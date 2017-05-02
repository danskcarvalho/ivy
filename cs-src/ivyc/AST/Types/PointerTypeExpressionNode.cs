using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class PointerTypeExpressionNode : ExpressionNode {
		public PointerTypeExpressionNode(SourceLocation location, TypeExpressionNode pointee, bool isConst, bool isVolatile) : base(location)
		{
			Pointee = pointee;
			IsConst = isConst;
			IsVolatile = isVolatile;
		}

		public TypeExpressionNode Pointee { get; private set; }
		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
	}
}
