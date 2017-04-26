using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class InstanceDeclarationNode : DeclarationNode {
		private InstanceDeclarationNode() {
		}

		public string Name { get; private set; }
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public TypeExpressionNode Class { get; private set; }
		public DeclarationBodyNode Body { get; private set; }
	}
}
