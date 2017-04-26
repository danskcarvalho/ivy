using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class ForStatementNode : StatementNode {
		private ForStatementNode() {
		}

		public IReadOnlyList<PatternNode> VarNames { get; private set; }
		public IReadOnlyList<ExpressionNode> Initializations { get; private set; }
		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<ExpressionNode> Next { get; private set; }
	}
}
