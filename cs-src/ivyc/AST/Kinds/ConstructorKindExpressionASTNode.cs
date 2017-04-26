using System;
using System.Collections.Generic;

namespace ivyc.AST {
	public class TypeConstructorArgumentNode : Node {
		private TypeConstructorArgumentNode(){
			
		}

		public string Name { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}
	public class TypeConstructorKindExpressionNode : KindExpressionNode {
		public TypeConstructorKindExpressionNode() {
		}

		public IReadOnlyList<TypeConstructorArgumentNode> Arguments { get; private set; }
		public KindExpressionNode Result { get; private set; }
	}
}
