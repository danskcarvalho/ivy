using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public enum CaseStatementKind {
		Case = 0,
		//not supported on prototype
		//Throw = 1,
		Fail = 2,
		Default = 3
	}
	//Ex.: case Expression(a, b)
	public class CaseStatementNode : Node {
		public CaseStatementNode(SourceLocation location, CaseStatementKind kind, PatternNode pattern, ExpressionNode whereClause, IEnumerable<StatementNode> body) : base(location)
		{
			Kind = kind;
			Pattern = pattern;
			WhereClause = whereClause;
			Body = body?.ToList().AsReadOnly();
		}

		public CaseStatementKind Kind { get; private set; }
		public PatternNode Pattern { get; private set; }
		public ExpressionNode WhereClause { get; private set; }
		public IReadOnlyList<StatementNode> Body { get; private set; }
	}
	public class SwitchStatementNode : StatementNode {
		public SwitchStatementNode(SourceLocation location, string labelName, ExpressionNode target, IEnumerable<CaseStatementNode> caseStatements) : base(location)
		{
			LabelName = labelName;
			Target = target;
			CaseStatements = caseStatements?.ToList().AsReadOnly();
		}

		public string LabelName { get; private set; }
		public ExpressionNode Target { get; private set; }
		public IReadOnlyList<CaseStatementNode> CaseStatements { get; private set; }
	}
}
