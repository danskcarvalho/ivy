using System;
using System.Collections.Generic;
namespace ivyc.AST {

	public class TupleElementNode : Node {
		private TupleElementNode(){
			
		}

		public ExpressionNode Left { get; private set; }
		public ExpressionNode Right { get; private set; }
	}

	public enum TupleKind {
		Round,
		Square,
		Curly
	}

	public class TupleExpressionNode : ExpressionNode {
		private TupleExpressionNode() {
		}

		public IReadOnlyList<TupleElementNode> Elements { get; private set; }
		public TupleKind Kind { get; private set; }
	}
}
