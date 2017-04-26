using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class PolyTypeExpressionNode : TypeExpressionNode {
		private PolyTypeExpressionNode() {
		}

		public TypeExpressionNode Constructor { get; private set; }
		public IReadOnlyList<TypeExpressionNode> Arguments { get; private set; }
	}
}
