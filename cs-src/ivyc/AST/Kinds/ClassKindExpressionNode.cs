using System;
namespace ivyc.AST {
	public class ClassKindExpressionNode : KindExpressionNode {
		private ClassKindExpressionNode() {
		}

		public TypeExpressionNode Class { get; private set; }
	}
}
