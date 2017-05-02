using System;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: _
	public class WildcardPatternNode : PatternNode {
		public WildcardPatternNode(SourceLocation location) : base(location)
		{
		}
	}
}
