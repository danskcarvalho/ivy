using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum AssertStatementKind {
		Regular,	//assert?
		Enforce,	//assert
	}
	public enum AssertFailedResult {
		Fail,
		//not supported
		//Throw,
		Return,
		//YieldBreak,
		//Yield,
		Continue,
		Break,
		Goto,
		ExecuteBlock
	}
	public class AssertStatementNode : StatementNode {
		public AssertStatementNode(SourceLocation location, ExpressionNode condition, AssertFailedResult failedResult, ExpressionNode resultExpression, string resultLabel, IEnumerable<StatementNode> resultBlock) : base(location)
		{
			Condition = condition;
			FailedResult = failedResult;
			ResultExpression = resultExpression;
			ResultLabel = resultLabel;
			ResultBlock = resultBlock?.ToList().AsReadOnly();
		}

		public ExpressionNode Condition { get; private set; }
		public AssertFailedResult FailedResult { get; private set; }
		public ExpressionNode ResultExpression { get; private set; }
		public string ResultLabel { get; private set; }
		public IReadOnlyList<StatementNode> ResultBlock { get; private set; }
	}
}
