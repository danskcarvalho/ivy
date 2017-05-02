using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {

	public class TupleElementNode : Node {
		public TupleElementNode(SourceLocation location, ExpressionNode left, ExpressionNode right) : base(location)
		{
			Left = left;
			Right = right;
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
		public TupleExpressionNode(SourceLocation location, IEnumerable<TupleElementNode> elements, TupleKind kind) : base(location)
		{
			Elements = elements?.ToList().AsReadOnly();
			Kind = kind;
		}

		public IReadOnlyList<TupleElementNode> Elements { get; private set; }
		public TupleKind Kind { get; private set; }
	}
}
