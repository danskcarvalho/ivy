using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public enum AssertStatementKind {
		Regular,
		Enforce,
	}
	public enum AssertFailedResult {
		Fail,
		Throw,
		Return,
		YieldBreak,
		Yield,
		Continue,
		Break,
		Goto,
		ExecuteBlock
	}
	public class AssertStatementNode : StatementNode {
		private AssertStatementNode() {
		}

		public ExpressionNode Condition { get; private set; }
		public AssertFailedResult FailedResult { get; private set; }
		public ExpressionNode ResultExpression { get; private set; }
		public string ResultLabel { get; private set; }
		public IReadOnlyList<StatementNode> ResultBlock { get; private set; }
	}
}
