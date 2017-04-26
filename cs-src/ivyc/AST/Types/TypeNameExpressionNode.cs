using System;
namespace ivyc.AST {
	public class TypeNameExpressionNode : TypeExpressionNode {
		protected TypeNameExpressionNode() {
		}

		public string Name { get; private set; }

		public TypeNameExpressionNode Create(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return new TypeNameExpressionNode() {
				Name = name
			};
		}
	}
}
