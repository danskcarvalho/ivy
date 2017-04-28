using System;
using System.Collections.Generic;
namespace ivyc.AST {
	//Ex.:
	//try:
	//	SomeCode()
	//catch:
	//	throw EIO(Code, Message):
	//		return Message
	//	default:
	//		Out.WriteLine("some unknown error...")
	//only fail is supported in the prototype
	public class TryStatementNode : StatementNode {
		private TryStatementNode() {
		}

		public IReadOnlyList<StatementNode> TryBody { get; private set; }
		public IReadOnlyList<CaseStatementNode> CatchFilterBody { get; private set; }
		public IReadOnlyList<StatementNode> CatchStmtBody { get; private set; }
	}
}
