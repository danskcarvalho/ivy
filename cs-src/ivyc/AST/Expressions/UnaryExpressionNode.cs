using System;
using ivyc.Basic;

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
		//Not supported in prototype
		//Await,
		//NullPropagation
	}

	public class UnaryExpressionNode : ExpressionNode {
		public UnaryExpressionNode(SourceLocation location, ExpressionNode inner, UnaryOperator @operator) : base(location)
		{
			Inner = inner;
			Operator = @operator;
		}

		public ExpressionNode Inner { get; private set; }
		public UnaryOperator Operator { get; private set; }
	}
}
