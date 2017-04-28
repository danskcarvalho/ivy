using System;
using System.Collections.Generic;
namespace ivyc.AST {
	//Ex.: for var I = 0, var J = 0 while I < Count && J < Count do I++, J++
	public class ForWhileStatementNode : StatementNode {
		private ForWhileStatementNode() {
		}

		public string LabelName { get; private set; }
		public IReadOnlyList<PatternNode> VarNames { get; private set; }
		public IReadOnlyList<ExpressionNode> Initializations { get; private set; }
		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<ExpressionNode> Next { get; private set; }
	}
}
