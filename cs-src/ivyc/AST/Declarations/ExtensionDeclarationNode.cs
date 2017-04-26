using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class ExtensionDeclarationNode : DeclarationBodyNode {
		private ExtensionDeclarationNode() {
		}

		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public TypeExpressionNode Target { get; private set; }
		public DeclarationBodyNode Body { get; private set; }
	}
}
