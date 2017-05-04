using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum RefKind {
		Value = 0,
		Ref = 1,
		MoveRef = 2
	}
	public enum CallingConvention {
		Default = 0,
		IvyCall,
		CCall
	}

	public class FunctionArgumentNode : Node {
		public FunctionArgumentNode(SourceLocation location, TypeExpressionNode argument, bool isLet, bool isVolatile, RefKind @ref) : base(location)
		{
			Argument = argument;
			IsLet = isLet;
			IsVolatile = isVolatile;
			Ref = @ref;
		}

		public TypeExpressionNode Argument { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
	}

	public class FunctionTypeArgumentNode : Node {
		public FunctionTypeArgumentNode(SourceLocation location, string name, KindExpressionNode kind) : base(location)
		{
			Name = name;
			Kind = kind;
		}

		public string Name { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}

	public class FunctionTypeExpressionNode : TypeExpressionNode {
		public FunctionTypeExpressionNode(SourceLocation location, CallingConvention callingConvention, IEnumerable<FunctionTypeArgumentNode> typeArguments, IEnumerable<FunctionArgumentNode> arguments, FunctionArgumentNode result) : base(location)
		{
			CallingConvention = callingConvention;
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Arguments = arguments?.ToList().AsReadOnly();
			Result = result;
		}

		public CallingConvention CallingConvention { get; private set; }
		//Not supported in prototype
		//public bool IsDelegate { get; private set; }
		//Not supported in prototype
		//public bool Throws { get; private set; }
		public IReadOnlyList<FunctionTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<FunctionArgumentNode> Arguments { get; private set; }
		public FunctionArgumentNode Result { get; private set; }
	}
}
