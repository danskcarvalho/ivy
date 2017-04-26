﻿using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public enum DeferStatementKind {
		Regular,
		Delete,
		Fail,
		Throw,
		Yield,
		YieldBreak
	}
	public class DeferStatementNode : StatementNode {
		private DeferStatementNode() {
		}

		public ExpressionNode Expression { get; private set; }
		public IReadOnlyList<StatementNode> Body { get; private set; }
		public DeferStatementKind Kind { get; private set; }
	}
}