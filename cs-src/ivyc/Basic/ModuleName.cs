using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace ivyc.Basic {
	/// <summary>
	/// A Module name
	/// </summary>
	public class ModuleName : IEquatable<ModuleName> {

		public IReadOnlyList<string> Names { get; private set; }

		public bool IsEmpty => Names == null || Names.Count == 0;

		private ModuleName(){
			
		}

		public ModuleName Create(IEnumerable<string> names){
			if (names == null)
				return new ModuleName() { Names = new ReadOnlyCollection<string>(new List<string>()) };

			return new ModuleName() {
				Names = new ReadOnlyCollection<string>(names.ToList())
			};
		}

		public ModuleName Create(params string[] names) {
			if (names == null)
				return new ModuleName() { Names = new ReadOnlyCollection<string>(new List<string>()) };

			return new ModuleName() {
				Names = new ReadOnlyCollection<string>(names.ToList())
			};
		}

		public bool Equals(ModuleName other) {
			if (other.Names.Count != Names.Count)
				return false;

			for (int i = 0; i < other.Names.Count; i++) {
				if (Names[i] != other.Names[i])
					return false;
			}

			return true;
		}

		public override bool Equals(object obj) {
			return Equals(obj as ModuleName);
		}

		public override int GetHashCode() {
			int result = 17;
			for (int i = 0; i < Names.Count; i++) {
				result = 31 * result + Names[i].GetHashCode();
			}
			return result;
		}

		public override string ToString() {
			return string.Join(".", Names.ToList());
		}

		public static bool operator==(ModuleName v1, ModuleName v2){
			if (object.ReferenceEquals(v1, v2))
				return true;
			if (object.ReferenceEquals(v1, null) || object.ReferenceEquals(v2, null))
				return false;

			return v1.Equals(v2);
		}
		public static bool operator !=(ModuleName v1, ModuleName v2) {
			if (object.ReferenceEquals(v1, v2))
				return false;
			if (object.ReferenceEquals(v1, null) || object.ReferenceEquals(v2, null))
				return true;

			return !v1.Equals(v2);
		}
	}
}
