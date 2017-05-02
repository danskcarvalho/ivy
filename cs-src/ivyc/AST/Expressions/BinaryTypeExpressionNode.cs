using System;
using ivyc.Basic;

namespace ivyc.AST {
	public enum TypeExpressionOperator {
		Annotation,		// ::  operator
		As,				// as  operator
		SafeAs			// as? operator
	}

	public class BinaryTypeExpressionNode : ExpressionNode {
		public BinaryTypeExpressionNode(SourceLocation location, ExpressionNode left, TypeExpressionNode type, TypeExpressionOperator @operator) : base(location)
		{
			Left = left;
			Type = type;
			Operator = @operator;
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
