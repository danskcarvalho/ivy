using System;
namespace ivyc.AST {
	public enum TypeExpressionOperator {
		Annotation,		// ::  operator
		As,				// as  operator
		SafeAs			// as? operator
	}

	public class BinaryTypeExpressionNode : ExpressionNode {
		private BinaryTypeExpressionNode() {
		}

		public ExpressionNode Left {
			get;
			private set;
		}

		public TypeExpressionNode Type {
			get;
			private set;
		}

		public TypeExpressionOperator Operator {
			get;
			private set;
		}
	}
}
