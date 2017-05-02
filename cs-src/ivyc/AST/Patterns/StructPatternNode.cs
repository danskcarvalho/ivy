using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class StructPatternElementNode : Node {
		public StructPatternElementNode(SourceLocation location, string name, PatternNode pattern) : base(location)
		{
			Name = name;
			Pattern = pattern;
		}

		public string Name { get; private set; }
		public PatternNode Pattern { get; private set; }
	}
	public class StructPatternNode : PatternNode {
		public StructPatternNode(SourceLocation location, IEnumerable<StructPatternElementNode> innerPatterns, string name, bool isLet, bool isVolatile, RefKind @ref, TypeExpressionNode typeAnnotation, TailPosition? tailPosition) : base(location)
		{
			InnerPatterns = innerPatterns?.ToList().AsReadOnly();
			Name = name;
			IsLet = isLet;
			IsVolatile = isVolatile;
			Ref = @ref;
			TypeAnnotation = typeAnnotation;
			TailPosition = tailPosition;
		}

		public IReadOnlyList<StructPatternElementNode> InnerPatterns { get; private set; }
		public string Name { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }
		public TailPosition? TailPosition { get; private set; }

		//Ex.: {X = _, Y = a, ...}
		//Ex.: let& c = {X = _, Y = a } :: Vec2
		//Ex.: &{X = _, Y = a }
	}
}
