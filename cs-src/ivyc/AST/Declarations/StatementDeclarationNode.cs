using System;
using System.Collections.Generic;
using ivyc.Basic;

namespace ivyc.AST {
	public class StatementDeclarationNode : DeclarationNode {
		public StatementDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, StatementNode statement) : base(location, accessibility, annotations)
		{
			Statement = statement;
		}

		public StatementNode Statement { get; private set; }
	}
}
