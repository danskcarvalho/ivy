using System;
namespace ivyc.Basic {
	/// <summary>
	/// Identifies a place in a source file.
	/// </summary>
	public struct SourceLocation : IEquatable<SourceLocation> {
		/// <summary>
		/// No value.
		/// </summary>
		public const int NoValue = -1;

		public int SourceId { get; private set; }
		public int Line { get; private set; }
		public int Column { get; private set; }
		public int Offset { get; private set; }
		public int Length { get; private set; }

		public static SourceLocation Create(
			int SourceId = -1,
			int Line = -1,
			int Column = -1,
			int Offset = -1,
			int Length = -1) {
			SourceLocation result = new SourceLocation();

			result.SourceId = SourceId;
			result.Line = Line;
			result.Column = Column;
			result.Offset = Offset;
			result.Length = Length;

			return result;
		}

		public SourceLocation With(
			int? SourceId = null,
			int? Line = null,
			int? Column = null,
			int? Offset = null,
			int? Length = null) {
			SourceLocation clone = this;
			if (SourceId.HasValue)
				clone.SourceId = SourceId.Value;
			if (Line.HasValue)
				clone.Line = Line.Value;
			if (Column.HasValue)
				clone.Column = Column.Value;
			if (Offset.HasValue)
				clone.Offset = Offset.Value;
			if (Length.HasValue)
				clone.Length = Length.Value;

			return clone;
		}

		public bool HasSourceId => SourceId != NoValue;
		public bool HasLine => Line != NoValue;
		public bool HasColumn => Column != NoValue;
		public bool HasOffset => Offset != NoValue;
		public bool HasLength => Length != NoValue;

		public bool Equals(SourceLocation other) {
			return other.SourceId == SourceId && other.Line == Line && other.Column == Column && other.Offset == Offset &&
						other.Length == Length;
		}

		public override bool Equals(object obj) {
			if (!(obj is SourceLocation))
				return false;
			return Equals((SourceLocation)obj);
		}

		public override string ToString() {
			return string.Format("[SourceId={0}, Line={1}, Column={2}, Offset={3}, Length={4}]", SourceId, Line, Column, Offset, Length);
		}

		public override int GetHashCode() {
			int result = 17;
			result = 31 * result + SourceId.GetHashCode();
			result = 31 * result + Line.GetHashCode();
			result = 31 * result + Column.GetHashCode();
			result = 31 * result + Offset.GetHashCode();
			result = 31 * result + Length.GetHashCode();
			return result;
		}

		public static bool operator==(SourceLocation v1, SourceLocation v2){
			return v1.Equals(v2);
		}
		public static bool operator!=(SourceLocation v1, SourceLocation v2){
			return !v1.Equals(v2);
		}
	}
}
