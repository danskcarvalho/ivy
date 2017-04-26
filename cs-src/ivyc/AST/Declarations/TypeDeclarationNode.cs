using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class TypeDeclarationNode : DeclarationNode {
		private TypeDeclarationNode() {
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
