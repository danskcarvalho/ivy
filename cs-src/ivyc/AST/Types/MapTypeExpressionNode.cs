using System;
namespace ivyc.AST {
	//Ex.: [string: int] map of string to int
	public class MapTypeExpressionNode : TypeExpressionNode {
		public MapTypeExpressionNode() {
		}

		public TypeExpressionNode Key { get; private set; }
		public TypeExpressionNode Value { get; private set; }
	}
}
