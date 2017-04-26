using System;
namespace ivyc.AST {
	public class DotTypeExpressionNode {
		protected DotTypeExpressionNode() {
		}

		public TypeExpressionNode Left { get; private set; }
		public TypeExpressionNode Right { get; private set; }

		public DotTypeExpressionNode Create(TypeExpressionNode left, TypeExpressionNode right){
			if (left == null)
				throw new ArgumentNullException(nameof(left));
			if (right == null)
				throw new ArgumentNullException(nameof(right));

			return new DotTypeExpressionNode() {
				Left = left,
				Right = right
			};
		}
	}
}
