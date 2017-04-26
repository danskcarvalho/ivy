using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class SpecializationDeclarationNode : DeclarationNode {
		private SpecializationDeclarationNode() {
		}

		public IReadOnlyList<TypeExpressionNode> Specializations { get; private set; }

		//Ex.: specialization Add<int, int> :: <a :: *, b :: *>(a, b) -> Sum<a, b>
	}
}
