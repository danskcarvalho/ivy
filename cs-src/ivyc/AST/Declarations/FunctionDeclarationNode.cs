using System;
using System.Collections.Generic;
using ivyc.Basic;
namespace ivyc.AST {

	public class FunctionDeclarationArgumentNode : Node {
		private FunctionDeclarationArgumentNode() {

		}

		public string Name { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public ExpressionNode DefaultValue { get; set; }
	}
	public class FunctionDeclarationWhereClauseNode : Node {
		private FunctionDeclarationWhereClauseNode(){
			
		}

		public string FieldName { get; private set; }
		public ExpressionNode Initialization { get; private set; }
	}

	public class FunctionDeclarationNode : DeclarationNode {
		private FunctionDeclarationNode() {
		}

		public Name Name { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
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
        //Ex.: volatile SomeFunction()
	}
}
