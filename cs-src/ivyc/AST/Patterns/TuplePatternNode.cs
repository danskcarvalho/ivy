using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class TupleElementPatternNode : Node {
		private TupleElementPatternNode(){
			
		}

		public PatternNode Left { get; private set; }
		public PatternNode Right { get; private set; }
	}
	public class TuplePatternNode : PatternNode {
		private TuplePatternNode() {
		}

		public TupleKind TupleKind { get; private set; }
		public string Name { get; private set; }
		public IReadOnlyList<TupleElementPatternNode> InnerPatterns { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }
		public PatternNode TailPattern { get; private set; }
		public TailPosition? TailPosition { get; private set; }

		//Ex.:
		//[a, b, ...c] where c is tail

	}
}
