using System;
using ivyc.Basic;

namespace ivyc.AST {
	//Ex.: let Index = 10
	public class VarStatementNode : StatementNode {
		public VarStatementNode(SourceLocation location, PatternNode varName, ExpressionNode initialization) : base(location)
		{
			VarName = varName;
			Initialization = initialization;
		}

		public PatternNode VarName { get; private set; }
		public ExpressionNode Initialization { get; private set; }
	}
}
