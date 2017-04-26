using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public enum RefKind {
		Value = 0,
		Ref = 1,
		MoveRef = 2
	}

	public class FunctionArgumentNode : Node {
		private FunctionArgumentNode(){
			
		}

		public TypeExpressionNode Argument { get; private set; }
		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
	}

	public class FunctionTypeArgumentNode : Node {
		private FunctionTypeArgumentNode() {

		}

		public string Name { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}

	public class FunctionTypeExpressionASTNode : TypeExpressionNode {
		public FunctionTypeExpressionASTNode() {
		}

		public bool IsDelegate { get; private set; }
		public bool Throws { get; private set; }
		public IReadOnlyList<FunctionTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<FunctionArgumentNode> Arguments { get; private set; }
		public FunctionArgumentNode Result { get; private set; }
	}
}
