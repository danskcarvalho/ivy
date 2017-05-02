using System;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: [int] is a list of ints
	public class ListTypeExpressionNode : TypeExpressionNode {
		public ListTypeExpressionNode(SourceLocation location, TypeExpressionNode element) : base(location)
		{
			Element = element;
		}

		public TypeExpressionNode Element { get; private set; }
	}
}
