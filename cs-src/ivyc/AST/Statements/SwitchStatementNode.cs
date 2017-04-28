using System;
using System.Collections.Generic;
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
		private CaseStatementNode(){
		}

		public CaseStatementKind Kind { get; private set; }
		public PatternNode Pattern { get; private set; }
		public ExpressionNode WhereClause { get; private set; }
		public IReadOnlyList<StatementNode> Body { get; private set; }
	}
	public class SwitchStatementNode : StatementNode {
		private SwitchStatementNode() {
		}

		public string LabelName { get; private set; }
		public ExpressionNode Target { get; private set; }
		public IReadOnlyList<CaseStatementNode> CaseStatements { get; private set; }
	}
}
