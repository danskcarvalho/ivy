using System;
using System.Collections.Generic;
using ivyc.Basic;

namespace ivyc.AST {
	public class SimplePatternNode : PatternNode {
		public SimplePatternNode(SourceLocation location, bool isLet, bool isVolatile, RefKind @ref, string name, TypeExpressionNode typeAnnotation) : base(location)
		{
			IsLet = isLet;
			IsVolatile = isVolatile;
			Ref = @ref;
			Name = name;
			TypeAnnotation = typeAnnotation;
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
