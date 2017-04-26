using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public enum TailPosition {
		AtStart,
		AtEnd
	}
	public class ConstructorPatternNode : PatternNode {
		private ConstructorPatternNode() {
		}

		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }

		public string ModuleName { get; private set; }
		public string ConstructorName { get; private set; }
		public IReadOnlyList<string> TypePatterns { get; private set; }
		public IReadOnlyList<PatternNode> ValuePatterns { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }
		public string Name { get; private set; }
		public TailPosition? TailPosition { get; private set; }

		//Ex.: a = sys.Some(a) :: const Nullable<int>&
		//Ex.: const& a = sys.Some(a)
		//where Name = a, ModuleName = sys, ConstructorName = Some, TypePatterns = [B], TypeAnnotation = Nullable<int>
	}
}
