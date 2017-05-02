using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

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
		public TryStatementNode(SourceLocation location, IEnumerable<StatementNode> tryBody, IEnumerable<CaseStatementNode> catchFilterBody, IEnumerable<StatementNode> catchStmtBody) : base(location)
		{
			TryBody = tryBody?.ToList().AsReadOnly();
			CatchFilterBody = catchFilterBody?.ToList().AsReadOnly();
			CatchStmtBody = catchStmtBody?.ToList().AsReadOnly();
		}

		public IReadOnlyList<StatementNode> TryBody { get; private set; }
		public IReadOnlyList<CaseStatementNode> CatchFilterBody { get; private set; }
		public IReadOnlyList<StatementNode> CatchStmtBody { get; private set; }
	}
}
