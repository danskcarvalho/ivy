using System;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: <A :: CPrintable<int>>
	public class ClassKindExpressionNode : KindExpressionNode {
		public ClassKindExpressionNode(SourceLocation location, TypeExpressionNode @class) : base(location)
		{
			Class = @class;
		}

		public TypeExpressionNode Class { get; private set; }
	}
}
