using System;
using LLVMSharp;
using System.Runtime.InteropServices;
using System.Text;
namespace ivyc.Basic {
	public enum NumberComparison {
		Eq,
		Gt,
		Ls,
		Invalid,
		Undef
	}
	public enum NumberBinaryOp {
		Add,
		Sub,
		Mult,
		Div,
		Rem,
		Shl,
		Shr,
		And,
		Or,
		Xor
	}
	public enum NumberUnaryOp {
		Not,
		Neg
	}

	public partial class Number : IEquatable<Number> {
		private string CachedString = null;

		public static Number operator +(Number n1, Number n2){
			return Perform(NumberBinaryOp.Add, n1, n2);
		}
		public static Number operator -(Number n1, Number n2) {
			return Perform(NumberBinaryOp.Sub, n1, n2);
		}
		public static Number operator *(Number n1, Number n2) {
			return Perform(NumberBinaryOp.Mult, n1, n2);
		}
		public static Number operator /(Number n1, Number n2) {
			return Perform(NumberBinaryOp.Div, n1, n2);
		}
		public static Number operator %(Number n1, Number n2) {
			return Perform(NumberBinaryOp.Rem, n1, n2);
		}
		public static Number operator &(Number n1, Number n2) {
			return Perform(NumberBinaryOp.And, n1, n2);
		}
		public static Number operator |(Number n1, Number n2) {
			return Perform(NumberBinaryOp.Or, n1, n2);
		}
		public static Number operator ^(Number n1, Number n2) {
			return Perform(NumberBinaryOp.Xor, n1, n2);
		}
		public static bool operator ==(Number n1, Number n2) {
			return n1.CompareTo(n2) == NumberComparison.Eq;
		}
		public static bool operator !=(Number n1, Number n2) {
			return n1.CompareTo(n2) != NumberComparison.Eq;
		}
		public static bool operator >(Number n1, Number n2) {
			return n1.CompareTo(n2) == NumberComparison.Gt;
		}
		public static bool operator <(Number n1, Number n2) {
			return n1.CompareTo(n2) == NumberComparison.Ls;
		}
		public static bool operator >=(Number n1, Number n2) {
			var cmp = n1.CompareTo(n2);
			return cmp == NumberComparison.Gt || cmp == NumberComparison.Eq;
		}
		public static bool operator <=(Number n1, Number n2) {
			var cmp = n1.CompareTo(n2);
			return cmp == NumberComparison.Ls || cmp == NumberComparison.Eq;
		}
		public static Number operator ~(Number n1) {
			return n1.Not();
		}
		public static Number operator -(Number n1) {
			return n1.Neg();
		}

		public static Number Perform(NumberBinaryOp op, Number n1, Number n2){
			switch (op) {
				case NumberBinaryOp.Add:
					return n1.Add(n2);
				case NumberBinaryOp.Sub:
					return n1.Subtract(n2);
				case NumberBinaryOp.Mult:
					return n1.Mult(n2);
				case NumberBinaryOp.Div:
					return n1.Div(n2);
				case NumberBinaryOp.Rem:
					return n1.Rem(n2);
				case NumberBinaryOp.Shl:
					return n1.Shl(n2);
				case NumberBinaryOp.Shr:
					return n1.Shr(n2);
				case NumberBinaryOp.And:
					return n1.And(n2);
				case NumberBinaryOp.Or:
					return n1.Or(n2);
				case NumberBinaryOp.Xor:
					return n1.Xor(n2);
				default:
					throw new NotSupportedException();
			}
		}
		public static Number Perform(NumberUnaryOp op, Number n) {
			switch (op) {
				case NumberUnaryOp.Not:
					return n.Not();
				case NumberUnaryOp.Neg:
					return n.Neg();
				default:
					throw new NotSupportedException();
			}
		}

		[DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "free")]
		private static extern unsafe void Free(void* ptr);

		public override string ToString() {
			if (CachedString != null)
				return CachedString;
			unsafe
			{
				var str = (byte*)LLVM.PrintValueToString(LLVMValue).ToPointer();
				var byteCount = StrLen(str);
				var count = Encoding.ASCII.GetCharCount(str, byteCount);
				var chars = stackalloc char[count];
				Encoding.ASCII.GetChars(str, byteCount, chars, count);
				CachedString = new string(chars, 0, count);
				Free(str);
			}
			return CachedString;
		}

		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}

		public override bool Equals(object obj) {
			return Equals(obj as Number);
		}

		unsafe int StrLen(byte* str) {
			int len = 0;
			while (*str != 0) {
				len++;
				str++;
			}
			return len;
		}

		public bool Equals(Number other) {
			if (other == null)
				return false;

			return this.ToString() == other.ToString();
		}

		static NumberKind OperationKind(NumberKind k1, NumberKind k2, bool unsignedWins = false) {
			if (k1.IsInteger()) {
				if (k2.IsInteger()) {
					var sameSignedness = (k1.IsSigned() && k2.IsSigned()) || (k1.IsUnsigned() && k2.IsUnsigned());
					if (sameSignedness) {
						var minKSize = Semantics.DefaultKind.BitSize(Semantics);
						var k1Size = k1.BitSize(Semantics);
						var k2Size = k2.BitSize(Semantics);

						if (k1Size < minKSize && k2Size < minKSize) {
							if (k1.IsSigned())
								return Semantics.DefaultKind.Signed();
							else
								return Semantics.DefaultKind.Unsigned();
						} else {
							var kSize = Math.Max(k1Size, k2Size);
							if (kSize == k1Size)
								return k1;
							else
								return k2;
						}
					} else {
						if (unsignedWins) {
							k1 = k1.Unsigned();
							k2 = k2.Unsigned();
						} else {
							k1 = k1.Signed();
							k2 = k2.Signed();
						}

						var minKSize = Semantics.DefaultKind.BitSize(Semantics);
						var k1Size = k1.BitSize(Semantics);
						var k2Size = k2.BitSize(Semantics);

						if (k1Size < minKSize && k2Size < minKSize) {
							if (k1.IsSigned())
								return Semantics.DefaultKind.Signed();
							else
								return Semantics.DefaultKind.Unsigned();
						} else {
							var kSize = Math.Max(k1Size, k2Size);
							if (kSize == k1Size)
								return k1;
							else
								return k2;
						}
					}
				} else {
					return k2;
				}

			} else {
				if (k2.IsInteger()) {
					return k1;
				} else {
					var k1Size = k1.BitSize(Semantics);
					var k2Size = k2.BitSize(Semantics);

					if (k1Size == k2Size) {
						if (k1 == k2)
							return k1;
						else {
							return GetBestFloatKind(k1, k2);
						}
					} else {
						var biggest = Math.Max(k1Size, k2Size);
						return biggest == k1Size ? k1 : k2;
					}
				}
			}
		}

		static NumberKind GetBestFloatKind(NumberKind k1, NumberKind k2) {
			var kSize = k1.BitSize(Semantics);
			if (kSize == 64)
				return NumberKind.Double;
			else if (kSize == 32)
				return NumberKind.Float;
			else {
				if (k1 == NumberKind.Real || k2 == NumberKind.Real)
					return NumberKind.Real;
				else
					return NumberKind.Quad;
			}
		}

		public NumberComparison CompareTo(Number n) {
			if (this.HasErrors || n.HasErrors)
				return NumberComparison.Invalid;

			var opKind = OperationKind(this.Kind, n.Kind);
			var op1 = this.Convert(opKind);
			var op2 = n.Convert(opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstICmp(LLVMIntPredicate.LLVMIntEQ, op1.LLVMValue, op2.LLVMValue).ConstIntGetZExtValue();
				if (result == 1)
					return NumberComparison.Eq;
				else {
					result = LLVM.ConstICmp(opKind.IsSigned() ? LLVMIntPredicate.LLVMIntSGT : LLVMIntPredicate.LLVMIntUGT,
											op1.LLVMValue,
											op2.LLVMValue).ConstIntGetZExtValue();

					return result == 1 ? NumberComparison.Gt : NumberComparison.Ls;
				}
			} else {
				var result = LLVMExt.APFloatCompare(op1.APFloat, op2.APFloat);
				switch (result) {
					case 0:
						return NumberComparison.Ls;
					case 1:
						return NumberComparison.Eq;
					case 2:
						return NumberComparison.Gt;
					default:
						return NumberComparison.Undef;
				}
			}
		}

		public Number Add(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstAdd(this.Value, n.Value);
				var state = CheckForOpOverflow(opKind, result);

				if (state != NumberState.Ok)
					return new Number(state | this.State | n.State, opKind);
				else
					return new Number(dummy: string.Empty) {
						Value = result,
						State = this.State | n.State,
						Kind = opKind
					};
			}
			else {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);

				if (op1 == this)
					op1 = op1.Duplicate();
				op1.State |= (NumberState)LLVMExt.APFloatAdd(op1.APFloat, op2.APFloat, RoundingMode);
				return op1;
			}
		}

		public Number Subtract(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstSub(this.Value, n.Value);
				var state = CheckForOpOverflow(opKind, result);

				if (state != NumberState.Ok)
					return new Number(state | this.State | n.State, opKind);
				else
					return new Number(dummy: string.Empty) {
						Value = result,
						State = this.State | n.State,
						Kind = opKind
					};
			} else {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);

				if (op1 == this)
					op1 = op1.Duplicate();
				op1.State |= (NumberState)LLVMExt.APFloatSub(op1.APFloat, op2.APFloat, RoundingMode);
				return op1;
			}
		}

		public Number Mult(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstMul(this.Value, n.Value);
				var state = CheckForOpOverflow(opKind, result);

				if (state != NumberState.Ok)
					return new Number(state | this.State | n.State, opKind);
				else
					return new Number(dummy: string.Empty) {
						Value = result,
						State = this.State | n.State,
						Kind = opKind
					};
			} else {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);

				if (op1 == this)
					op1 = op1.Duplicate();
				op1.State |= (NumberState)LLVMExt.APFloatMult(op1.APFloat, op2.APFloat, RoundingMode);
				return op1;
			}
		}

		public Number Div(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = opKind.IsSigned() ? LLVM.ConstSDiv(this.Value, n.Value) : LLVM.ConstUDiv(this.Value, n.Value);
				var state = CheckForOpOverflow(opKind, result);

				if (state != NumberState.Ok)
					return new Number(state | this.State | n.State, opKind);
				else
					return new Number(dummy: string.Empty) {
						Value = result,
						State = this.State | n.State,
						Kind = opKind
					};
			} else {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);

				if (op1 == this)
					op1 = op1.Duplicate();
				op1.State |= (NumberState)LLVMExt.APFloatDiv(op1.APFloat, op2.APFloat, RoundingMode);
				return op1;
			}
		}

		public Number Rem(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = opKind.IsSigned() ? LLVM.ConstSRem(this.Value, n.Value) : LLVM.ConstURem(this.Value, n.Value);
				var state = CheckForOpOverflow(opKind, result);

				if (state != NumberState.Ok)
					return new Number(state | this.State | n.State, opKind);
				else
					return new Number(dummy: string.Empty) {
						Value = result,
						State = this.State | n.State,
						Kind = opKind
					};
			} else {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);

				if (op1 == this)
					op1 = op1.Duplicate();
				op1.State |= (NumberState)LLVMExt.APFloatMod(op1.APFloat, op2.APFloat);
				return op1;
			}
		}

		public Number Shl(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if(!opKind.IsFloat()){
				if (this.Kind.IsSigned())
					opKind = opKind.Signed();
				else
					opKind = opKind.Unsigned();
			}
			
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);
				var result = LLVM.ConstShl(op1.LLVMValue, op2.LLVMValue);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = opKind.IsSigned() ? LLVM.ConstSExt(result, LLVM.Int128Type()) : LLVM.ConstZExt(result, LLVM.Int128Type()),
					State = this.State | n.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				return new Number(dummy: string.Empty) {
					State = this.State | n.State | NumberState.Invalid,
					Kind = opKind
				};
			}
		}

		public Number Shr(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind);
			if (!opKind.IsFloat()) {
				if (this.Kind.IsSigned())
					opKind = opKind.Signed();
				else
					opKind = opKind.Unsigned();
			}

			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var op1 = this.Convert(opKind);
				var op2 = n.Convert(opKind);
				var result = opKind.IsSigned() ? LLVM.ConstAShr(op1.LLVMValue, op2.LLVMValue) : LLVM.ConstLShr(op1.LLVMValue, op2.LLVMValue);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = opKind.IsSigned() ? LLVM.ConstSExt(result, LLVM.Int128Type()) : LLVM.ConstZExt(result, LLVM.Int128Type()),
					State = this.State | n.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				return new Number(dummy: string.Empty) {
					State = this.State | n.State | NumberState.Invalid,
					Kind = opKind
				};
			}
		}

		public Number And(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind, unsignedWins: true);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstAnd(this.Value, n.Value);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = result,
					State = this.State | n.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				return new Number(dummy: string.Empty) {
					State = this.State | n.State | NumberState.Invalid,
					Kind = opKind
				};
			}
		}

		public Number Or(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind, unsignedWins: true);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstOr(this.Value, n.Value);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = result,
					State = this.State | n.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				return new Number(dummy: string.Empty) {
					State = this.State | n.State | NumberState.Invalid,
					Kind = opKind
				};
			}
		}

		public Number Xor(Number n) {
			var opKind = OperationKind(this.Kind, n.Kind, unsignedWins: true);
			if (this.HasErrors || n.HasErrors)
				return new Number(this.State | n.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstXor(this.Value, n.Value);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = result,
					State = this.State | n.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				return new Number(dummy: string.Empty) {
					State = this.State | n.State | NumberState.Invalid,
					Kind = opKind
				};
			}
		}

		public Number Not() {
			var opKind = OperationKind(this.Kind, NumberKind.UInt8);
			if (this.HasErrors)
				return new Number(this.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstNot(this.Value);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = result,
					State = this.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				return new Number(dummy: string.Empty) {
					State = this.State | NumberState.Invalid,
					Kind = opKind
				};
			}
		}

		public Number Neg() {
			var opKind = OperationKind(this.Kind, NumberKind.UInt8);
			if (this.HasErrors)
				return new Number(this.State, opKind);

			if (opKind.IsInteger()) {
				var result = LLVM.ConstNeg(this.Value);
				var undef = result.IsUndef();

				return new Number(dummy: string.Empty) {
					Value = result,
					State = this.State | (undef ? NumberState.Invalid : NumberState.Ok),
					Kind = opKind
				};
			} else {
				var dup = this.Duplicate();
				var minusOne = new Number(-1.0, this.Kind);
				var state = (NumberState)LLVMExt.APFloatMult(dup.APFloat, minusOne.APFloat, RoundingMode);
				var result = dup.APFloat;
				dup.APFloat = new LLVMAPFloatRef(IntPtr.Zero);

				return new Number(dummy: string.Empty) {
					APFloat = result,
					State = this.State | state,
					Kind = opKind
				};
			}
		}

		public Number Duplicate() {
			var dup = new Number(dummy: string.Empty);
			dup.State = this.State;
			dup.Kind = this.Kind;
			if(this.Value.Pointer.ToInt64() != 0){
				dup.Value = Value;
			}
			if (this.APFloat.Pointer.ToInt64() != 0) {
				int status;
				dup.APFloat = LLVMExt.APFloatFromAPFloat(this.APFloat, GetAPFloatSemantics(this.Kind), out status);
			}
			return dup;
		}

		NumberState CheckForOpOverflow(NumberKind opKind, LLVMValueRef result) {
			if(opKind.IsSigned()){
				var lessThan = LLVM.ConstICmp(LLVMIntPredicate.LLVMIntSLT, result, MinLongLLVMValue).ConstIntGetZExtValue() == 1;
				if (lessThan)
					return NumberState.Underflow;
				var greatherThan = LLVM.ConstICmp(LLVMIntPredicate.LLVMIntSGT, result, MaxLongLLVMValue).ConstIntGetZExtValue() == 1;
				if (greatherThan)
					return NumberState.Overflow;

				var overflows = CheckForOverflow(result.ConstIntGetSExtValue(), opKind);
				if (overflows == 1)
					return NumberState.Overflow;
				else if (overflows == -1)
					return NumberState.Underflow;
				else
					return NumberState.Ok;
			}
			else {
				var greatherThan = LLVM.ConstICmp(LLVMIntPredicate.LLVMIntUGT, result, MaxULongLLVMValue).ConstIntGetZExtValue() == 1;
				if (greatherThan)
					return NumberState.Overflow;

				var overflows = CheckForOverflow(result.ConstIntGetZExtValue(), opKind);
				if (overflows == 1)
					return NumberState.Overflow;
				else if (overflows == -1)
					return NumberState.Underflow;
				else
					return NumberState.Ok;
			}
		}
	}
}
