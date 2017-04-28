using System;
namespace ivyc.AST.Types {
	//Ex.: {int} set of ints
	public class SetTypeExpressionNode : TypeExpressionNode {
		public SetTypeExpressionNode() {
		}

		public TypeExpressionNode Element { get; set; }
	}
}
