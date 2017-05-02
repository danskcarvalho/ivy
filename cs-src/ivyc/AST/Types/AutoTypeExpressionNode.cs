using System;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: auto<CPrintable<int>>
	public class AutoTypeExpressionNode : TypeExpressionNode {
		public AutoTypeExpressionNode(SourceLocation location, TypeExpressionNode @class) : base(location)
		{
			Class = @class;
		}

		public TypeExpressionNode Class { get; private set; }
	}
}
