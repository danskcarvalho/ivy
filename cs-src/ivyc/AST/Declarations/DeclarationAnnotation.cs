using System;
using System.Collections.Generic;
namespace ivyc.AST {
	/// <summary>
	/// Declaration annotation.
	/// </summary>
	public enum DeclarationAnnotationName {
		/// <summary>
		/// Can be applied to data declarations. It means the structure wont have padding.
		/// </summary>
		Packed,
		/// <summary>
		/// Can be applied to data declarations or fields. It has one required parameter which is
		/// a number that must be a power of 2 or number 1. For this to have any effect, this number must be bigger
		/// than the natural alignment of the data or field youre applying this to.
		/// 
		/// Ex.: aligned(8) //8 bytes alignment
		/// </summary>
		Aligned,
		/// <summary>
		/// The default tuple type. Everytime the compiler finds something like (int, double). It will convert to
		/// Tuple<int, double> where Tuple is the name of the polymorphic type this annotation was applied to.
		/// This annotation can only be applied to polymorphic data with 2 type parameters.
		/// </summary>
		TupleType,
		/// <summary>
		/// The default list type. Everytime the compiler finds something like [0, 1, 2, 3]. It will try to infer
		/// this type. Must be applied to a polymorphic data declaration with one type parameter.
		/// </summary>
		ListType,
		/// <summary>
		/// The default map type. Everytime the compiler finds something like [0: "0", 1: "1"]. The compiler will try to
		/// infer this type. Must be applied to a polymorphic data declaration with 2 type parameters.
		/// </summary>
		MapType,
		/// <summary>
		/// The default set type. Everytime the compiler finds something like {0, 1, 2, 3}. It will try to infer
		/// this type. Must be applied to a polymorphic data declaration with one type parameter.
		/// </summary>
		SetType,
		/// <summary>
		/// The default UTF-8 string type.
		/// </summary>
		UTF8StringType,
		/// <summary>
		/// The default UTF-16 string type.
		/// </summary>
		UTF16StringType,
		/// <summary>
		/// The default UTF-32 string type.
		/// </summary>
		UTF32StringType,
		/// <summary>
		/// Applied to a data declaration that is a enum. All the named constructor of this enum must be parameterless.
		/// Makes the compiler generate | and & operator functions for this enum. The operator & returns a boolean.
		/// It changes the way Ivy sets the numeric values of each named constructor. This annotation implies the numeric
		/// annotation. 
		/// </summary>
		Flags,
		/// <summary>
		/// Applied to a data declaration that is a enum. Each named constructor of this enum will become a type.
		/// This annotation must be applied if the enum has polymorphic named constructors. If applied, it becomes impossible
		/// to define a default constructor to this enum.
		/// </summary>
		Abstract,
		/// <summary>
		/// Applied to a data declaration that is a enum. Generates conversion functions from and to the backing type of this enum.
		/// All the named constructors must be parameterless.
		/// </summary>
		Numeric,
		/// <summary>
		/// Applied to a class declaration. This class can only implemented (instatiated) by the declaring module.
		/// </summary>
		Closed,
		/// <summary>
		/// The compiler automatically creates a instance of CEquatable for this type.
		/// </summary>
		Equatable,
		/// <summary>
		/// The compiler automatically creates a instance of CComparable for this type. Implies Equatable.
		/// </summary>
		Comparable,
		/// <summary>
		/// The compiler automatically creates a instance of CHashable for this type. Comparable implies Equatable.
		/// </summary>
		Hashable,
		/// <summary>
		/// The compiler automatically creates a instance of CBounded for this type. Can only be applied to enum data declarations with
		/// parameterless named constructors. Bounded implies Comparable.
		/// </summary>
		Bounded,
		/// <summary>
		/// The compiler automatically creates a instance of CInjective for this type. Can only be applied to enum data declarations
		/// with parameterless named constructors. Injective implies Bounded. 
		/// </summary>
		Injective,
		/// <summary>
		/// Implies Equatable, Comparable, Hashable, Copyable and Movable.
		/// </summary>
		ValueType,
		/// <summary>
		/// The data type can be copied with operator =. Implies Movable.
		/// </summary>
		Copyable,
		/// <summary>
		/// The data type can be moved with operator =.
		/// </summary>
		Movable,
		/// <summary>
		/// The data type has a default init function. If applied 
		/// </summary>
		DefaultInit,
		/// <summary>
		/// The default init function of this data type does nothing. The compiler generates a default init.
		/// </summary>
		TrivialInit,
		/// <summary>
		/// The deinit of this data type does nothing.
		/// </summary>
		TrivialDeinit,
		/// <summary>
		/// Applied to global vars. Each thread has a copy of this variable. The type of the variable must have a trivial init
		/// and trivial deinit. Not in this prototype.
		/// </summary>
		//ThreadLocal,
		/// <summary>
		/// Either the function can be accessed externally by C/C++ code or the function is provided externally by C/C++ code.
		/// It can have a name passed as an argument to this annotation.
		/// </summary>
		Extern,
		/// <summary>
		/// Applied to a init function. This function is only used if a type annotation is present in the expression.
		/// </summary>
		Explicit,
		/// <summary>
		/// Applied to a field of a struct. Changes the way field mutators/accessors are generated. It means a field of a const
		/// struct can still be mutated.
		/// </summary>
		Mutable,
		/// <summary>
		/// Applied to a field of a struct. Changes the way field mutators/accessors are generated. It means a field of a volatile
		/// struct can still be accessed as non volatile data.
		/// </summary>
		Definite,
		/// <summary>
		/// Applied to functions. The last parameter of this function must be of FunctionTail<...>. The function can then be called
		/// as if it had an infinite number of arguments.
		/// </summary>
		Variadic,
		/// <summary>
		/// Applied to functions.
		/// </summary>
		Inline,
		/// <summary>
		/// Applied to functions.
		/// </summary>
		AlwaysInline,
		/// <summary>
		/// Can be applied to anything. Generates a warning telling this is obsolete. Can provide a custom warning text.
        /// Not available on the prototype.
		/// </summary>
		//Obsolete,
		/// <summary>
		/// Generates a warning with the provided text. Not available on the prototype.
		/// </summary>
		//Warning,
		/// <summary>
		/// Applied to a named constructor. Ivy generates a init parameterless function that calls this named constructor.
		/// </summary>
		Default,
		/// <summary>
		/// Can be applied to functions. Has one required string parameter. If a compiler directive with the same name of
		/// the string provided is defined, then all function calls are removed from their call sites. The return of this
		/// function must be a void. The string can also be a preprocessor expression.
		/// 
		/// Ex.:
		/// [excludeif("!DEBUG")]
		/// def DebugMessage(msg :: StringView) = default
        /// Not available in the prototype.
		/// </summary>
		//ExcludeIf,
		/// <summary>
		/// Generates a CWritable instance for the data declaration this annotation is applied to.
		/// </summary>
		Writable,
		/// <summary>
		/// Generates a CReadable instance for the data declaration this annotation is applied to.
		/// </summary>
		Readable,
		/// <summary>
		/// The backing type of a enum. If not provided, the compiler selects the best backing type.
		/// </summary>
		BackingType,
		/// <summary>
		/// The default null type. So Type? is converted to NullType<Type>.
		/// </summary>
		NullType,
		/// <summary>
		/// Applied to a global let of type const void*. Has one required parameter. It embbeds the path of the file passed
		/// into this module. The global var points to the contents of this file.
		/// </summary>
		Resource
	}

	/// <summary>
	/// Argument of an annotation. Can be a expression or a type.
	/// </summary>
	public class DeclarationAnnotationParameterNode : Node {
		public DeclarationAnnotationParameterNode(Basic.SourceLocation location, ExpressionNode expression, TypeExpressionNode type) : base(location) {
			Expression = expression;
			Type = type;
		}
		public ExpressionNode Expression { get; private set; }
		public TypeExpressionNode Type { get; private set; }
	}

	/// <summary>
	/// Declaration Annotation
	/// </summary>
	public class DeclarationAnnotationNode : Node {
		public DeclarationAnnotationNode(Basic.SourceLocation location, DeclarationAnnotationName name, IReadOnlyList<DeclarationAnnotationParameterNode> arguments) : base(location) {
			Name = name;
			Arguments = arguments;
		}

		/// <summary>
		/// Name of this annotation.
		/// </summary>
		public DeclarationAnnotationName Name { get; private set; }
        // Ex.: data(!valuetype) Nullable<T> = Some(T) | None
        public bool IsNegated { get; set; }
		/// <summary>
		/// Arguments of this annotation.
		/// </summary>
		public IReadOnlyList<DeclarationAnnotationParameterNode> Arguments { get; private set; }
	}
}
