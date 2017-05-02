using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class SpecializationDeclarationNode : DeclarationNode {
		public SpecializationDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, IEnumerable<TypeExpressionNode> specializations) : base(location, accessibility, annotations)
		{
			Specializations = specializations?.ToList().AsReadOnly();
		}

		public IReadOnlyList<TypeExpressionNode> Specializations { get; private set; }

		//Ex.: specialization Add<int, int> :: <a :: *, b :: *>(a, b) -> Sum<a, b>
	}
}
