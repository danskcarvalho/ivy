using System;
using ivyc.Basic;
using System.Collections.Generic;
using System.Linq;
namespace ivyc.AST {
	public abstract class ImportDirectiveNode : Node {
		public ImportDirectiveNode(SourceLocation location) : base(location) {
		}
	}
    /// <summary>
    /// Ex.: *
    /// </summary>
	public class ImportAllDirectiveNode : ImportDirectiveNode {
		public ImportAllDirectiveNode(SourceLocation location) : base(location) {
		}
	}
    /// <summary>
    /// Ex.: Name
    /// </summary>
	public class ImportNameDirectiveNode : ImportDirectiveNode {
		public ImportNameDirectiveNode(SourceLocation location, Name name) : base(location) {
			Name = name;
		}
		public Name Name { get; private set; }
	}
    /// <summary>
    /// Ex.: SomeName => AnotherName
    /// </summary>
	public class ImportAliasedNameDirectiveNode : ImportDirectiveNode {
		public ImportAliasedNameDirectiveNode(SourceLocation location, string alias, Name aliased) : base(location) {
			Alias = alias;
			Aliased = aliased;
		}
		public string Alias { get; private set; }
		public Name Aliased { get; private set; }
	}
    /// <summary>
    /// Ex.: * => Sys:*
    /// </summary>
	public class ImportNamespacedDirectiveNode : ImportDirectiveNode {
		public ImportNamespacedDirectiveNode(SourceLocation location, string @namespace) : base(location) {
			this.Namespace = @namespace;
		}
		public string Namespace { get; private set; }
	}
	public class ImportDeclarationNode : DeclarationNode {
		public ImportDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, ModuleName imported, IEnumerable<ImportDirectiveNode> directives) : base(location, accessibility, annotations) {
			Imported = imported;
			Directives = directives?.ToList().AsReadOnly();
		}

		public ModuleName Imported { get; private set; }
		public IReadOnlyList<ImportDirectiveNode> Directives { get; private set; }

		//Ex.: import System.Collections(* => SysCol:*)
	}
}
