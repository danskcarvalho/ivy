using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class StructPatternElementNode : Node {
		public StructPatternElementNode(){
			
		}

		public string Name { get; private set; }
		public PatternNode Pattern { get; private set; }
	}
	public class StructPatternNode : PatternNode {
		private StructPatternNode() {
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
