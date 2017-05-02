using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: for var I = 0, var J = 0 while I < Count && J < Count do I++, J++
	public class ForWhileStatementNode : StatementNode {
		public ForWhileStatementNode(SourceLocation location, string labelName, IEnumerable<PatternNode> varNames, IEnumerable<ExpressionNode> initializations, ExpressionNode condition, IEnumerable<ExpressionNode> next, IEnumerable<StatementNode> body) : base(location)
		{
			LabelName = labelName;
			VarNames = varNames?.ToList().AsReadOnly();
			Initializations = initializations?.ToList().AsReadOnly();
			Condition = condition;
			Next = next?.ToList().AsReadOnly();
			Body = body?.ToList().AsReadOnly();
		}

		public string LabelName { get; private set; }
		public IReadOnlyList<PatternNode> VarNames { get; private set; }
		public IReadOnlyList<ExpressionNode> Initializations { get; private set; }
		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<ExpressionNode> Next { get; private set; }
		public IReadOnlyList<StatementNode> Body { get; private set; }
	}
}
