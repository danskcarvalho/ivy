using System;
using System.Collections.Generic;
using System.Linq;
namespace ivyc.AST {
	/// <summary>
	/// The body of a declaration.
	/// </summary>
	public abstract class DeclarationBodyNode : Node {
		public DeclarationBodyNode(Basic.SourceLocation location) : base(location) {
		}
	}

	/// <summary>
	/// Default body for a declaration. 
    /// Ex.: def MyFunction() -> void = default
	/// </summary>
	public class DefaultDeclarationBodyNode : DeclarationBodyNode {
		public DefaultDeclarationBodyNode(Basic.SourceLocation location) : base(location) {
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
		public DeclarationTypeArgumentNode(Basic.SourceLocation location, string name, KindExpressionNode kind) : base(location) {
			Name = name;
			Kind = kind;
		}

		public string Name { get; private set; }
		public KindExpressionNode Kind { get; private set; }
	}

	public class NewDeclarationBodyNode : DeclarationBodyNode {
		public NewDeclarationBodyNode(Basic.SourceLocation location, IEnumerable<DeclarationTypeArgumentNode> arguments, TypeExpressionNode target) : base(location) {
			Arguments = arguments?.ToList().AsReadOnly();
			Target = target;
		}

		public IReadOnlyList<DeclarationTypeArgumentNode> Arguments { get; private set; }
		public TypeExpressionNode Target { get; private set; }
		//Ex.: type Printable = new<T, CPrintable<T>>(const T*)
	}

    /// <summary>
    /// Ex.: def Sum(A :: uint, B :: uint) -> uint => A + B
    /// </summary>
	public class ExpressionBodyNode : DeclarationBodyNode {
		public ExpressionBodyNode(Basic.SourceLocation location, ExpressionNode expression) : base(location) {
			Expression = expression;
		}

		public ExpressionNode Expression { get; private set; }
	}

    /// <summary>
    /// A type body for type declarations.
    /// Ex.: type SoundBit = bool
    /// </summary>
	public class TypeBodyNode : DeclarationBodyNode {
		public TypeBodyNode(Basic.SourceLocation location, TypeExpressionNode type) : base(location) {
			Type = type;
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
		public StatementListBodyNode(Basic.SourceLocation location, IEnumerable<StatementNode> statements) : base(location) {
			Statements = statements?.ToList().AsReadOnly();
		}

		public IReadOnlyList<StatementNode> Statements { get; private set; }
	}

    /// <summary>
    /// Used for classes and extensions
    /// </summary>
	public class DeclarationListBodyNode : DeclarationBodyNode {
		public DeclarationListBodyNode(Basic.SourceLocation location, IEnumerable<DeclarationNode> declarations) : base(location) {
			Declarations = declarations?.ToList().AsReadOnly();
		}

		public IReadOnlyList<DeclarationNode> Declarations { get; private set; }
	}

	public class StructFieldDeclarationNode : Node {
		public StructFieldDeclarationNode(Basic.SourceLocation location, string name, TypeExpressionNode type, bool isLet, bool isVolatile, RefKind @ref, IEnumerable<ExpressionNode> indexes, ExpressionNode defaultValue, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations) : base(location) {
			Name = name;
			Type = type;
			IsLet = isLet;
			IsVolatile = isVolatile;
			this.Ref = @ref;
			Indexes = indexes?.ToList().AsReadOnly();
			DefaultValue = defaultValue;
			Accessibility = accessibility;
			Annotations = annotations?.ToList().AsReadOnly();
		}

		public string Name { get; private set; }
		public TypeExpressionNode Type { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
        /// <summary>
        /// Ex.: let Path :: char[256]
        /// </summary>
		public IReadOnlyList<ExpressionNode> Indexes { get; private set; }
		public ExpressionNode DefaultValue { get; private set; }

		public DeclarationAccessibility Accessibility { get; private set; }
        //not in prototype
		//public IReadOnlyList<ExpressionNode> CustomAttributes { get; private set; }
		public IReadOnlyList<DeclarationAnnotationNode> Annotations { get; private set; }

		//Ex.: let Path :: char[256]
	}

	public class StructDeclarationBodyNode : DeclarationBodyNode {
		public StructDeclarationBodyNode(Basic.SourceLocation location, IEnumerable<StructFieldDeclarationNode> fields, bool isUnion) : base(location) {
			Fields = fields?.ToList().AsReadOnly();
			IsUnion = isUnion;
		}

		public IReadOnlyList<StructFieldDeclarationNode> Fields { get; private set; }
		public bool IsUnion { get; private set; }

		//Ex.: data Vec2 = { X :: float, Y :: float }
		//Ex.: data Uninitialized<T> = union { Value :: T }
	}

	public class NamedConstructorArgumentNode : Node {
		public NamedConstructorArgumentNode(Basic.SourceLocation location, TypeExpressionNode type, string name, bool isLet, bool isVolatile, RefKind @ref, IEnumerable<ExpressionNode> indexes, ExpressionNode defaultValue) : base(location) {
			Type = type;
			Name = name;
			IsLet = isLet;
			IsVolatile = isVolatile;
			this.Ref = @ref;
			Indexes = indexes?.ToList().AsReadOnly();
			DefaultValue = defaultValue;
		}

		public TypeExpressionNode Type { get; private set; }
		public string Name { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		//Ex.: TreeValue(char[256])
		public IReadOnlyList<ExpressionNode> Indexes { get; private set; }
		public ExpressionNode DefaultValue { get; private set; }
	}

	public class NamedConstructorNode : Node {
		public NamedConstructorNode(Basic.SourceLocation location, string name, IEnumerable<DeclarationTypeArgumentNode> typeArguments, IEnumerable<NamedConstructorArgumentNode> arguments, ExpressionNode numericValue, ExpressionNode whereExpression, IEnumerable<DeclarationAnnotationNode> annotations) : base(location) {
			Name = name;
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Arguments = arguments?.ToList().AsReadOnly();
			NumericValue = numericValue;
			WhereExpression = whereExpression;
			Annotations = annotations?.ToList().AsReadOnly();
		}

		public string Name { get; private set; }
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public IReadOnlyList<NamedConstructorArgumentNode> Arguments { get; private set; }
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
		public EnumDeclarationBodyNode(Basic.SourceLocation location, IEnumerable<NamedConstructorNode> constructors) : base(location) {
			Constructors = constructors?.ToList().AsReadOnly();
		}

		public IReadOnlyList<NamedConstructorNode> Constructors { get; private set; }

		//Ex.: data Nullable<T> = Some(T) | None
	}
 }
