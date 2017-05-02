using System;
using ivyc.Basic;

namespace ivyc.AST {
	public abstract class PatternNode : Node {
		protected PatternNode(SourceLocation location) : base(location)
		{
		}
	}
}
