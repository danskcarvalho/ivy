using System;
using System.Collections.Generic;
namespace ivyc.AST {
	/// <summary>
	/// The body of a declaration.
	/// </summary>
	public abstract class DeclarationBodyNode : Node {
		protected DeclarationBodyNode() {
		}
	}

	/// <summary>
	/// Default body for a declaration. 
    /// Ex.: def MyFunction() -> void = default
	/// </summary>
	public class DefaultDeclarationBodyNode : DeclarationBodyNode {
		private DefaultDeclarationBodyNode() {

		}
	}

	/// <summary>
	/// Mixin declaration body. Can be used on instance declarations.
    /// Not available in the prototype.
	/// </summary>
	//public class MixinDeclarationBodyNode : DeclarationBodyNode {
	//	private MixinDeclarationBodyNode() {
	//	}

	//	public ExpressionNode Expression { get; private set; }

	//	//Ex.: instance IASTNodePrintable<T> -> CPrintable<ASTNode<T>> = mixin(self.Name)
	//}

	public class DeclarationTypeArgumentNode : Node {
		private DeclarationTypeArgumentNode() {

		}

		public string Name { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}

	public class NewDeclarationBodyNode : DeclarationBodyNode {
		private NewDeclarationBodyNode() {

		}

		public IReadOnlyList<DeclarationTypeArgumentNode> Arguments { get; private set; }
		public TypeExpressionNode Target { get; private set; }
		//Ex.: type Printable = new<T, CPrintable<T>>(const T*)
	}

    /// <summary>
    /// Ex.: def Sum(A :: uint, B :: uint) -> uint => A + B
    /// </summary>
	public class ExpressionBodyNode : DeclarationBodyNode {
		private ExpressionBodyNode() {

		}

		public ExpressionNode Expression { get; private set; }
	}

    /// <summary>
    /// A type body for type declarations.
    /// Ex.: type SoundBit = bool
    /// </summary>
	public class TypeBodyNode : DeclarationBodyNode {
		private TypeBodyNode() {

		}

		public TypeExpressionNode Type { get; private set; }
	}

    /// <summary>
    /// Used in function declarations. Ex.:
    /// def SafeDiv(A :: uint, B :: uint) -> uint?:
    ///     if B != 0:
    ///         return A / B
    ///     else:
    ///         return null
    /// </summary>
	public class StatementListBodyNode : DeclarationBodyNode {
		private StatementListBodyNode() {

		}

		public IReadOnlyList<StatementNode> Statements { get; private set; }
	}

    /// <summary>
    /// Used for classes and extensions
    /// </summary>
	public class DeclarationListBodyNode : DeclarationBodyNode {
		private DeclarationListBodyNode() {

		}

		public IReadOnlyList<DeclarationNode> Declarations { get; private set; }
	}

	public class StructFieldDeclarationNode : Node {
		private StructFieldDeclarationNode(){
			
		}

		public string Name { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
        /// <summary>
        /// Ex.: let Path[256] :: char
        /// </summary>
		public IReadOnlyList<ExpressionNode> Indexes { get; private set; }
		public ExpressionNode DefaultValue { get; private set; }

		public DeclarationAccessibility Accessibility { get; private set; }
        //not in prototype
		//public IReadOnlyList<ExpressionNode> CustomAttributes { get; private set; }
		public IReadOnlyList<DeclarationAnnotationNode> Annotations { get; private set; }

		//Ex.: let Path[256] :: char
	}

	public class StructDeclarationBodyASTNode : DeclarationBodyNode {
		private StructDeclarationBodyASTNode(){
			
		}

		public IReadOnlyList<StructFieldDeclarationNode> Fields { get; private set; }
		public bool IsUnion { get; private set; }

		//Ex.: data Vec2 = { X :: float, Y :: float }
		//Ex.: data Uninitialized<T> = union { Value :: T }
	}

	public class NamedConstructorNode : Node {
		private NamedConstructorNode() {

		}

		public string Name { get; private set; }
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<TypeExpressionNode> Arguments { get; private set; }
		public ExpressionNode NumericValue { get; private set; } 
        /// <summary>
        /// Validation expression for the constructor
        /// </summary>
        public ExpressionNode WhereExpression { get; set; }

        //Not in prototype
		//public IReadOnlyList<ExpressionNode> CustomAttributes { get; private set; }
		public IReadOnlyList<DeclarationAnnotationNode> Annotations { get; private set; }

        //Ex.: data Gender = Male :: 0 | Female :: 1
        //Ex.: data CallingConvention = StdCall :: 0 | CCall :: 1
        //                              CustomCall(Index:: uint) :: 2
        //                                  where Index >= 2 throw EValidation("Index", "Index < 2")
	}

	public class EnumDeclarationBodyNode : DeclarationBodyNode {
		private EnumDeclarationBodyNode(){
			
		}

		public IReadOnlyList<NamedConstructorNode> Constructors { get; private set; }

		//Ex.: data Nullable<T> = Some(T) | None
	}
 }
