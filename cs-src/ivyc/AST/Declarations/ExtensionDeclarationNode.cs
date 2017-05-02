using System;
using System.Collections.Generic;
using System.Linq;
namespace ivyc.AST {
	public class ExtensionDeclarationNode : DeclarationBodyNode {
		public ExtensionDeclarationNode(Basic.SourceLocation location, IEnumerable<DeclarationTypeArgumentNode> typeArguments, TypeExpressionNode target, DeclarationBodyNode body) : base(location) {
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Target = target;
			Body = body;
		}

		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public TypeExpressionNode Target { get; private set; }
        public DeclarationBodyNode Body { get; private set; }
	}
}
