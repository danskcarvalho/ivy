using System;
using ivyc.Basic;
namespace ivyc.AST {
	public abstract class Node {
		protected Node() {
		}

		public SourceLocation Location {
			get;
			protected set;
		}

		public Node Parent {
			get;
			set;
		}
	}
}
