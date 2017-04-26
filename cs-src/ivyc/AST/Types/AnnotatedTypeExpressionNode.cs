using System;
namespace ivyc.AST {
	public class AnnotatedTypeExpressionNode : TypeExpressionNode {
		private AnnotatedTypeExpressionNode() {
		}

		public TypeExpressionNode Annotated { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}
}
