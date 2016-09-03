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
namespace ivy {
  /// Diagnostic Message emitted by the compiler. Can be an error, warning or
  /// simple message.
  class DiagMessage {
  public:
    /// New empty diagnostic message.
    DiagMessage();
  };
}
#endif