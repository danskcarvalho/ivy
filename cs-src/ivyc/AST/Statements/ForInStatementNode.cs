using System;
namespace ivyc.AST {
	// Ex.: for var I in 0...List.Count
	public class FoInStatementNode : StatementNode {
		private FoInStatementNode() {
		}

		public ExpressionNode Sequence { get; private set; }
		public PatternNode VarName { get; private set; }
		public string LabelName { get; private set; }
		//not supported on prototype
		//public bool IsAsync { get; private set; }

	}
}
