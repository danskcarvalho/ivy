using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class UsingStatementNode : StatementNode {
		public UsingStatementNode(SourceLocation location, PatternNode varName, ExpressionNode initialization, IEnumerable<StatementNode> block, string labelName) : base(location)
		{
			VarName = varName;
			Initialization = initialization;
			Block = block?.ToList().AsReadOnly();
			LabelName = labelName;
		}

		public PatternNode VarName { get; private set; }
		public ExpressionNode Initialization { get; private set; }
		public IReadOnlyList<StatementNode> Block { get; private set; }
		public string LabelName { get; private set; }
	}
}
