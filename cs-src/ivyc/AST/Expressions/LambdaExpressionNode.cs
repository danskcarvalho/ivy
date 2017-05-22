using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum LambdaBodyKind {
		Expression,
		Statements
	}
	public class LambdaBodyNode : Node {
		public LambdaBodyNode(SourceLocation location, LambdaBodyKind bodyKind, ExpressionNode expressionBody, IEnumerable<StatementNode> statements) : base(location)
		{
			BodyKind = bodyKind;
			ExpressionBody = expressionBody;
			Statements = statements?.ToList().AsReadOnly();
		}

		public LambdaBodyKind BodyKind { get; private set;}
		public ExpressionNode ExpressionBody { get; private set; }
		public IReadOnlyList<StatementNode> Statements { get; private set; }
	}
	public enum LambdaCaptureKind {
		ByValue,
		ByRef
	}
	public class LambdaCapturedVarNode : Node {
		public LambdaCapturedVarNode(SourceLocation location, LambdaCaptureKind kind, string varName) : base(location)
		{
			Kind = kind;
			VarName = varName;
		}

		public LambdaCaptureKind Kind { get; private set; }
		public string VarName { get; private set; }
	}
	public class LambdaCapturesNode : Node {
		public LambdaCapturesNode(SourceLocation location, LambdaCaptureKind? allReferenced, IEnumerable<LambdaCapturedVarNode> capturedVars) : base(location)
		{
			AllReferenced = allReferenced;
			CapturedVars = capturedVars?.ToList().AsReadOnly();
		}

		public LambdaCaptureKind? AllReferenced { get; private set; }
		public IReadOnlyList<LambdaCapturedVarNode> CapturedVars { get; private set; }
	}
	public class LambdaArgumentNode : Node {
		public LambdaArgumentNode(SourceLocation location, string name, bool isLet, bool isUnstable, RefKind @ref, TypeExpressionNode type) : base(location)
		{
			Name = name;
			IsLet = isLet;
			IsUnstable = isUnstable;
			Ref = @ref;
			Type = type;
		}

		public string Name { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsUnstable { get; private set; }
		public RefKind Ref { get; private set; }
		public TypeExpressionNode Type { get; private set; }
	}
	public class LambdaResultNode : Node {
		public LambdaResultNode(SourceLocation location, bool isLet, bool isUnstable, RefKind @ref, TypeExpressionNode type) : base(location)
		{
			IsLet = isLet;
			IsUnstable = isUnstable;
			Ref = @ref;
			Type = type;
		}

		public bool IsLet { get; private set; }
		public bool IsUnstable { get; private set; }
		public RefKind Ref { get; private set; }
		public TypeExpressionNode Type { get; private set; }
	}
	public class LambdaExpressionNode : ExpressionNode {
		public LambdaExpressionNode(SourceLocation location, IEnumerable<FunctionTypeArgumentNode> typeArguments, IEnumerable<LambdaArgumentNode> arguments, LambdaResultNode result, string name, LambdaBodyNode body, LambdaCapturesNode captures) : base(location)
		{
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Arguments = arguments?.ToList().AsReadOnly();
			Result = result;
			Name = name;
			Body = body;
			Captures = captures;
		}

		public IReadOnlyList<FunctionTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<LambdaArgumentNode> Arguments { get; private set; }
		public LambdaResultNode Result { get; private set; }
		public string Name { get; private set; }
		public LambdaBodyNode Body { get; private set; }
		public LambdaCapturesNode Captures { get; private set; }
		//not supported in prototype
		//public bool IsAsync { get; set; }
		//not supported in prototype
		//public bool Throws { get; private set; }
	}
}
