using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class TryStatementNode : StatementNode {
		private TryStatementNode() {
		}

		public IReadOnlyList<StatementNode> TryBody { get; private set; }
		public IReadOnlyList<CaseStatementNode> CatchFilterBody { get; private set; }
		public IReadOnlyList<StatementNode> CatchStmtBody { get; private set; }
	}
}
