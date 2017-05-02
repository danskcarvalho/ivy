using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum DeferStatementKind {
		Regular,
		Delete,		//defer delete expr
		Fail,		//defer fail "should fail"
		//not supported on prototype
		//Throw,
		//Yield,
		//YieldBreak
	}
	public class DeferStatementNode : StatementNode {
		public DeferStatementNode(SourceLocation location, ExpressionNode expression, IEnumerable<StatementNode> body, DeferStatementKind kind) : base(location)
		{
			Expression = expression;
			Body = body?.ToList().AsReadOnly();
			Kind = kind;
		}

		public ExpressionNode Expression { get; private set; }
		public IReadOnlyList<StatementNode> Body { get; private set; }
		public DeferStatementKind Kind { get; private set; }
	}
}
