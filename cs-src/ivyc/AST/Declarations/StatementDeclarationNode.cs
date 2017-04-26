using System;
namespace ivyc.AST {
	public class StatementDeclarationNode : DeclarationNode {
		private StatementDeclarationNode() {
		}

		public StatementNode Statement { get; private set; }
	}
}
