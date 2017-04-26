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
	/// Default body for a declaration. The default body depends on the declaration itself.
	/// </summary>
	public class DefaultDeclarationBodyNode : DeclarationBodyNode {
		private DefaultDeclarationBodyNode() {

		}
	}

	/// <summary>
	/// Mixin declaration body. Can be used on instance declarations.
	/// </summary>
	public class MixinDeclarationBodyNode : DeclarationBodyNode {
		private MixinDeclarationBodyNode() {
		}

		public ExpressionNode Expression { get; private set; }

		//Ex.: instance IASTNodePrintable<T> -> CPrintable<ASTNode<T>> = mixin(self.Name)
	}

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

	public class ExpressionBodyNode : DeclarationBodyNode {
		private ExpressionBodyNode() {

		}

		public ExpressionNode Expression { get; private set; }
	}

	public class TypeBodyNode : DeclarationBodyNode {
		private TypeBodyNode() {

		}

		public TypeExpressionNode Type { get; private set; }
	}

	public class StatementListBodyNode : DeclarationBodyNode {
		private StatementListBodyNode() {

		}

		public IReadOnlyList<StatementNode> Statements { get; private set; }
	}

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
		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public IReadOnlyList<ExpressionNode> Indexes { get; private set; }
		public ExpressionNode DefaultValue { get; private set; }

		public DeclarationAccessibility Accessibility { get; private set; }
		public IReadOnlyList<ExpressionNode> CustomAttributes { get; private set; }
		public IReadOnlyList<DeclarationAnnotationNode> Annotations { get; private set; }

		//Ex.: const Path[256] :: char
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

		public IReadOnlyList<ExpressionNode> CustomAttributes { get; private set; }
		public IReadOnlyList<DeclarationAnnotationNode> Annotations { get; private set; }

		//Ex.: Male: 0 | Female: 1
	}

	public class EnumDeclarationBodyNode : DeclarationBodyNode {
		private EnumDeclarationBodyNode(){
			
		}

		public IReadOnlyList<NamedConstructorNode> Constructors { get; private set; }

		//Ex.: data Nullable<T> = Some(T) | None
	}
 }
