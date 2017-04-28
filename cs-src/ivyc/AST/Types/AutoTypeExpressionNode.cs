using System;
namespace ivyc.AST {
	//Ex.: auto<CPrintable<int>>
	public class AutoTypeExpressionNode : TypeExpressionNode {
		public AutoTypeExpressionNode() {
		}

		public TypeExpressionNode Class { get; private set; }
	}
}
