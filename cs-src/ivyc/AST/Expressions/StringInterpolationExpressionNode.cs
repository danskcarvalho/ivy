using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class StringInterpolationElementNode : Node {
		private StringInterpolationElementNode(){
			
		}

		public string String { get; private set; }
		public ExpressionNode Expression { get; private set; }
	}
	public class StringInterpolationExpressionNode {
		private StringInterpolationExpressionNode() {
		}

		public IReadOnlyList<StringInterpolationElementNode> Elements { get; private set; }
		public StringPrefixKind Prefix { get; private set; }
	}
}
