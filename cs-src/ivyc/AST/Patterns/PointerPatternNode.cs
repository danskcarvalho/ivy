using System;
namespace ivyc.AST {
	public class PointerPatternNode : PatternNode {
		private PointerPatternNode() {
		}

		public PatternNode Inner { get; private set; }
		public string Name { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }
	}
}
