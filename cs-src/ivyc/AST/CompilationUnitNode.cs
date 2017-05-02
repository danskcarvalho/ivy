using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class CompilationUnitNode : Node {
		public CompilationUnitNode(SourceLocation location, IEnumerable<DeclarationNode> declarations) : base(location)
		{
			Declarations = declarations?.ToList().AsReadOnly();
		}

		public IReadOnlyList<DeclarationNode> Declarations { get; private set; }
	}
}
