using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public enum LambdaBodyKind {
		Expression,
		Statements
	}
	public class LambdaBodyNode : Node {
		private LambdaBodyNode(){
			
		}

		public LambdaBodyKind BodyKind { get; private set;}
		public ExpressionNode ExpressionBody { get; private set; }
		public IReadOnlyList<StatementNode> Statements { get; private set; }
	}
	public enum LambdaCaptures {
		ByValue,
		ByRef
	}
	public class LambdaCapturedVarNode : Node {
		private LambdaCapturedVarNode(){
			
		}

		public LambdaCaptures Captured { get; private set; }
		public string VarName { get; private set; }
	}
	public class LambdaCapturesNode : Node {
		private LambdaCapturesNode(){
			
		}
		public LambdaCaptures? AllReferenced { get; private set; }
		public IReadOnlyList<LambdaCapturedVarNode> CapturedVars { get; private set; }
	}
	public class LambdaArgumentNode : Node {
		private LambdaArgumentNode() {

		}

		public string Name { get; private set; }
		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public TypeExpressionNode Type { get; private set; }
	}
	public class LambdaResultNode : Node {
		private LambdaResultNode() {

		}

		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public TypeExpressionNode Type { get; private set; }
	}
	public class LambdaExpressionNode : ExpressionNode {
		public LambdaExpressionNode() {
		}

		public IReadOnlyList<FunctionTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<LambdaArgumentNode> Arguments { get; private set; }
		public LambdaResultNode Result { get; private set; }
		public string Name { get; private set; }
		public LambdaBodyNode Body { get; private set; }
		public LambdaCapturesNode Captures { get; private set; }
		public bool Throws { get; private set; }
	}
}
