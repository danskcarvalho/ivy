using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum TailPosition {
		AtStart,
		AtEnd
	}
	public class ConstructorPatternNode : PatternNode {
		public ConstructorPatternNode(SourceLocation location, bool isLet, bool isUnstable, RefKind @ref, string moduleName, string constructorName, IEnumerable<string> typePatterns, IEnumerable<PatternNode> valuePatterns, TypeExpressionNode typeAnnotation, string name, TailPosition? tailPosition) : base(location)
		{
			IsLet = isLet;
			IsUnstable = isUnstable;
			Ref = @ref;
			ModuleName = moduleName;
			ConstructorName = constructorName;
			TypePatterns = typePatterns?.ToList().AsReadOnly();
			ValuePatterns = valuePatterns?.ToList().AsReadOnly();
			TypeAnnotation = typeAnnotation;
			Name = name;
			TailPosition = tailPosition;
		}

		public bool IsLet { get; private set; }
		public bool IsUnstable { get; private set; }
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
