using System;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: [string: int] map of string to int
	public class MapTypeExpressionNode : TypeExpressionNode {
		public MapTypeExpressionNode(SourceLocation location, TypeExpressionNode key, TypeExpressionNode value) : base(location)
		{
			Key = key;
			Value = value;
		}

		public TypeExpressionNode Key { get; private set; }
		public TypeExpressionNode Value { get; private set; }
	}
}
