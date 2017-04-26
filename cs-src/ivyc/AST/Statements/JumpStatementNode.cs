using System;
namespace ivyc.AST {
	public enum JumpStatementKind {
		Goto,
		Continue,
		Break
	}
	public class JumpStatementNode : StatementNode {
		private JumpStatementNode() {
		}

		public string LabelName { get; set; }
		public JumpStatementKind Kind { get; set; } 
	}
}
