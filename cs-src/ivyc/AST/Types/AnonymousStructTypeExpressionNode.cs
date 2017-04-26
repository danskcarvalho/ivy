using System;
using System.Collections.Generic;

namespace ivyc.AST.Types {
	public class AnonymousStructTypeFieldNode : Node {
		private AnonymousStructTypeFieldNode() {

		}

		public string Name { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public IReadOnlyList<ExpressionNode> Indexes { get; private set; }

		//Ex.: const Path[256] :: char
	}

	public class AnonymousStructTypeExpressionNode : TypeExpressionNode {
		private AnonymousStructTypeExpressionNode() {
		}

		public IReadOnlyList<AnonymousStructTypeFieldNode> Arguments { get; private set; }
		public bool IsUnion { get; private set; }
	}
}
