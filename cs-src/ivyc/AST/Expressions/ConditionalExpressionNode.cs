using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class ConditionalExpressionNode : ExpressionNode {
		public ConditionalExpressionNode(SourceLocation location, ExpressionNode condition, ExpressionNode trueExpression, ExpressionNode falseExpression) : base(location)
		{
			Condition = condition;
			TrueExpression = trueExpression;
			FalseExpression = falseExpression;
		}

		public ExpressionNode Condition { get; private set; }
		public ExpressionNode TrueExpression { get; private set; }
		public ExpressionNode FalseExpression { get; private set; }
	}
}
