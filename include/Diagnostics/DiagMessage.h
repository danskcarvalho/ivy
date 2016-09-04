//=- Diagnostics/DiagMessage.h - Diagnostic Message Definition -*- C++ -*-=====//
//
//                               Ivy Compiler
//
// This file is distributed under the Open Source License.
// See LICENSE.TXT for details.
//
//===----------------------------------------------------------------------===//
//
// This file contains the definition of the DiagMessage which is the model for
// diagnostic messages (Errors, Warnings and Messages) inside the compiler.
//
//===----------------------------------------------------------------------===//

#ifndef IVY_DIAGNOSTICS_DIAGMESSAGE
#define IVY_DIAGNOSTICS_DIAGMESSAGE
#include "Basic/BasicTypes.h"
#include "Basic/SourceLocation.h"

namespace ivy {
  /// DiagMessage - Diagnostic Message emitted by the compiler. Can be an error, warning or
  /// simple message.
  class DiagMessage {
  public:
    /// DiagMessageType - The Type of the DiagMessage
    enum DiagMessageType {
      NoType        = 0,
      Error         = 1,
      Warning       = 2,
      Info          = 3
    };
    /// DiagMessageSeverity - The higher the Level, the less severe the DiagMessage is
    enum DiagMessageSeverity {
      NoLevel   = 0,
      Level1    = 1,
      Level2    = 2,
      Level3    = 3,
      Level4    = 4
    };
    /// DiagMessageSource - Where this DiagMessage came from
    enum DiagMessageSource {
      NoSource        = 0,
      SourceStreamer  = 1,
      Preprocessor    = 2,
      Lexer           = 3,
      Parser          = 4,
      InterfaceGen    = 5,
      SemaDriver      = 6,
      SemaAnalyzer    = 7,
      CodeGen         = 8
    };
  private:
    /// Id of this message
    UInt32 Id;
    /// Location where the message was generated from
    Option<SourceLocation> Location;
    /// The Message
    String Message;
    /// Type
    DiagMessageType Type;
    /// Severity
    DiagMessageSeverity Severity;
    /// Source
    DiagMessageSource Source;
    /// Parent
    UInt32 Parent;
  public:
    inline DiagMessage() {
      Id = 0;
      Type = NoType;
      Severity = NoLevel;
      Source = NoSource;
    }
    inline DiagMessage(UInt32 Id,
                       ConstOptionRef<SourceLocation> Location,
                       ConstStringRef Message,
                       DiagMessageType Type,
                       DiagMessageSeverity Severity,
                       DiagMessageSource Source,
                       UInt32 Parent) {
      this->Id            = Id;
      this->Location      = Location;
      this->Message       = Message;
      this->Type          = Type;
      this->Severity      = Severity;
      this->Source        = Source;
      this->Parent        = Parent;
    }

    inline UInt32 getId() const {
      return Id;
    }
    inline void setId(UInt32 Id) {
      DiagMessage::Id = Id;
    }
    inline const Option<ivy::SourceLocation> &getLocation() const {
      return Location;
    }
    inline void setLocation(const Option<ivy::SourceLocation> &Location) {
      DiagMessage::Location = Location;
    }
    inline const String &getMessage() const {
      return Message;
    }
    inline void setMessage(const String &Message) {
      DiagMessage::Message = Message;
    }
    inline DiagMessageType getType() const {
      return Type;
    }
    inline void setType(DiagMessageType Type) {
      DiagMessage::Type = Type;
    }
    inline DiagMessageSeverity getSeverity() const {
      return Severity;
    }
    inline void setSeverity(DiagMessageSeverity Severity) {
      DiagMessage::Severity = Severity;
    }
    inline DiagMessageSource getSource() const {
      return Source;
    }
    inline void setSource(DiagMessageSource Source) {
      DiagMessage::Source = Source;
    }
    inline UInt32 getParent() const {
      return Parent;
    }
    inline void setParent(UInt32 Parent) {
      DiagMessage::Parent = Parent;
    }

    DiagMessage WithId(UInt32 Id) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }
    DiagMessage WithLocation(ConstOptionRef<SourceLocation> Location) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }
    DiagMessage WithMessage(ConstStringRef Message) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }
    DiagMessage WithType(DiagMessageType Type) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }
    DiagMessage WithSeverity(DiagMessageSeverity Severity) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }
    DiagMessage WithSource(DiagMessageSource Source) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }
    DiagMessage WithParent(UInt32 Parent) const {
      return DiagMessage(Id, Location, Message, Type, Severity, Source, Parent);
    }

    DiagMessage& ChangeId(UInt32 Id) {
      this->Id = Id;
      return *this;
    }
    DiagMessage& ChangeLocation(ConstOptionRef<SourceLocation> Location) {
      this->Location = Location;
      return *this;
    }
    DiagMessage& ChangeMessage(ConstStringRef Message) {
      this->Message = Message;
      return *this;
    }
    DiagMessage& ChangeType(DiagMessageType Type) {
      this->Type = Type;
      return *this;
    }
    DiagMessage& ChangeSeverity(DiagMessageSeverity Severity) {
      this->Severity = Severity;
      return *this;
    }
    DiagMessage& ChangeSource(DiagMessageSource Source) {
      this->Source = Source;
      return *this;
    }
    DiagMessage& ChangeParent(UInt32 Parent) {
      this->Parent = Parent;
      return *this;
    }

    inline Bool HasLocation() const {
      return Location.hasValue();
    }
    inline Bool HasParent() const {
      return Parent != 0;
    }

    bool operator==(const DiagMessage &rhs) const {
      return Id     == rhs.Id &&
          Location  == rhs.Location &&
          Message   == rhs.Message &&
          Type      == rhs.Type &&
          Severity  == rhs.Severity &&
          Source    == rhs.Source &&
          Parent    == rhs.Parent;
    }
    bool operator!=(const DiagMessage &rhs) const {
      return !(rhs == *this);
    }
    bool operator<(const DiagMessage &rhs) const {
      if (Id < rhs.Id)
        return true;
      if (rhs.Id < Id)
        return false;
      if (Location < rhs.Location)
        return true;
      if (rhs.Location < Location)
        return false;
      if (Message < rhs.Message)
        return true;
      if (rhs.Message < Message)
        return false;
      if (Type < rhs.Type)
        return true;
      if (rhs.Type < Type)
        return false;
      if (Severity < rhs.Severity)
        return true;
      if (rhs.Severity < Severity)
        return false;
      if (Source < rhs.Source)
        return true;
      if (rhs.Source < Source)
        return false;
      return Parent < rhs.Parent;
    }
    bool operator>(const DiagMessage &rhs) const {
      return rhs < *this;
    }
    bool operator<=(const DiagMessage &rhs) const {
      return !(rhs < *this);
    }
    bool operator>=(const DiagMessage &rhs) const {
      return !(*this < rhs);
    }
  };
}
#endif