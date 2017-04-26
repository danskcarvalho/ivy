using System;
namespace ivyc.AST {
	public class NullableTypeExpressionNode {
		private NullableTypeExpressionNode() {
		}

		public TypeExpressionNode Nullable { get; private set; }
	}
}
