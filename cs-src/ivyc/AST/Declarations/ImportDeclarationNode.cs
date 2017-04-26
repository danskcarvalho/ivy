using System;
using ivyc.Basic;
using System.Collections.Generic;
namespace ivyc.AST {
	public abstract class ImportDirectiveNode : Node {
		
	}
	public class ImportAllDirectiveNode : ImportDirectiveNode {
		
	}
	public class ImportNameDirectiveNode : ImportDirectiveNode {
		public Name Name { get; private set; }
	}
	public class ImportAliasedNameDirectiveNode : ImportDirectiveNode {
		public string Alias { get; private set; }
		public Name Aliased { get; private set; }
	}
	public class ImportNamespacedDirectiveNode : ImportDirectiveNode {
		public string Namespace { get; private set; }
	}
	public class ImportDeclarationNode : DeclarationNode {
		private ImportDeclarationNode() {
		}

		public ModuleName Imported { get; private set; }
		public IReadOnlyList<ImportDirectiveNode> Directives { get; private set; }

		//Ex.: import System.Collections(* => SysCol:*)
	}
}
