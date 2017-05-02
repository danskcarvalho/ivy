using System;
using System.Collections.Generic;
using ivyc.Basic;

namespace ivyc.AST {
	public class TypeDeclarationNode : DeclarationNode {
		public TypeDeclarationNode(SourceLocation location, DeclarationAccessibility accessibility, IEnumerable<DeclarationAnnotationNode> annotations, string name, IList<DeclarationTypeArgumentNode> typeArguments, KindExpressionNode result, KindExpressionNode signature, DeclarationBodyNode body) : base(location, accessibility, annotations)
		{
			Name = name;
			TypeArguments = typeArguments;
			Result = result;
			Signature = signature;
			Body = body;
		}

		public string Name { get; private set; }
		public IList<DeclarationTypeArgumentNode> TypeArguments { get; private set; }
		public KindExpressionNode Result { get; private set; }
		public KindExpressionNode Signature { get; private set; }
		public DeclarationBodyNode Body { get; private set; }

		//Ex.: type Name = int
		//Ex.: type StringMap<Value> = Dictionary<String, Value>
		//Ex.: type StringMap<Value> -> * = Dictionary<String, Value>
		//Ex.: type DictionaryType :: <*, *> -> *
	}
}
