using System;
namespace ivyc.AST {
	public enum IntrinsicTypeFunction {
		SizeOf,
		TypeId
	}
	public class IntrinsicTypeFunctionExpressionNode : ExpressionNode {
		private IntrinsicTypeFunctionExpressionNode() {
		}

		public TypeExpressionNode Type { get; private set; }
		public IntrinsicTypeFunction Function { get; private set; }
	}
}
