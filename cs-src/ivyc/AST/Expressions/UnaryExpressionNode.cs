using System;
namespace ivyc.AST {
	public enum UnaryOperator {
		Ref,	//&
		Def,	//*
		Plus,
		Minus,
		Not,
		BitNot,
		PreInc,
		PreDec,
		PostInc,
		PostDec,
		Await,
		NullPropagation
	}

	public class UnaryExpressionNode : ExpressionNode {
		private UnaryExpressionNode() {
		}

		public ExpressionNode Inner { get; private set; }
		public UnaryOperator Operator { get; private set; }
	}
}
