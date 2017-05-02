using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class TypeNameExpressionNode : TypeExpressionNode {
		public TypeNameExpressionNode(SourceLocation location, string name) : base(location)
		{
			Name = name;
		}

		public string Name { get; private set; }
	}
}
