using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class IfStatementNode : StatementNode {
		public IfStatementNode(SourceLocation location, ExpressionNode condition, IEnumerable<StatementNode> trueStatements, IEnumerable<StatementNode> elseStatements) : base(location)
		{
			Condition = condition;
			TrueStatements = trueStatements?.ToList().AsReadOnly();
			ElseStatements = elseStatements?.ToList().AsReadOnly();
		}

		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<StatementNode> TrueStatements { get; private set; }
		public IReadOnlyList<StatementNode> ElseStatements { get; private set; }
	}
}
