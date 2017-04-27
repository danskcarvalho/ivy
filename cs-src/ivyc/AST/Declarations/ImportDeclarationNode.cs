using System;
using ivyc.Basic;
using System.Collections.Generic;
namespace ivyc.AST {
	public abstract class ImportDirectiveNode : Node {
		
	}
    /// <summary>
    /// Ex.: *
    /// </summary>
	public class ImportAllDirectiveNode : ImportDirectiveNode {
		
	}
    /// <summary>
    /// Ex.: Name
    /// </summary>
	public class ImportNameDirectiveNode : ImportDirectiveNode {
		public Name Name { get; private set; }
	}
    /// <summary>
    /// Ex.: SomeName => AnotherName
    /// </summary>
	public class ImportAliasedNameDirectiveNode : ImportDirectiveNode {
		public string Alias { get; private set; }
		public Name Aliased { get; private set; }
	}
    /// <summary>
    /// Ex.: * => Sys:*
    /// </summary>
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
