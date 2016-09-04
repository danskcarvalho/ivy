//=- Basic/BasicTypes.h - Basic Types -*- C++ -*-=============================//
//
//                               Ivy Compiler
//
// This file is distributed under the Open Source License.
// See LICENSE.TXT for details.
//
//===----------------------------------------------------------------------===//
//
// This file contains basic types definitions used throughout the compiler.
//
//===----------------------------------------------------------------------===//

#ifndef IVY_BASIC_BASICTYPES
#define IVY_BASIC_BASICTYPES

#ifndef IVY_NO_INCLUDES
#include <cstdint>
#include <string>
#include <vector>
#include <array>
#include <set>
#include <map>
#include <llvm/ADT/StringRef.h>
#include <llvm/ADT/ArrayRef.h>
#include <llvm/ADT/Optional.h>
#ifdef NDEBUG
#include <llvm/ADT/SmallVector.h>
#include <llvm/ADT/SmallString.h>
#include <llvm/ADT/SmallSet.h>
#include <llvm/ADT/SmallPtrSet.h>
#include <llvm/ADT/StringSet.h>
#include <llvm/ADT/DenseSet.h>
#include <llvm/ADT/StringMap.h>
#include <llvm/ADT/DenseMap.h>
#include <llvm/ADT/DenseMapInfo.h>
#endif
#endif

namespace ivy {
  // Signed Integer
  typedef int8_t   Int8;
  typedef int16_t  Int16;
  typedef int32_t  Int32;
  typedef int64_t  Int64;
  typedef int8_t&  Int8Ref;
  typedef int16_t& Int16Ref;
  typedef int32_t& Int32Ref;
  typedef int64_t& Int64Ref;

  // Unsigned Integer
  typedef uint8_t   UInt8;
  typedef uint16_t  UInt16;
  typedef uint32_t  UInt32;
  typedef uint16_t  UInt62;
  typedef uint8_t&  UInt8Ref;
  typedef uint16_t& UInt16Ref;
  typedef uint32_t& UInt32Ref;
  typedef uint16_t& UInt62Ref;

  // Char
  typedef char      Char8;
  typedef char16_t  Char16;
  typedef char32_t  Char32;
  typedef char&     Char8Ref;
  typedef char16_t& Char16Ref;
  typedef char32_t& Char32Ref;

  // Char Pointer
  typedef char*             Char8Ptr;
  typedef const char*       ConstChar8Ptr;
  typedef char16_t*         Char16Ptr;
  typedef const char16_t*   ConstChar16Ptr;
  typedef char32_t*         Char32Ptr;
  typedef char32_t*         ConstChar32Ptr;
  typedef char*&            Char8PtrRef;
  typedef const char*&      ConstChar8PtrRef;
  typedef char16_t*&        Char16PtrRef;
  typedef const char16_t*&  ConstChar16PtrRef;
  typedef char32_t*&        Char32PtrRef;
  typedef char32_t*&        ConstChar32PtrRef;
  // Default Char Pointer
  typedef char*      CharPtr;
  typedef char*      ConstCharPtr;
  typedef char*&     CharPtrRef;
  typedef char*&     ConstCharPtrRef;

  //Others
  typedef bool         Bool;
  typedef float        Single;
  typedef double       Double;
  typedef long double  Extended;
  typedef bool&        BoolRef;
  typedef float&       SingleRef;
  typedef double&      DoubleRef;
  typedef long double& ExtendedRef;

  //Option
  template<class T>
  using Option = llvm::Optional<T>;
  template<class T>
  using OptionRef = llvm::Optional<T>&;
  template<class T>
  using ConstOption = const llvm::Optional<T>;
  template<class T>
  using ConstOptionRef = const llvm::Optional<T>&;

#if defined(NDEBUG) && !defined(IVY_USE_LLVM_DATA_TYPES)
#define IVY_USING_LLVM_TYPES
#endif

#ifndef IVY_DONT_USE_LLVM_STRINGREF
#define IVY_USING_LLVM_STRINGREF
#endif

#ifndef IVY_DONT_USE_LLVM_ARRAYREF
#define IVY_USING_LLVM_ARRAYREF
#endif

#if !defined(NDEBUG) || defined(IVY_USE_LLVM_DATA_TYPES)
  // String
  typedef std::string        String;
  typedef std::string&       StringRef;
  typedef const std::string  ConstString;
#ifndef IVY_DONT_USE_LLVM_STRINGREF
  typedef llvm::StringRef    ConstStringRef;
#else
  typedef const std::string& ConstStringRef;
#endif

  // Small String
  template<unsigned Len>
  using SmallString = std::string;
  template<unsigned Len>
  using SmallStringRef = std::string&;
  template<unsigned Len>
  using ConstSmallString = const std::string;
  template<unsigned Len>
  using ConstSmallStringRef = const std::string&;

  // Vector
  template<class T>
  using Vector = std::vector<T>;
  template<class T>
  using VectorRef = std::vector<T>&;
  template<class T>
  using ConstVector = const std::vector<T>;
#ifndef IVY_DONT_USE_LLVM_ARRAYREF
  template<class T>
  using ConstVectorRef = llvm::ArrayRef<T>;
#else
  template<class T>
  using ConstVectorRef = const std::vector<T>&;
#endif

  // Small Vector
  template<class T, unsigned Size>
  using SmallVector = std::vector<T>;
  template<class T, unsigned Size>
  using SmallVectorRef = std::vector<T>&;
  template<class T, unsigned Size>
  using ConstSmallVector = const std::vector<T>;
  template<class T, unsigned Size>
  using ConstSmallVectorRef = const std::vector<T>&;

  // Array
  template<class T, unsigned Size>
  using Array = std::array<T, Size>;
  template<class T, unsigned Size>
  using ArrayRef = std::array<T, Size>&;
  template<class T, unsigned Size>
  using ConstArray = const std::array<T, Size>;
  template<class T, unsigned Size>
  using ConstArrayRef = const std::array<T, Size>&;

  // Set
  template<class T>
  using Set = std::set<T>;
  template<class T>
  using SetRef = std::set<T>&;
  template<class T>
  using ConstSet = const std::set<T>;
  template<class T>
  using ConstSetRef = const std::set<T>&;

  // Small Set
  template<class T, unsigned Size>
  using SmallSet = std::set<T>;
  template<class T, unsigned Size>
  using SmallSetRef = std::set<T>&;
  template<class T, unsigned Size>
  using ConstSmallSet = const std::set<T>;
  template<class T, unsigned Size>
  using ConstSmallSetRef = const std::set<T>&;

  // Small Pointer Set
  template<class T, unsigned Size>
  using SmallPtrSet = std::set<T>;
  template<class T, unsigned Size>
  using SmallPtrSetRef = std::set<T>&;
  template<class T, unsigned Size>
  using ConstSmallPtrSet = const std::set<T>;
  template<class T, unsigned Size>
  using ConstSmallPtrSetRef = const std::set<T>&;

  // String Set
  typedef std::set<std::string> StringSet;
  typedef std::set<std::string>& StringSetRef;
  typedef const std::set<std::string> ConstStringSet;
  typedef const std::set<std::string>& ConstStringSetRef;

  // Dense Set
  template<class T>
  using DenseSet = std::set<T>;
  template<class T>
  using DenseSetRef = std::set<T>&;
  template<class T>
  using ConstDenseSet = const std::set<T>;
  template<class T>
  using ConstDenseSetRef = const std::set<T>&;

  // Map
  template<class T, class Y>
  using Map = std::map<T, Y>;
  template<class T, class Y>
  using MapRef = std::map<T, Y>&;
  template<class T, class Y>
  using ConstMap = const std::map<T, Y>;
  template<class T, class Y>
  using ConstMapRef = const std::map<T, Y>&;

  // String Map
  template<class T>
  using StringMap = std::map<std::string, T>;
  template<class T>
  using StringMapRef = std::map<std::string, T>&;
  template<class T>
  using ConstStringMap = const std::map<std::string, T>;
  template<class T>
  using ConstStringMapRef = const std::map<std::string, T>&;

  // Dense Map
  template<class T, class Y>
  using DenseMap = std::map<T, Y>;
  template<class T, class Y>
  using DenseMapRef = std::map<T, Y>&;
  template<class T, class Y>
  using ConstDenseMap = const std::map<T, Y>;
  template<class T, class Y>
  using ConstDenseMapRef = const std::map<T, Y>&;
#else
  // String
  typedef std::string        String;
  typedef std::string&       StringRef;
  typedef const std::string  ConstString;
#ifndef IVY_DONT_USE_LLVM_STRINGREF
  typedef llvm::StringRef    ConstStringRef;
#else
  typedef const std::string& ConstStringRef;
#endif

  // Small String
  template<unsigned Len>
  using SmallString = llvm::SmallString<Len>;
  template<unsigned Len>
  using SmallStringRef = llvm::SmallString<Len>&;
  template<unsigned Len>
  using ConstSmallString = const llvm::SmallString<Len>;
  template<unsigned Len>
  using ConstSmallStringRef = const llvm::SmallString<Len>&;

  // Vector
  template<class T>
  using Vector = std::vector<T>;
  template<class T>
  using VectorRef = std::vector<T>&;
  template<class T>
  using ConstVector = const std::vector<T>;
#ifndef IVY_DONT_USE_LLVM_ARRAYREF
  template<class T>
  using ConstVectorRef = llvm::ArrayRef<T>;
#else
  template<class T>
  using ConstVectorRef = const std::vector<T>&;
#endif

  // Small Vector
  template<class T, unsigned Size>
  using SmallVector = llvm::SmallVector<T, Size>;
  template<class T, unsigned Size>
  using SmallVectorRef = llvm::SmallVector<T, Size>&;
  template<class T, unsigned Size>
  using ConstSmallVector = const llvm::SmallVector<T, Size>;
  template<class T, unsigned Size>
  using ConstSmallVectorRef = const llvm::SmallVector<T, Size>&;

  // Array
  template<class T, unsigned Size>
  using Array = std::array<T, Size>;
  template<class T, unsigned Size>
  using ArrayRef = std::array<T, Size>&;
  template<class T, unsigned Size>
  using ConstArray = const std::array<T, Size>;
  template<class T, unsigned Size>
  using ConstArrayRef = const std::array<T, Size>&;

  // Set
  template<class T>
  using Set = std::set<T>;
  template<class T>
  using SetRef = std::set<T>&;
  template<class T>
  using ConstSet = const std::set<T>;
  template<class T>
  using ConstSetRef = const std::set<T>&;

  // Small Set
  template<class T, unsigned Size>
  using SmallSet = llvm::SmallSet<T, Size>;
  template<class T, unsigned Size>
  using SmallSetRef = llvm::SmallSet<T, Size>&;
  template<class T, unsigned Size>
  using ConstSmallSet = const llvm::SmallSet<T, Size>;
  template<class T, unsigned Size>
  using ConstSmallSetRef = const llvm::SmallSet<T, Size>&;

  // Small Pointer Set
  template<class T, unsigned Size>
  using SmallPtrSet = llvm::SmallPtrSet<T, Size>;
  template<class T, unsigned Size>
  using SmallPtrSetRef = llvm::SmallPtrSet<T, Size>&;
  template<class T, unsigned Size>
  using ConstSmallPtrSet = const llvm::SmallPtrSet<T, Size>;
  template<class T, unsigned Size>
  using ConstSmallPtrSetRef = const llvm::SmallPtrSet<T, Size>&;

  // String Set
  typedef llvm::StringSet         StringSet;
  typedef llvm::StringSet&        StringSetRef;
  typedef const llvm::StringSet   ConstStringSet;
  typedef const llvm::StringSet&  ConstStringSetRef;

  // Dense Set
  template<class T>
  using DenseSet = llvm::DenseSet<T>;
  template<class T>
  using DenseSetRef = llvm::DenseSet<T>&;
  template<class T>
  using ConstDenseSet = const llvm::DenseSet<T>;
  template<class T>
  using ConstDenseSetRef = const llvm::DenseSet<T>&;

  // Map
  template<class T, class Y>
  using Map = std::map<T, Y>;
  template<class T, class Y>
  using MapRef = std::map<T, Y>&;
  template<class T, class Y>
  using ConstMap = const std::map<T, Y>;
  template<class T, class Y>
  using ConstMapRef = const std::map<T, Y>&;

  // String Map
  template<class T>
  using StringMap = llvm::StringMap<T>;
  template<class T>
  using StringMapRef = llvm::StringMap<T>&;
  template<class T>
  using ConstStringMap = const llvm::StringMap<T>;
  template<class T>
  using ConstStringMapRef = const llvm::StringMap<T>&;

  // Dense Map
  template<class T, class Y>
  using DenseMap = llvm::DenseMap<T, Y>;
  template<class T, class Y>
  using DenseMapRef = llvm::DenseMap<T, Y>&;
  template<class T, class Y>
  using ConstDenseMap = const llvm::DenseMap<T, Y>;
  template<class T, class Y>
  using ConstDenseMapRef = const llvm::DenseMap<T, Y>&;
#endif
}
#endif
