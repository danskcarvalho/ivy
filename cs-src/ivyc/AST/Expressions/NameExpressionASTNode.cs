using System;
using ivyc.Basic;
namespace ivyc.AST {
	public class NameExpressionASTNode : ExpressionNode {
		private NameExpressionASTNode() {
		}

		public Name Name { get; private set; }
		public string ModulePrefix { get; private set; }

		//Ex.: Sys:List where ModulePrefix = Sys, Name = List
		//The operator : must be used without spaces
		//Ex.: [a: 10, b: 20] is not interpreted as the module prefix
	}
}
