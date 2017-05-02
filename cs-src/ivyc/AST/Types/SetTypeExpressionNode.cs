using System;
using ivyc.Basic;

namespace ivyc.AST.Types {
	//Ex.: {int} set of ints
	public class SetTypeExpressionNode : TypeExpressionNode {
		public SetTypeExpressionNode(SourceLocation location, TypeExpressionNode element) : base(location)
		{
			Element = element;
		}

		public TypeExpressionNode Element { get; set; }
	}
}
