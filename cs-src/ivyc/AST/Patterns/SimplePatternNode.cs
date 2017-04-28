using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class SimplePatternNode : PatternNode {
		private SimplePatternNode() {
		}

		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public string Name { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }

		//Ex.: let& b :: int
		//Ex.: b
		//Ex.: let& b
		//Ex.: &b [same as var& b]
	}
}
