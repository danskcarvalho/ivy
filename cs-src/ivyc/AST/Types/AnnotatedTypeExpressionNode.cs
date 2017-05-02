using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class AnnotatedTypeExpressionNode : TypeExpressionNode {
		public AnnotatedTypeExpressionNode(SourceLocation location, TypeExpressionNode annotated, KindExpressionNode kind) : base(location)
		{
			Annotated = annotated;
			Kind = kind;
		}

		public TypeExpressionNode Annotated { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}
}
