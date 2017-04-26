using System;
namespace ivyc.Basic {
	/// <summary>
	/// Generic Operator
	/// </summary>
	public enum OperatorName {
		None = 0,
		BitNot,
		BitAnd,
		BitOr,
		BitXor,
		Add,
		Sub,
		Mult,
		Div,
		Rem,
		Inc,
		Dec,
		Eq,
		NotEq,
		Gt,
		Lt,
		GtEq,
		LtEq,
		Not,
		And,
		Or,
		Shl,
		Shr,
		Assign,
		AddAssign,
		SubAssign,
		MultAssign,
		DivAssign,
		RemAssign,
		ShlAssign,
		ShrAssign,
		BitAndAssign,
		BitOrAssign,
		BitXorAssign,
		Dot,
		Arrow,
		Question,
		Coalesce,
		Range,
		HalfOpenRange,
		CountRange,
		Is,
		As,
		SafeAs,
	}

	public static class GenericOperatorExtensions {
		public static string GetTextualRepresentation(this OperatorName op){
			switch (op) {
				case OperatorName.BitNot:
					return "~";
				case OperatorName.BitAnd:
					return "&";
				case OperatorName.BitOr:
					return "|";
				case OperatorName.BitXor:
					return "^";
				case OperatorName.Add:
					return "+";
				case OperatorName.Sub:
					return "-";
				case OperatorName.Mult:
					return "*";
				case OperatorName.Div:
					return "/";
				case OperatorName.Rem:
					return "%";
				case OperatorName.Inc:
					return "++";
				case OperatorName.Dec:
					return "--";
				case OperatorName.Eq:
					return "==";
				case OperatorName.NotEq:
					return "!=";
				case OperatorName.Gt:
					return ">";
				case OperatorName.Lt:
					return "<";
				case OperatorName.GtEq:
					return ">=";
				case OperatorName.LtEq:
					return "<=";
				case OperatorName.Not:
					return "!";
				case OperatorName.And:
					return "&&";
				case OperatorName.Or:
					return "||";
				case OperatorName.Shl:
					return "<<";
				case OperatorName.Shr:
					return ">>";
				case OperatorName.Assign:
					return "=";
				case OperatorName.AddAssign:
					return "+=";
				case OperatorName.SubAssign:
					return "-=";
				case OperatorName.MultAssign:
					return "*=";
				case OperatorName.DivAssign:
					return "/=";
				case OperatorName.RemAssign:
					return "%=";
				case OperatorName.ShlAssign:
					return "<<=";
				case OperatorName.ShrAssign:
					return ">>=";
				case OperatorName.BitAndAssign:
					return "&=";
				case OperatorName.BitOrAssign:
					return "|=";
				case OperatorName.BitXorAssign:
					return "^=";
				case OperatorName.Dot:
					return ".";
				case OperatorName.Arrow:
					return "->";
				case OperatorName.Question:
					return "?";
				case OperatorName.Coalesce:
					return "??";
				case OperatorName.Range:
					return "..";
				case OperatorName.HalfOpenRange:
					return "..<";
				case OperatorName.CountRange:
					return "...";
				case OperatorName.Is:
					return "is";
				case OperatorName.As:
					return "as";
				case OperatorName.SafeAs:
					return "as?";
				default:
					return null;
			}
		}
	}
}
