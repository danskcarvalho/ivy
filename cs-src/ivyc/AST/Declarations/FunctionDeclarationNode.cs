using System;
using System.Collections.Generic;
using ivyc.Basic;
using System.Linq;
namespace ivyc.AST {

	public class FunctionDeclarationArgumentNode : Node {
		public FunctionDeclarationArgumentNode(SourceLocation location, string name, TypeExpressionNode type, bool isLet, bool isUnstable, RefKind @ref, ExpressionNode defaultValue) : base(location) {
			Name = name;
			Type = type;
			IsLet = isLet;
			IsUnstable = isUnstable;
			this.Ref = @ref;
			DefaultValue = defaultValue;
		}

		public string Name { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsUnstable { get; private set; }
		public RefKind Ref { get; private set; }
		public ExpressionNode DefaultValue { get; set; }
	}
	public class FunctionDeclarationWhereClauseNode : Node {
		public FunctionDeclarationWhereClauseNode(SourceLocation location, string fieldName, ExpressionNode initialization) : base(location) {
			FieldName = fieldName;
			Initialization = initialization;
		}

		public string FieldName { get; private set; }
		public ExpressionNode Initialization { get; private set; }
	}

	public class FunctionDeclarationNode : DeclarationNode {
		public FunctionDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, CallingConvention callingConvention, Name name, bool isLet, bool isUnstable, RefKind @ref, IEnumerable<DeclarationTypeArgumentNode> typeArguments, IEnumerable<FunctionDeclarationArgumentNode> arguments, FunctionTypeArgumentNode result, DeclarationBodyNode body, IEnumerable<FunctionDeclarationWhereClauseNode> whereClauses) : base(location, accessibility, annotations) {
			CallingConvention = callingConvention;
			Name = name;
			IsLet = isLet;
			IsUnstable = isUnstable;
			this.Ref = @ref;
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Arguments = arguments?.ToList().AsReadOnly();
			Result = result;
			Body = body;
			WhereClauses = whereClauses?.ToList().AsReadOnly();
		}

		public CallingConvention CallingConvention { get; private set; }
		public Name Name { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsUnstable { get; private set; }
		//not supported in prototype
		//Ex.: async def ReadFile() -> Task<List<String>>
		//public bool IsAsync { get; set; }
		public RefKind Ref { get; private set; }
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<FunctionDeclarationArgumentNode> Arguments { get; private set; }
        //Not supported in the prototype
		//public bool Throws { get; private set; }
		public FunctionTypeArgumentNode Result { get; private set; }
		public DeclarationBodyNode Body { get; private set; }
		public IReadOnlyList<FunctionDeclarationWhereClauseNode> WhereClauses { get; private set;}

		//Ex.: def Add(a :: int, b :: int) => a + b
		//Ex.: def Add<A, B, CNumber<A>, CNumber<B>>(a :: A, b :: B) -> CNumberResult<A, B>
        //Ex.: let Element(Index :: uint) => self.MData[Index]
        //Ex.: var Normalize() => self.X /= self.Length; self.Y /= self.Length
		//Ex.: def init() where vBuffer(null), vCount(0) = default
        //Ex.: unstable SomeFunction()
	}
}
