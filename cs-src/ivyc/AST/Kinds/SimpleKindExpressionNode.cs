using System;
using ivyc.Basic;

namespace ivyc.AST {
	public enum SimpleKindName {
		Star,
		Class
	}

	public class SimpleKindExpressionNode : KindExpressionNode {
		public SimpleKindExpressionNode(SourceLocation location, SimpleKindName name) : base(location)
		{
			Name = name;
		}

		public SimpleKindName Name { get; private set; }
	}
}
