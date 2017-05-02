using System;
using System.Collections.Generic;
using System.Linq;
namespace ivyc.AST {
	/// <summary>
	/// A class declaration. A class defines a subset of types supporting a few common opertations.
	/// A class may define functions, functions with a default implementation, variables, type 
	/// declarations, inits, new and delete functions. A class cannot define a deinit function because
	/// all types are assumed to have a deinit function and it can always be called.
	/// 
	/// Ex.: class CCopyable<T> :: CMovable<T> 
	/// </summary>
	public class ClassDeclarationNode : DeclarationNode {
		public ClassDeclarationNode(Basic.SourceLocation location, 
		                            DeclarationAccessibility accessibility, 
		                            IEnumerable<DeclarationAnnotationNode> annotations, 
		                            string name, 
		                            IEnumerable<DeclarationTypeArgumentNode> typeArguments, 
		                            IEnumerable<TypeExpressionNode> superClasses, 
		                            DeclarationBodyNode body) : base(location, accessibility, annotations) {
			Name = name;
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			SuperClasses = superClasses?.ToList().AsReadOnly();
			Body = body;
		}

		/// <summary>
		/// The name of this class. In Ivy, the convention is to name classes with a UpperCamelCase starting with
		/// a C. Ex.: CPrintable, CComparable, CHashable, CFunction, etc...
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }
		/// <summary>
		/// Type arguments of a class. A class is not required to have type arguments. Though, a class with no type
		/// arguments is kind of useless. If thats the case, this property is a zero-length list.
		/// </summary>
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		/// <summary>
		/// A class can inherit from zero, one or more classes. A class cannot inherit from itself directly or indirectly.
		/// </summary>
		public IReadOnlyList<TypeExpressionNode> SuperClasses { get; private set; }
		/// <summary>
		/// The body of a class. A class may define functions, functions with a default implementation, variables, type 
		/// declarations, inits, new and delete functions. A class cannot define a deinit function because
		/// all types are assumed to have a deinit function and it can always be called.
		/// </summary>
		public DeclarationBodyNode Body { get; private set; }
	}
}
