using System;
namespace ivyc.AST {
	public enum BinaryOperator {
		Dot,
		Arrow,
		Mult,
		Div,
		Rem,
		Add,
		Sub,
		Shl,
		Shr,
		BitAnd,
		BitOr,
		BitXor,
		Range,
		HalfOpenRange,
		CountRange,
		Eq,
		NotEq,
		Gt,
		Lt,
		GtEq,
		LtEq,
		And,
		Or,
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
		Coalesce,
		RoundCall,		//left (right)
		SquareCall,		//left [right]
	}

	public class BinaryExpressionNode : ExpressionNode {
		private BinaryExpressionNode() {
		}

		public ExpressionNode Left { get; private set; }
		public ExpressionNode Right { get; private set; }

		public BinaryOperator Operator { get; private set; }
	}
}
