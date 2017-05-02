using System;
using ivyc.Basic;
namespace ivyc.AST {
	public abstract class Node {
		protected Node(SourceLocation location) {
			this.Location = location;
		}

		public SourceLocation Location {
			get;
			protected set;
		}
	}
}
