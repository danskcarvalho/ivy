using System;
using ivyc.Basic;

namespace ivyc.AST {
	public abstract class StatementNode : Node {
		protected StatementNode(SourceLocation location) : base(location)
		{
		}
	}
}
