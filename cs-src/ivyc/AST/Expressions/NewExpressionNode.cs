using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum NewBehavior {
		//Throws,	//throw if fail to allocate		(new! type)
		Fails,		//failure if cannot allocate	(new  type)
		Null,		//null if fail to allocate		(new? type)
		Stack		//allocate from stack... undefined behavior if fail to allocate (stacknew type)
	}
	public class NewExpressionNode : ExpressionNode {
		public NewExpressionNode(SourceLocation location, NewBehavior behavior, bool isConstNew, bool isVolatileNew, TypeExpressionNode type, IEnumerable<ExpressionNode> initArguments, ExpressionNode arraySizeArgument) : base(location)
		{
			Behavior = behavior;
			IsConstNew = isConstNew;
			IsVolatileNew = isVolatileNew;
			Type = type;
			InitArguments = initArguments?.ToList().AsReadOnly();
			ArraySizeArgument = arraySizeArgument;
		}

		public NewBehavior Behavior { get; private set; }
		public bool IsConstNew { get; private set; }
		public bool IsVolatileNew { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public IReadOnlyList<ExpressionNode> InitArguments { get; private set; }
		public ExpressionNode ArraySizeArgument { get; private set; }
	}
}
