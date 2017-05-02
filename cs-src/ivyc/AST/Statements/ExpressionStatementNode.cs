using System;
using ivyc.Basic;

namespace ivyc.AST {
	public enum ExpressionStatementKind {
		Execute,
		Return,
		Fail,
		//not supported on prototype
		//Throw,
		//Yield,
		//YieldBreak,
		Delete
	}
	public class ExpressionStatementNode : StatementNode {
		public ExpressionStatementNode(SourceLocation location, ExpressionStatementKind kind, ExpressionNode expression) : base(location)
		{
			Kind = kind;
			Expression = expression;
		}

		public ExpressionStatementKind Kind { get; private set; }
		public ExpressionNode Expression { get; private set; }
	}
}
