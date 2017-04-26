using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class CompilationUnitNode : Node {
		private CompilationUnitNode() {
		}

		public IReadOnlyList<DeclarationNode> Declarations { get; private set; }
	}
}
