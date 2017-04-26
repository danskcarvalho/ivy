using System;
using LLVMSharp;
using System.Text.RegularExpressions;
using System.Globalization;
namespace ivyc.Basic {
	public enum NumberKind {
		Int8,
		Int16,
		Int32,
		Int64,
		UInt8,
		UInt16,
		UInt32,
		UInt64,
		Float,
		Double,
		LongDouble,
		Quad
	}
	public static class NumberKindExtensions {
		public static bool IsInteger(this NumberKind kind){
			switch (kind) {
				case NumberKind.Int8:
				case NumberKind.Int16:
				case NumberKind.Int32:
				case NumberKind.Int64:
				case NumberKind.UInt8:
				case NumberKind.UInt16:
				case NumberKind.UInt32:
				case NumberKind.UInt64:
					return true;
				default:
					return false;
			}
		}
		public static bool IsFloat(this NumberKind kind) {
			return !IsInteger(kind);
		}
		public static bool IsSigned(this NumberKind kind){
			switch (kind) {
				case NumberKind.Int8:
				case NumberKind.Int16:
				case NumberKind.Int32:
				case NumberKind.Int64:
				case NumberKind.Float:
				case NumberKind.Double:
				case NumberKind.LongDouble:
				case NumberKind.Quad:
					return true;
				default:
					return false;
			}
		}
		public static bool IsUnsigned(this NumberKind kind){
			return !IsSigned(kind);
		}
		public static NumberKind Signed(this NumberKind kind){
			switch (kind) {
				case NumberKind.UInt8:
					return NumberKind.Int8;
				case NumberKind.UInt16:
					return NumberKind.Int16;
				case NumberKind.UInt32:
					return NumberKind.Int32;
				case NumberKind.UInt64:
					return NumberKind.Int64;
				default:
					return kind;
			}
		}
		public static NumberKind Unsigned(this NumberKind kind){
			switch (kind) {
				case NumberKind.Int8:
				case NumberKind.UInt8:
					return NumberKind.UInt8;
				case NumberKind.Int16:
				case NumberKind.UInt16:
					return NumberKind.UInt16;
				case NumberKind.Int32:
				case NumberKind.UInt32:
					return NumberKind.UInt32;
				case NumberKind.Int64:
				case NumberKind.UInt64:
					return NumberKind.UInt64;
				default:
					throw new NotSupportedException("doesn't have an unsigned counterpart");
			}
		}
		public static int BitSize(this NumberKind kind, NumberSemantics semantics = null){
			switch (kind) {
				case NumberKind.Int8:
					return 8;
				case NumberKind.Int16:
					return 16;
				case NumberKind.Int32:
					return 32;
				case NumberKind.Int64:
					return 64;
				case NumberKind.UInt8:
					return 8;
				case NumberKind.UInt16:
					return 16;
				case NumberKind.UInt32:
					return 32;
				case NumberKind.UInt64:
					return 64;
				case NumberKind.Float:
					return 32;
				case NumberKind.Double:
					return 64;
				case NumberKind.LongDouble:
				case NumberKind.Quad:
					switch (kind == NumberKind.LongDouble ? semantics.LongDoubleSemantics : semantics.QuadSemantics) {
						case FloatSemantics.IEEEHalf:
							return 16;
						case FloatSemantics.IEEESingle:
							return 32;
						case FloatSemantics.IEEEDouble:
							return 64;
						case FloatSemantics.IEEEQuad:
							return 128;
						case FloatSemantics.PPCDoubleDouble:
							return 128;
						case FloatSemantics.X87DoubleExtended:
							return 80;
						default:
							throw new NotSupportedException();
					}
				default:
					throw new NotSupportedException();
			}
		}
	}
	[Flags]
	public enum NumberState {
		Ok = 0,
		Invalid = 1,
		DivByZero = 2,
		Overflow = 4,
		Underflow = 8,
		Inexact = 16
	}
	public enum FloatSemantics {
		IEEEHalf = 0,
		IEEESingle = 1,
		IEEEDouble = 2,
		IEEEQuad = 3,
		PPCDoubleDouble = 4,
		X87DoubleExtended = 5
	}
	public class NumberSemantics {
		public NumberKind DefaultKind { get; private set; }
		public FloatSemantics LongDoubleSemantics { get; private set; }
		public FloatSemantics QuadSemantics { get; private set; }

		public NumberSemantics(){
			DefaultKind = NumberKind.Int32;
			LongDoubleSemantics = FloatSemantics.X87DoubleExtended;
			QuadSemantics = FloatSemantics.IEEEQuad;
		}
		public NumberSemantics(
			NumberKind DefaultKind = NumberKind.Int32, 
			FloatSemantics LongDoubleSemantics = FloatSemantics.X87DoubleExtended,
			FloatSemantics QuadSemantics = FloatSemantics.IEEEQuad){
			if (!DefaultKind.IsInteger())
				throw new ArgumentException("DefaultKind must be an integer", nameof(DefaultKind));
			this.DefaultKind = DefaultKind;
			this.LongDoubleSemantics = LongDoubleSemantics;
			this.QuadSemantics = QuadSemantics;
		}
		public static readonly NumberSemantics Default = new NumberSemantics();
	}
	public partial class Number {
		private const int RoundingMode = 0;
		[ThreadStatic]
		private static NumberSemantics FSemantics = null;
		public static NumberSemantics Semantics {
			get {
				if (FSemantics == null)
					FSemantics = NumberSemantics.Default;

				return FSemantics;
			}
			set {
				FSemantics = value ?? NumberSemantics.Default;
			}
		}

		private LLVMAPFloatRef APFloat;
		private LLVMValueRef Value;
		private LLVMValueRef ExternalValue;
		private double? CachedDoubleValue;
		private long? CachedLongValue;
		private ulong? CachedULongValue;

		static Number(){
			MaxLongValue = LLVMExt.APFloatZero(APFloatSemantics.IEEEquad);
			MinLongValue = LLVMExt.APFloatZero(APFloatSemantics.IEEEquad);
			MaxULongValue = LLVMExt.APFloatZero(APFloatSemantics.IEEEquad);
			MinULongValue = LLVMExt.APFloatZero(APFloatSemantics.IEEEquad);

			LLVMExt.APFloatFromString(MaxLongValue, long.MaxValue.ToString(CultureInfo.InvariantCulture), RoundingMode);
			LLVMExt.APFloatFromString(MinLongValue, long.MinValue.ToString(CultureInfo.InvariantCulture), RoundingMode);
			LLVMExt.APFloatFromString(MaxULongValue, ulong.MaxValue.ToString(CultureInfo.InvariantCulture), RoundingMode);
			LLVMExt.APFloatFromString(MinULongValue, ulong.MinValue.ToString(CultureInfo.InvariantCulture), RoundingMode);

			MaxLongLLVMValue = LLVM.ConstInt(LLVM.Int128Type(), long.MaxValue, new LLVMBool(1));
			MinLongLLVMValue = LLVM.ConstInt(LLVM.Int128Type(), unchecked((ulong)long.MinValue), new LLVMBool(1));
			MaxULongLLVMValue = LLVM.ConstInt(LLVM.Int128Type(), ulong.MaxValue, new LLVMBool(0));
		}

		private Number(string dummy){
			
		}
		private Number(NumberState state, NumberKind kind){
			this.State = state;
			this.Kind = kind;
		}
		public Number() {
			this.State = NumberState.Ok;
			this.Kind = Semantics.DefaultKind;
			this.Value = LLVM.ConstInt(GetLLVMType(), 0, new LLVMBool(0));
		}
		public Number(string number, NumberKind numberKind) {
			if (number == null)
				throw new ArgumentNullException(nameof(number));
			
			this.Kind = numberKind;

			if(numberKind.IsInteger()){
				this.State = CheckIntegerString(number, numberKind);
				if (!this.HasErrors)
					this.Value = LLVM.ConstIntOfString(LLVM.Int128Type(), number, 10);
			}
			else {
				this.State = CheckFloatString(number);
				if (!this.HasErrors) {
					this.APFloat = LLVMExt.APFloatZero(GetAPFloatSemantics(this.Kind));
					this.State |= (NumberState)LLVMExt.APFloatFromString(this.APFloat, number, RoundingMode);
				}
			}
		}

		public Number(long number, NumberKind numberKind) {
			this.Kind = numberKind;

			if(numberKind.IsInteger()){
				var overflows = CheckForOverflow(number, numberKind);
				if (overflows == 1)
					this.State = NumberState.Overflow;
				else if (overflows == -1)
					this.State = NumberState.Underflow;

				if (!HasErrors)
					this.Value = LLVM.ConstInt(GetLLVMType(), (ulong)number, new LLVMBool(1));
			}
			else {
				this.APFloat = LLVMExt.APFloatZero(GetAPFloatSemantics(this.Kind));
				this.State |= (NumberState)LLVMExt.APFloatFromString(this.APFloat, number.ToString(CultureInfo.InvariantCulture), RoundingMode);
			}
		}
		public Number(ulong number, NumberKind numberKind) {
			this.Kind = numberKind;

			if (numberKind.IsInteger()) {
				var overflows = CheckForOverflow(number, numberKind);
				if (overflows == 1)
					this.State = NumberState.Overflow;
				else if (overflows == -1)
					this.State = NumberState.Underflow;

				if (!HasErrors)
					this.Value = LLVM.ConstInt(GetLLVMType(), number, new LLVMBool(0));
			} else {
				this.APFloat = LLVMExt.APFloatZero(GetAPFloatSemantics(this.Kind));
				this.State |= (NumberState)LLVMExt.APFloatFromString(this.APFloat, number.ToString(CultureInfo.InvariantCulture), RoundingMode);
			}
   		}
		public Number(double number, NumberKind numberKind) {
			this.Kind = numberKind;

			if (numberKind.IsInteger()) {
				var overflows = CheckForOverflow(number, numberKind);
				if (overflows == 1)
					this.State = NumberState.Overflow;
				else if (overflows == -1)
					this.State = NumberState.Underflow;

				if (!HasErrors) {
					this.Value = LLVM.ConstReal(LLVM.DoubleType(), number);
					if (numberKind.IsSigned())
						this.Value = LLVM.ConstFPToSI(this.Value, GetLLVMType());
					else
						this.Value = LLVM.ConstFPToUI(this.Value, GetLLVMType());
				}
			} else {
				int state;
				this.APFloat = LLVMExt.APFloatFromDouble(number, GetAPFloatSemantics(this.Kind), out state);
				this.State |= (NumberState)state;
			}
		}

		~Number(){
			if (this.APFloat.Pointer.ToInt64() != 0)
				LLVMExt.APFloatDispose(this.APFloat);
		}

		public NumberKind Kind { get; private set; }
		public NumberState State { get; private set; }
		public bool IsOk => State == NumberState.Ok;
		public bool IsInvalid => (State & NumberState.Invalid) == NumberState.Invalid;
		public bool IsDivByZero => (State & NumberState.DivByZero) == NumberState.DivByZero;
		public bool IsOverflow => (State & NumberState.Overflow) == NumberState.Overflow;
		public bool IsUnderflow => (State & NumberState.Underflow) == NumberState.Underflow;
		public bool IsInexact => (State & NumberState.Inexact) == NumberState.Inexact;
		public bool HasErrors => IsInvalid || IsDivByZero || IsOverflow || IsUnderflow;

		public sbyte Int8Value {
			get {
				return unchecked((sbyte)Int64Value);
			}
		}
		public short Int16Value {
			get {
				return unchecked((short)Int64Value);
			}
		}
		public int Int32Value {
			get {
				return unchecked((int)Int64Value);
			}
		}
		public long Int64Value {
			get {
				if (HasErrors)
					return 0;

				if (CachedLongValue.HasValue)
					return CachedLongValue.Value;
				
				if (Kind.IsInteger()) {
					if (Kind.IsSigned())
						CachedLongValue = LLVM.ConstIntGetSExtValue(Value);
					else
						CachedLongValue = (long)LLVM.ConstIntGetZExtValue(Value);
				} else {
					CachedLongValue = (long)LLVMExt.APFloatToDouble(APFloat);
				}
				return CachedLongValue.Value;
			}
		}
		public byte UInt8Value {
			get {
				return unchecked((byte)UInt64Value);
			}
		}
		public ushort UInt16Value {
			get {
				return unchecked((ushort)UInt64Value);
			}
		}
		public uint UInt32Value {
			get {
				return unchecked((uint)UInt64Value);
			}
		}
		public ulong UInt64Value {
			get {
				if (HasErrors)
					return 0;
				if (CachedULongValue.HasValue)
					return CachedULongValue.Value;
				if (Kind.IsInteger()) {
					if (Kind.IsSigned())
						CachedULongValue = (ulong)LLVM.ConstIntGetSExtValue(Value);
					else
						CachedULongValue = LLVM.ConstIntGetZExtValue(Value);
				} else {
					CachedULongValue = (ulong)LLVMExt.APFloatToDouble(APFloat);
				}
				return CachedULongValue.Value;
			}
		}
		public float FloatValue {
			get {
				return (float)DoubleValue;
			}
		}
		public double DoubleValue {
			get {
				if (HasErrors)
					return 0;

				if (CachedDoubleValue.HasValue)
					return CachedDoubleValue.Value;
				if (Kind.IsInteger()) {
					if (Kind.IsSigned())
						CachedDoubleValue = LLVM.ConstIntGetSExtValue(Value);
					else
						CachedDoubleValue = LLVM.ConstIntGetZExtValue(Value);
				} else {
					CachedDoubleValue = LLVMExt.APFloatToDouble(APFloat);
				}
				return CachedDoubleValue.Value;
			}
		}
		public LLVMValueRef LLVMValue {
			get {
				if(ExternalValue.Pointer.ToInt64() == 0){
					if (APFloat.Pointer.ToInt64() != 0)
						ExternalValue = LLVMExt.APFloatToValue(APFloat);
					else if (Value.Pointer.ToInt64() != 0)
						ExternalValue = LLVM.ConstIntCast(Value, GetLLVMType(internalType: false), new LLVMBool(this.Kind.IsSigned() ? 1 : 0));
					else
						LoadZeroExternalValue();
				}
				return ExternalValue;
			}
		}

		public bool IsZero {
			get {
				if (HasErrors)
					return false;

#pragma warning disable RECS0018 // Comparison of floating point numbers with equality operator
				return DoubleValue == 0;
#pragma warning restore RECS0018 // Comparison of floating point numbers with equality operator
			}
		}
		public bool IsPositive {
			get {
				if (HasErrors)
					return false;

				return DoubleValue >= 0;
			}
		}
		public bool IsStrictlyPositive {
			get {
				if (HasErrors)
					return false;

				return DoubleValue > 0;
			}
		}
		public bool IsNegative {
			get {
				if (HasErrors)
					return false;

				return DoubleValue < 0;
			}
		}

		public Number Convert(NumberKind kind){
			if (kind == this.Kind)
				return this;
			if (this.HasErrors)
				return new Number(this.State, this.Kind);

			if(this.Kind.IsInteger()){
				if (this.Kind.IsSigned()) {
					var n = new Number(this.Int64Value, kind);
					n.State |= this.State;
					return n;
				} else {
					var n = new Number(this.UInt64Value, kind);
					n.State |= this.State;
					return n;
				}
			}
			else {
				if (kind.IsFloat()) {
					int status;
					var apFloat = LLVMExt.APFloatFromAPFloat(this.APFloat, GetAPFloatSemantics(kind), out status);
					return new Number(dummy: string.Empty) {
						APFloat = apFloat,
						State = this.State | (NumberState)status,
						Kind = kind
					};
				} else {
					if (this.Kind == NumberKind.Double) {
						var n = new Number(this.DoubleValue, kind);
						n.State |= this.State;
						return n;
					} else if (this.Kind == NumberKind.Float) {
						var n = new Number(this.FloatValue, kind);
						n.State |= this.State;
						return n;
					} else {
						if (kind.IsSigned()) {
							var overflows = CheckForLongOverflow();
							if (overflows == 1)
								return new Number(NumberState.Overflow, kind);
							else if (overflows == -1)
								return new Number(NumberState.Underflow, kind);
							else {
								var longValue = LLVM.ConstFPToSI(LLVMExt.APFloatToValue(APFloat), LLVM.Int64Type());
								var longValue2 = LLVM.ConstIntGetSExtValue(longValue);

								return new Number(longValue2, kind);
							}
						} else {
							var overflows = CheckForULongOverflow();
							if (overflows == 1)
								return new Number(NumberState.Overflow, kind);
							else if (overflows == -1)
								return new Number(NumberState.Underflow, kind);
							else {
								var ulongValue = LLVM.ConstFPToUI(LLVMExt.APFloatToValue(APFloat), LLVM.Int64Type());
								var ulongValue2 = LLVM.ConstIntGetZExtValue(ulongValue);

								return new Number(ulongValue2, kind);
							}
						}
					}
				}
			}
		}
		private static Regex IntegerRegex = new Regex(@"^[\+\-]?[0-9]+$");
		private static Regex FloatRegex = new Regex(@"^[\+\-]?[0-9]+(\.[0-9]+)?([eE][\+\-]?[0-9]+)?$");

		static NumberState CheckIntegerString(string number, NumberKind numberKind) {
			if (!IntegerRegex.IsMatch(number))
				return NumberState.Invalid;

			var isNegative = number.StartsWith("-", StringComparison.InvariantCultureIgnoreCase);
			var overflows = CheckForOverflow(number, numberKind);

			return overflows ? (isNegative ? NumberState.Underflow : NumberState.Overflow) : NumberState.Ok;
		}

		private static LLVMAPFloatRef MaxLongValue;
		private static LLVMAPFloatRef MinLongValue;
		private static LLVMAPFloatRef MaxULongValue;
		private static LLVMAPFloatRef MinULongValue;

		private static LLVMValueRef MaxLongLLVMValue;
		private static LLVMValueRef MinLongLLVMValue;
		private static LLVMValueRef MaxULongLLVMValue;

		int CheckForLongOverflow() {
			switch(this.Kind){
				case NumberKind.LongDouble:
				case NumberKind.Quad:
					int status;
					LLVMAPFloatRef apFloat = LLVMExt.APFloatFromAPFloat(APFloat, APFloatSemantics.IEEEquad, out status);
					var comparisonMax = LLVMExt.APFloatCompare(apFloat, MaxLongValue);
					var comparisonMin = LLVMExt.APFloatCompare(apFloat, MinLongValue);
					LLVMExt.APFloatDispose(apFloat);

					if (comparisonMax == 2)
						return 1;
					if (comparisonMin == 0)
						return -1;
					return 0;
				default:
					throw new NotSupportedException();
			}
		}

		int CheckForULongOverflow() {
			switch (this.Kind) {
				case NumberKind.LongDouble:
				case NumberKind.Quad:
					int status;
					LLVMAPFloatRef apFloat = LLVMExt.APFloatFromAPFloat(APFloat, APFloatSemantics.IEEEquad, out status);
					var comparisonMax = LLVMExt.APFloatCompare(apFloat, MaxULongValue);
					var comparisonMin = LLVMExt.APFloatCompare(apFloat, MinULongValue);
					LLVMExt.APFloatDispose(apFloat);

					if (comparisonMax == 2)
						return 1;
					if (comparisonMin == 0)
						return -1;
					return 0;
				default:
					throw new NotSupportedException();
			}
		}

		static bool CheckForOverflow(string number, NumberKind numberKind) {
			try {
				switch (numberKind) {
					case NumberKind.Int8:
						sbyte.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.Int16:
						short.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.Int32:
						int.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.Int64:
						long.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.UInt8:
						byte.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.UInt16:
						ushort.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.UInt32:
						uint.Parse(number, CultureInfo.InvariantCulture);
						break;
					case NumberKind.UInt64:
						ulong.Parse(number, CultureInfo.InvariantCulture);
						break;
					default:
						throw new NotSupportedException();
				}
				return false;
			}
			catch {
				return true;
			}
		}

		static int CheckForOverflow(long number, NumberKind numberKind) {
			switch (numberKind) {
				case NumberKind.Int8:
					return number > sbyte.MaxValue ? 1 : (number < sbyte.MinValue ? -1 : 0);
				case NumberKind.Int16:
					return number > short.MaxValue ? 1 : (number < short.MinValue ? -1 : 0);
				case NumberKind.Int32:
					return number > int.MaxValue ? 1 : (number < int.MinValue ? -1 : 0);
				case NumberKind.Int64:
					return 0;
				case NumberKind.UInt8:
					return number > (long)byte.MaxValue ? 1 : (number < 0 ? -1 : 0);
				case NumberKind.UInt16:
					return number > (long)ushort.MaxValue ? 1 : (number < 0 ? -1 : 0);
				case NumberKind.UInt32:
					return number > (long)uint.MaxValue ? 1 : (number < 0 ? -1 : 0);
				case NumberKind.UInt64:
					return (number < 0 ? -1 : 0);
				default:
					return 0;
			}
		}

		static int CheckForOverflow(ulong number, NumberKind numberKind) {
			switch (numberKind) {
				case NumberKind.Int8:
					return number > (ulong)sbyte.MaxValue ? 1 : 0;
				case NumberKind.Int16:
					return number > (ulong)short.MaxValue ? 1 : 0;
				case NumberKind.Int32:
					return number > (ulong)int.MaxValue ? 1 : 0;
				case NumberKind.Int64:
					return number > (ulong)long.MaxValue ? 1 : 0;
				case NumberKind.UInt8:
					return number > (ulong)byte.MaxValue ? 1 : 0;
				case NumberKind.UInt16:
					return number > (ulong)ushort.MaxValue ? 1 : 0;
				case NumberKind.UInt32:
					return number > (ulong)uint.MaxValue ? 1 : 0;
				case NumberKind.UInt64:
					return 0;
				default:
					return 0;
			}
		}

		static int CheckForOverflow(double number, NumberKind numberKind) {
			switch (numberKind) {
				case NumberKind.Int8:
					return number > sbyte.MaxValue ? 1 : (number < sbyte.MinValue ? -1 : 0);
				case NumberKind.Int16:
					return number > short.MaxValue ? 1 : (number < short.MinValue ? -1 : 0);
				case NumberKind.Int32:
					return number > int.MaxValue ? 1 : (number < int.MinValue ? -1 : 0);
				case NumberKind.Int64:
					return number > long.MaxValue ? 1 : (number < long.MinValue ? -1 : 0);
				case NumberKind.UInt8:
					return number > byte.MaxValue ? 1 : (number < 0 ? -1 : 0);
				case NumberKind.UInt16:
					return number > ushort.MaxValue ? 1 : (number < 0 ? -1 : 0);
				case NumberKind.UInt32:
					return number > uint.MaxValue ? 1 : (number < 0 ? -1 : 0);
				case NumberKind.UInt64:
					return number > ulong.MaxValue ? 1 : (number < 0 ? -1 : 0);
				default:
					return 0;
			}
		}

		static NumberState CheckFloatString(string number) {
			return FloatRegex.IsMatch(number) ? NumberState.Ok : NumberState.Invalid;
		}

		void LoadZeroExternalValue() {
			this.ExternalValue = LLVM.ConstInt(GetLLVMType(internalType: false), 0, new LLVMBool(0));
		}

		LLVMTypeRef GetLLVMType(bool internalType = true) {
			switch (this.Kind) {
				case NumberKind.Int8:
					return internalType ? LLVM.Int128Type() : LLVM.Int8Type();
				case NumberKind.Int16:
					return internalType ? LLVM.Int128Type() : LLVM.Int16Type();
				case NumberKind.Int32:
					return internalType ? LLVM.Int128Type() : LLVM.Int32Type();
				case NumberKind.Int64:
					return internalType ? LLVM.Int128Type() : LLVM.Int64Type();
				case NumberKind.UInt8:
					return internalType ? LLVM.Int128Type() : LLVM.Int8Type();
				case NumberKind.UInt16:
					return internalType ? LLVM.Int128Type() : LLVM.Int16Type();
				case NumberKind.UInt32:
					return internalType ? LLVM.Int128Type() : LLVM.Int32Type();
				case NumberKind.UInt64:
					return internalType ? LLVM.Int128Type() : LLVM.Int64Type();
				case NumberKind.Float:
					return LLVM.FloatType();
				case NumberKind.Double:
					return LLVM.DoubleType();
				case NumberKind.LongDouble:
				case NumberKind.Quad:
					switch (this.Kind == NumberKind.LongDouble ? Semantics.LongDoubleSemantics : Semantics.QuadSemantics) {
						case FloatSemantics.IEEEHalf:
							return LLVM.HalfType();
						case FloatSemantics.IEEESingle:
							return LLVM.FloatType();
						case FloatSemantics.IEEEDouble:
							return LLVM.DoubleType();
						case FloatSemantics.IEEEQuad:
							return LLVM.FP128Type();
						case FloatSemantics.PPCDoubleDouble:
							return LLVM.PPCFP128Type();
						case FloatSemantics.X87DoubleExtended:
							return LLVM.X86FP80Type();
						default:
							throw new NotSupportedException();
					}
				default:
					throw new NotSupportedException();
			}
		}

		static APFloatSemantics GetAPFloatSemantics(NumberKind kind) {
			switch (kind) {
				case NumberKind.Float:
					return APFloatSemantics.IEEEsingle;
				case NumberKind.Double:
					return APFloatSemantics.IEEEdouble;
				case NumberKind.LongDouble:
				case NumberKind.Quad:
					switch (kind == NumberKind.LongDouble ? Semantics.LongDoubleSemantics : Semantics.QuadSemantics) {
						case FloatSemantics.IEEEHalf:
							return APFloatSemantics.IEEEhalf;
						case FloatSemantics.IEEESingle:
							return APFloatSemantics.IEEEsingle;
						case FloatSemantics.IEEEDouble:
							return APFloatSemantics.IEEEdouble;
						case FloatSemantics.IEEEQuad:
							return APFloatSemantics.IEEEquad;
						case FloatSemantics.PPCDoubleDouble:
							return APFloatSemantics.PPCDoubleDouble;
						case FloatSemantics.X87DoubleExtended:
							return APFloatSemantics.X87DoubleExtended;
						default:
							throw new NotSupportedException();
					}
				default:
					throw new NotSupportedException();
			}
		}
	}
}
