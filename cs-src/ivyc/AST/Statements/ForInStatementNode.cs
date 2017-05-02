using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	// Ex.: for var I in 0...List.Count
	public class FoInStatementNode : StatementNode {
		public FoInStatementNode(SourceLocation location, ExpressionNode sequence, PatternNode varName, string labelName, IEnumerable<StatementNode> body) : base(location)
		{
			Sequence = sequence;
			VarName = varName;
			LabelName = labelName;
			Body = body?.ToList().AsReadOnly();
		}

		public ExpressionNode Sequence { get; private set; }
		public PatternNode VarName { get; private set; }
		public string LabelName { get; private set; }
		public IReadOnlyList<StatementNode> Body { get; private set; }
		//not supported on prototype
		//public bool IsAsync { get; private set; }

	}
}
