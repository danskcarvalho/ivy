using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class TupleElementPatternNode : Node {
		public TupleElementPatternNode(SourceLocation location, PatternNode left, PatternNode right) : base(location)
		{
			Left = left;
			Right = right;
		}

		public PatternNode Left { get; private set; }
		public PatternNode Right { get; private set; }
	}
	public class TuplePatternNode : PatternNode {
		public TuplePatternNode(SourceLocation location, TupleKind tupleKind, string name, bool isLet, bool isUnstable, bool isPointer, RefKind @ref, IEnumerable<TupleElementPatternNode> innerPatterns, TypeExpressionNode typeAnnotation, TailPosition? tailPosition) : base(location)
		{
			TupleKind = tupleKind;
			Name = name;
			IsLet = isLet;
			IsUnstable = isUnstable;
			IsPointer = isPointer;
			Ref = @ref;
			InnerPatterns = innerPatterns?.ToList().AsReadOnly();
			TypeAnnotation = typeAnnotation;
			TailPosition = tailPosition;
		}

		public TupleKind TupleKind { get; private set; }
		public string Name { get; private set; }
		public bool IsLet { get; private set; }
		public bool IsUnstable { get; private set; }
		public bool IsPointer { get; private set; }
		public RefKind Ref { get; private set; }
		public IReadOnlyList<TupleElementPatternNode> InnerPatterns { get; private set; }
		public TypeExpressionNode TypeAnnotation { get; private set; }
		public TailPosition? TailPosition { get; private set; }

		//Ex.:
		// [a, b, ...]
		// &[a] can be used to match a pointer
		// &[0, 1] matches a pointer such that ptr[0] == 0 && ptr[1] == 1
	}
}
