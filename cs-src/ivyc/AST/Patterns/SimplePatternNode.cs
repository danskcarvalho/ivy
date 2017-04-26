using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class SimplePatternNode : PatternNode {
		private SimplePatternNode() {
		}

		public bool IsConst { get; private set; }
		public bool IsVolatile { get; private set; }
		public RefKind Ref { get; private set; }
		public string Name { get; private set; }
		public IReadOnlyList<ExpressionNode> Indexes { get; private set; }
		public TypeExpressionNode Type { get; private set; }

		//Ex.: b :: const int& (or) const& b :: int
		//Ex.: b
		//Ex.: const& b
		//Ex.: &b
	}
}
