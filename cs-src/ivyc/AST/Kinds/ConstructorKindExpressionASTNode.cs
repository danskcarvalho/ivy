using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class TypeConstructorArgumentNode : Node {
		public TypeConstructorArgumentNode(SourceLocation location, string name, KindExpressionNode kind) : base(location)
		{
			Name = name;
			Kind = kind;
		}

		public string Name { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}
	public class TypeConstructorKindExpressionNode : KindExpressionNode {
		public TypeConstructorKindExpressionNode(SourceLocation location, IEnumerable<TypeConstructorArgumentNode> arguments, KindExpressionNode result) : base(location)
		{
			Arguments = arguments?.ToList().AsReadOnly();
			Result = result;
		}

		public IReadOnlyList<TypeConstructorArgumentNode> Arguments { get; private set; }
		public KindExpressionNode Result { get; private set; }
	}
}
