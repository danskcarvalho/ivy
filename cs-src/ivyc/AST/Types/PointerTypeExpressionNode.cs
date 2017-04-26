using System;
namespace ivyc.AST {
	public class PointerTypeExpressionNode : ExpressionNode {
		private PointerTypeExpressionNode() {
		}

		public TypeExpressionNode Pointee { get; private set; }
		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
	}
}
