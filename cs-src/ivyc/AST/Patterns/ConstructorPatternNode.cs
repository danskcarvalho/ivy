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

		public bool IsLet { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }

		public string ModuleName { get; private set; }
		public string ConstructorName { get; private set; }
		public IReadOnlyList<string> TypePatterns { get; private set; }
		public IReadOnlyList<PatternNode> ValuePatterns { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }
		public string Name { get; private set; }
		public TailPosition? TailPosition { get; private set; }

		//Ex.: a = Sys:Some(a) :: Nullable<int>
		//Ex.: let& a = Sys:Some(b)
		//where Name = a, ModuleName = Sys, ConstructorName = Some, TypePatterns = [], TypeAnnotation = Nullable<int>
	}
}
