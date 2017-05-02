using System;
using System.Collections.Generic;
using ivyc.Basic;
namespace ivyc.AST {
    /// <summary>
    /// Ex.: module HelloWorld
    /// </summary>
	public class ModuleDeclarationNode : DeclarationNode {
	    public ModuleDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, ModuleName name) : base(location, accessibility, annotations)
	    {
		    Name = name;
	    }

	    public ModuleName Name { get; private set; }
	}
}
