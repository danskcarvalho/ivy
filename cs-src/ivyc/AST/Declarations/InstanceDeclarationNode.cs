using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class InstanceDeclarationNode : DeclarationNode {
		public InstanceDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, string name, IEnumerable<DeclarationTypeArgumentNode> typeArguments, TypeExpressionNode @class, DeclarationBodyNode body) : base(location, accessibility, annotations)
		{
			Name = name;
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Class = @class;
			Body = body;
		}

		public string Name { get; private set; }
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public TypeExpressionNode Class { get; private set; }
		public DeclarationBodyNode Body { get; private set; }
	}
}
