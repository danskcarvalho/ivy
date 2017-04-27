using System;
using ivyc.Basic;
namespace ivyc.AST {
    /// <summary>
    /// Ex.: module HelloWorld
    /// </summary>
	public class ModuleDeclarationNode : DeclarationNode {
		private ModuleDeclarationNode() {
		}

		public ModuleName Name { get; private set; }
	}
}
