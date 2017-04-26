using System;
namespace ivyc.Basic {
	public enum NameKind {
		None = 0,
		Identifier,
		Operator,
		Prefix,
		Postfix,
		Init,
		Deinit,
		New,
		Delete,
		Self,
	}
	public struct Name : IEquatable<Name> {
		public NameKind Kind { get; private set; }
		public string Identifier { get; private set; }
		public OperatorName Operator { get; private set; }

		public bool IsEmpty => Kind == NameKind.None;
		public bool IsIdentifier => Kind == NameKind.Identifier;

		public Name CreateIdentifier(string id){
			return new Name() {
				Kind = NameKind.Identifier,
				Identifier = id,
				Operator = OperatorName.None
			};
		}

		public Name CreateOperator(OperatorName op){
			return new Name() {
				Kind = NameKind.Operator,
				Identifier = null,
				Operator = op
			};
		}

		public Name CreatePrefix(OperatorName op) {
			return new Name() {
				Kind = NameKind.Prefix,
				Identifier = null,
				Operator = op
			};
		}

		public Name CreatePostfix(OperatorName op) {
			return new Name() {
				Kind = NameKind.Postfix,
				Identifier = null,
				Operator = op
			};
		}

		public Name CreateInit() => new Name() { Kind = NameKind.Init };
		public Name CreateDeinit() => new Name() { Kind = NameKind.Deinit };
		public Name CreateNew() => new Name() { Kind = NameKind.New };
		public Name CreateDelete() => new Name() { Kind = NameKind.Delete };
		public Name CreateSelf() => new Name() { Kind = NameKind.Self };

		public bool Equals(Name other) {
			return other.Kind == Kind && other.Operator == Operator && other.Identifier == Identifier;
		}

		public override bool Equals(object obj) {
			if (!(obj is Name))
				return false;
			return Equals((Name)obj);
		}

		public override int GetHashCode() {
			int result = 17;
			result = 31 * result + Kind.GetHashCode();
			result = 31 * result + Operator.GetHashCode();
			result = 31 * result + (Identifier ?? string.Empty).GetHashCode();
			return result;
		}

		public override string ToString() {
			switch (Kind) {
				case NameKind.Deinit:
					return "deinit";
				case NameKind.Delete:
					return "delete";
				case NameKind.Identifier:
					return Identifier;
				case NameKind.Init:
					return "init";
				case NameKind.New:
					return "new";
				case NameKind.Self:
					return "self";
				case NameKind.Operator:
					return $"operator {Operator.GetTextualRepresentation()}";
				case NameKind.Prefix:
					return $"prefix {Operator.GetTextualRepresentation()}";
				case NameKind.Postfix:
					return $"postfix {Operator.GetTextualRepresentation()}";
				default:
					return null;
			}
		}

		public static bool operator==(Name v1, Name v2){
			return v1.Equals(v2);
		}
		public static bool operator!=(Name v1, Name v2){
			return !v1.Equals(v2);
		}
	}
}
