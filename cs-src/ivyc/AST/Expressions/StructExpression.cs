using System;
using System.Collections.Generic;
using ivyc.Basic;

namespace ivyc.AST {
	public class StructExpressionElementNode : Node {
		public StructExpressionElementNode(SourceLocation location, string name, ExpressionNode value) : base(location)
		{
			Name = name;
			Value = value;
		}

		public string Name { get; private set; }
		public ExpressionNode Value { get; private set; }
	}
	public class StructExpressionNode : ExpressionNode {
		public StructExpressionNode(SourceLocation location, IReadOnlyList<StructExpressionElementNode> elements) : base(location)
		{
			Elements = elements;
		}

		public IReadOnlyList<StructExpressionElementNode> Elements { get; private set; }
	}
}
