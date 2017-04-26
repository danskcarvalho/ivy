using System;
namespace ivyc.AST {
	public class ExpressionPatternNode : Node {
		private ExpressionPatternNode() {
		}

		public ExpressionNode Expression { get; private set; }
	}
}
