//=- Basic/Assert.h - Assert -*- C++ -*-======================================//
//
//                               Ivy Compiler
//
// This file is distributed under the Open Source License.
// See LICENSE.TXT for details.
//
//===----------------------------------------------------------------------===//
//
// This file contains the assert macro.
//
//===----------------------------------------------------------------------===//

#ifndef IVY_BASIC_ASSERT
#define IVY_BASIC_ASSERT

#ifndef IVY_NO_INCLUDES
#include <cassert>
#endif

#define IvyAssert(cond, msg) assert((cond) && (msg))

#endif
