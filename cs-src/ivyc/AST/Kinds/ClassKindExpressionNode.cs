using System;
namespace ivyc.AST {
	//Ex.: <A :: CPrintable<int>>
	public class ClassKindExpressionNode : KindExpressionNode {
		private ClassKindExpressionNode() {
		}

		public TypeExpressionNode Class { get; private set; }
	}
}
