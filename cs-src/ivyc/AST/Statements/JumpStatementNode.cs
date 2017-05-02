using System;
using ivyc.Basic;

namespace ivyc.AST {
	public enum JumpStatementKind {
		//not supported on prototype
		Goto,
		Continue,
		Break
	}
	public class JumpStatementNode : StatementNode {
		public JumpStatementNode(SourceLocation location, string labelName, JumpStatementKind kind) : base(location)
		{
			LabelName = labelName;
			Kind = kind;
		}

		public string LabelName { get; set; }
		public JumpStatementKind Kind { get; set; } 
	}
}
