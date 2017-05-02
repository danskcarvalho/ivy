using System;
using ivyc.Basic;

namespace ivyc.AST {
	public enum IntrinsicTypeFunction {
		SizeOf,
		TypeId
	}
	public class IntrinsicTypeFunctionExpressionNode : ExpressionNode {
		public IntrinsicTypeFunctionExpressionNode(SourceLocation location, TypeExpressionNode type, IntrinsicTypeFunction function) : base(location)
		{
			Type = type;
			Function = function;
		}

		public TypeExpressionNode Type { get; private set; }
		public IntrinsicTypeFunction Function { get; private set; }
	}
}
