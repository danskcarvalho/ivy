using System;
namespace ivyc.AST {
	public enum SimpleKindName {
		Star,
		Class
	}

	public class SimpleKindExpressionNode : KindExpressionNode {
		private SimpleKindExpressionNode() {
		}

		public SimpleKindName Name { get; private set; }
	}
}
