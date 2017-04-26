using System;
using ivyc.Basic;
namespace ivyc.AST {
	public class ModuleDeclarationNode : DeclarationNode {
		private ModuleDeclarationNode() {
		}

		public ModuleName Name { get; private set; }
	}
}
