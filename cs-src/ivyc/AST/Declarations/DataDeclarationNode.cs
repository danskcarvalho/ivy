﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace ivyc.AST {
	/// <summary>
	/// A data declaration can be used to declare a struct, a union or a enumeration.
	/// 
	/// Ex.: data Person = { Name :: const char*, Age :: uint, Sex :: Gender }
	/// Ex.: data Vector = union { VectorF :: { X :: float, Y :: float }, VectorI :: { X :: Int32, Y :: Int32 }}
	/// Ex.: data Gender = M | F
	/// </summary>
	public class DataDeclarationNode : DeclarationNode {
		public DataDeclarationNode(Basic.SourceLocation location, 
		                           DeclarationAccessibility accessibility, 
		                           IEnumerable<DeclarationAnnotationNode> annotations, 
		                           string name, IEnumerable<DeclarationTypeArgumentNode> typeArguments, 
		                           DeclarationBodyNode body) : base(location, accessibility, annotations) {
			Name = name;
			TypeArguments = typeArguments?.ToList().AsReadOnly();
			Body = body;
		}
		/// <summary>
		/// The name of this declaration. The convention is to use UpperCammelCase.
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// Type arguments for this data declaration.
		/// </summary>
		public IReadOnlyList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		/// <summary>
		/// The body of this type declaration.
		/// </summary>
		/// <value>The body.</value>
		public DeclarationBodyNode Body { get; private set; }
	}
}
