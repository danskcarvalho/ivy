using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public enum NewBehavior {
		Throws,		//throw if fail to allocate		(new type)
		Fails,		//failure if cannot allocate	(new! type)
		Null,		//null if fail to allocate		(new? type)
		Stack		//allocate from stack... undefined behavior if fail to allocate (stacknew type)
	}
	public class NewExpressionNode : ExpressionNode {
		private NewExpressionNode() {
		}

		public NewBehavior Behavior { get; private set; }
		public bool IsConstNew { get; private set; }
		public bool IsVolatileNew { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public IReadOnlyList<ExpressionNode> InitArguments { get; private set; }
		public ExpressionNode ArraySizeArgument { get; private set; }
	}
}
