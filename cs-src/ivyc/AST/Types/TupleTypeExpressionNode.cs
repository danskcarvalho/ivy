using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class TupleTypeAgumentNode : Node {
		private TupleTypeAgumentNode(){
			
		}

		public TypeExpressionNode Type { get; private set; }
	}
	public class TupleTypeExpressionNode : TypeExpressionNode {
		private TupleTypeExpressionNode() {
		}

		public IReadOnlyList<TupleTypeAgumentNode> Arguments { get; private set; }
	}
}
