//=- Basic/SourceLocation.h - Source Location -*- C++ -*-======================//
//
//                               Ivy Compiler
//
// This file is distributed under the Open Source License.
// See LICENSE.TXT for details.
//
//===----------------------------------------------------------------------===//
//
// This file defines the SourceLocation class
//
//===----------------------------------------------------------------------===//

#ifndef IVY_BASIC_SOURCELOCATION
#define IVY_BASIC_SOURCELOCATION
#include "Basic/BasicTypes.h"

namespace ivy {
  /// SourceLocation - identifies a location in the source file
  class SourceLocation {
  private:
    /// Line of the source file (starting with 0)
    UInt32 Line;
    /// Column of the source file (starting with 0)
    UInt32 Column;
    /// Offset into the source file
    UInt32 Offset;
    /// Length of the span identified by this object
    UInt32 Length;
    /// Id of the source file
    UInt32 SourceId;
  public:
    /// Constant that identifies if this SourceLocation has no SourceId
    static const UInt32 NoSourceId;

    SourceLocation(){
      Line = Column = Offset = Length = 0;
      SourceId = NoSourceId;
    }
    SourceLocation(UInt32 Line, UInt32 Column, UInt32 Offset, UInt32 Length, UInt32 SourceId) {
      this->Line   = Line;
      this->Column = Column;
      this->Offset = Offset;

      this->Length   = Length;
      this->SourceId = SourceId;
    }

    inline UInt32 getLine() const {
      return Line;
    }
    inline void setLine(UInt32 Line) {
      SourceLocation::Line = Line;
    }
    inline UInt32 getColumn() const {
      return Column;
    }
    inline void setColumn(UInt32 Column) {
      SourceLocation::Column = Column;
    }
    inline UInt32 getOffset() const {
      return Offset;
    }
    inline void setOffset(UInt32 Offset) {
      SourceLocation::Offset = Offset;
    }
    inline UInt32 getLength() const {
      return Length;
    }
    inline void setLength(UInt32 Length) {
      SourceLocation::Length = Length;
    }
    inline UInt32 getSourceId() const {
      return SourceId;
    }
    inline void setSourceId(UInt32 SourceId) {
      SourceLocation::SourceId = SourceId;
    }

    inline Bool HasSourceId() const {
      return SourceId != NoSourceId;
    }
    inline Bool IsSpan() const {
      return Length != 0;
    }
    inline Bool IsOffset() const {
      return Length == 0;
    }
    inline Bool Contains(UInt32 Offset) const {
      return Offset >= this->Offset && Offset <= (this->Offset + this->Length);
    }

    inline SourceLocation WithLine(UInt32 Line) const {
      return SourceLocation(Line, Column, Offset, Length, SourceId);
    }
    inline SourceLocation WithColumn(UInt32 Column) const {
      return SourceLocation(Line, Column, Offset, Length, SourceId);
    }
    inline SourceLocation WithOffset(UInt32 Offset) const {
      return SourceLocation(Line, Column, Offset, Length, SourceId);
    }
    inline SourceLocation WithLength(UInt32 Length) const {
      return SourceLocation(Line, Column, Offset, Length, SourceId);
    }
    inline SourceLocation WithSourceId(UInt32 SourceID) const {
      return SourceLocation(Line, Column, Offset, Length, SourceId);
    }

    inline SourceLocation& ChangeLine(UInt32 Line) {
      this->Line = Line;
      return *this;
    }
    inline SourceLocation& ChangeColumn(UInt32 Column) {
      this->Column = Column;
      return *this;
    }
    inline SourceLocation& ChangeOffset(UInt32 Offset) {
      this->Offset = Offset;
      return *this;
    }
    inline SourceLocation& ChangeLength(UInt32 Length) {
      this->Length = Length;
      return *this;
    }
    inline SourceLocation& ChangeSourceId(UInt32 SourceId) {
      this->SourceId = SourceId;
      return *this;
    }

    inline bool operator<(const SourceLocation &rhs) const {
      if (Line < rhs.Line)
        return true;
      if (rhs.Line < Line)
        return false;
      if (Column < rhs.Column)
        return true;
      if (rhs.Column < Column)
        return false;
      if (Offset < rhs.Offset)
        return true;
      if (rhs.Offset < Offset)
        return false;
      if (Length < rhs.Length)
        return true;
      if (rhs.Length < Length)
        return false;
      return SourceId < rhs.SourceId;
    }
    inline bool operator>(const SourceLocation &rhs) const {
      return rhs < *this;
    }
    inline bool operator<=(const SourceLocation &rhs) const {
      return !(rhs < *this);
    }
    inline bool operator>=(const SourceLocation &rhs) const {
      return !(*this < rhs);
    }
    inline bool operator==(const SourceLocation &rhs) const {
      return  Line     == rhs.Line &&
              Column   == rhs.Column &&
              Offset   == rhs.Offset &&
              Length   == rhs.Length &&
              SourceId == rhs.SourceId;
    }
    inline bool operator!=(const SourceLocation &rhs) const {
      return !(rhs == *this);
    }
  };
}
#endif
