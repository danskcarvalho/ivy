using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class LabelStatementNode : StatementNode {
		public LabelStatementNode() {
		}

		public string Name { get; private set; }
		public IReadOnlyList<StatementNode> Block { get; private set; }
	}
}
