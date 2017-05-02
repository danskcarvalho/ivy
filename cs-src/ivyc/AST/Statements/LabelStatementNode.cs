using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class LabelStatementNode : StatementNode {
		public LabelStatementNode(SourceLocation location, string name, IEnumerable<StatementNode> block) : base(location)
		{
			Name = name;
			Block = block?.ToList().AsReadOnly();
		}

		public string Name { get; private set; }
		//if this is null or empty, then it's an empty block and can be used as a goto
		//target. Ex.:
		//
		// a = 0
		// Again:
		// a++
		// if a < 10:
		//    goto Again
		public IReadOnlyList<StatementNode> Block { get; private set; }
	}
}
