using System;
namespace ivyc.AST {
	//Ex.: [int] is a list of ints
	public class ListTypeExpressionNode : TypeExpressionNode {
		public ListTypeExpressionNode() {
		}

		public TypeExpressionNode Element { get; private set; }
	}
}
