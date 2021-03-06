﻿using System;
using ivyc.Basic;
using System.Text.RegularExpressions;
using System.Globalization;
namespace ivyc.AST {
	public enum PrimitiveLiteralKind {
		Null,
		Boolean,
		String,
		Number
	}
	public enum NumberLiteralKind {
		None = 0,
		Hexa,
		Int,
		Float
	}
	public enum NumberSuffixKind {
		None = 0,
		UInt8,
		UInt16,
		UInt32,
		UInt64,
		Int8,
		Int16,
		Int32,
		Int64,
		Unsigned
	}
	public enum StringPrefixKind {
		None = 0,
		UTF8,
		UTF16,
		UTF32,
		UTF8Char,
		UTF16Char,
		UTF32Char
	}

	public class PrimitiveLiteralNode : ExpressionNode {
		private PrimitiveLiteralNode(SourceLocation location) : base(location) {
		}

		public PrimitiveLiteralKind Kind { get; private set; }
		public NumberLiteralKind NumberKind { get; private set; }
		public NumberSuffixKind NumberSuffix { get; private set; }
		public StringPrefixKind StringPrefix { get; private set; }

		public bool IsNull => Kind == PrimitiveLiteralKind.Boolean;
		public bool IsBoolean => Kind == PrimitiveLiteralKind.Boolean;
		public bool IsString => Kind == PrimitiveLiteralKind.String;
		public bool IsNumber => Kind == PrimitiveLiteralKind.Number;

		public bool BooleanValue { get; private set; }
		public string StringValue { get; private set; }

		public static PrimitiveLiteralNode Null(SourceLocation location) {
			return new PrimitiveLiteralNode(location) {
				Kind = PrimitiveLiteralKind.Null,
				StringValue = "null"
			};
		}

		public static PrimitiveLiteralNode Boolean(SourceLocation location, bool value){
			return new PrimitiveLiteralNode(location) {
				Kind = PrimitiveLiteralKind.Boolean,
				StringValue = value ? "true" : "false"
			};
		}

		public static PrimitiveLiteralNode String(SourceLocation location, string value, StringPrefixKind prefix){
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return new PrimitiveLiteralNode(location) {
				Kind = PrimitiveLiteralKind.String,
				StringPrefix = prefix,
				StringValue = value
			};
		}

		public static PrimitiveLiteralNode Number(SourceLocation location, string value, NumberSuffixKind suffix){
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			ValidateNumber(value);

			return new PrimitiveLiteralNode(location) {
				Kind = PrimitiveLiteralKind.Number,
				NumberSuffix = suffix,
				StringValue = value,
				NumberKind = GetNumberKind(value)
			};
		}

		private static readonly Regex IntegerRegex = new Regex(@"^[\+\-]?[0-9]+$");
		private static readonly Regex FloatRegex = new Regex(@"^[\+\-]?[0-9]+(\.[0-9]+)?([eE][\+\-]?[0-9]+)?$");
		private static readonly Regex HexaRegex = new Regex(@"^0[xX][0123456789abcdefABCDEF]{1, 16}$");

		private static void ValidateNumber(string value) {
			var isNumber = IntegerRegex.IsMatch(value) || FloatRegex.IsMatch(value) || HexaRegex.IsMatch(value);

			if (!isNumber)
				throw new ArgumentException("value is not in a valid number format", nameof(value));
		}

		private static NumberLiteralKind GetNumberKind(string value) {
			if (value.StartsWith("0x", StringComparison.InvariantCulture) || value.StartsWith("0X", StringComparison.InvariantCulture))
				return NumberLiteralKind.Hexa;
			else if (value.Contains(".") || value.Contains("e") || value.Contains("E"))
				return NumberLiteralKind.Float;
			else
				return NumberLiteralKind.Int;
		}
}
}
