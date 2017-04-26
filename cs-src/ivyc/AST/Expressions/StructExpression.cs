using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class StructExpressionElementNode {
		private StructExpressionElementNode(){
			
		}
		public string Name { get; private set; }
		public ExpressionNode Value { get; private set; }
	}
	public class StructExpressionNode : ExpressionNode {
		private StructExpressionNode() {
		}

		public IReadOnlyList<StructExpressionElementNode> Elements { get; private set; }
	}
}
