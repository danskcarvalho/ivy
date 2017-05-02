using System;
using System.Collections.Generic;
using ivyc.Basic;
using System.Linq;
namespace ivyc.AST {
	/// <summary>
	/// The accessibility of a declaration. Can be public, private, internal or have no accesibility at all.
	/// </summary>
	public enum DeclarationAccessibility {
		/// <summary>
		/// No accessibility keyword was provided. The default accesibility is public.
		/// </summary>
		Default,
		/// <summary>
		/// This declaration is acessibility to the declaring module and all modules that imports the declaring modules.
		/// </summary>
		Public,
		/// <summary>
		/// This declaration is accessible only to the declaring module. And its also invisible to importer modules. Meaning that
		/// those modules wont even know this declaration exists.
		/// </summary>
		Private,
		/// <summary>
		/// This declaration is accessible only to the declaring module. However its visible to importer modules. They just arent 
		/// allowed to directly make use of it. This is used to symbols that are supposed to be private but may be used inside
		/// inline functions. Also, this modifier is allowed on struct fields.
		/// </summary>
		Internal
	}

	public abstract class DeclarationNode : Node {
		protected DeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations) : base(location) {
			this.Accessibility = accessibility;
			this.Annotations = annotations?.ToList().AsReadOnly();
		}

		/// <summary>
		/// The accessibility of this declaration. Can be public, private, internal or have no accesibility at all.
		/// </summary>
		public DeclarationAccessibility Accessibility { get; private set; }
		/// <summary>
		/// Custom Attributes on this declaration. A custom attribute can be any expression. It's evaluated on the
		/// context of a global expression (ie. only has access to global variables). A custom attribute is compiled
		/// into a function. This function can be returned with reflection.
        /// Not available on the prototype.
		/// </summary>
		//public IReadOnlyList<ExpressionNode> CustomAttributes { get; private set; }
		/// <summary>
		/// Annotations on this declaration. Annotations are compiler defined attributes that change the way the compiler
		/// compiles the declaration. For instance, the packed annotation changes the alignment of data fields.
		/// </summary>
		public IReadOnlyList<DeclarationAnnotationNode> Annotations { get; private set; }
	}
}
