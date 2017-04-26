﻿using System;
namespace ivyc.AST {
	public enum ExpressionStatementKind {
		Execute,
		Return,
		Fail,
		Throw,
		Yield,
		YieldBreak,
		Delete
	}
	public class ExpressionStatementNode : StatementNode {
		private ExpressionStatementNode() {
		}

		public ExpressionStatementKind Kind { get; private set; }
		public ExpressionNode Expression { get; private set; }
	}
}