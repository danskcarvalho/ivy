using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class WhileStatementNode : StatementNode {
		public WhileStatementNode(SourceLocation location, string labelName, ExpressionNode condition, IEnumerable<StatementNode> block) : base(location)
		{
			LabelName = labelName;
			Condition = condition;
			Block = block?.ToList().AsReadOnly();
		}

		public string LabelName { get; private set; }
		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<StatementNode> Block { get; private set; }
	}
}
