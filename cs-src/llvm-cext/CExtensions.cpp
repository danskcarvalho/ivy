#include "CExtensions.h"
#include "llvm-c/Core.h"
#include "llvm/ADT/StringRef.h"
#include "llvm/ADT/APFloat.h"
#include "llvm/IR/Constants.h"
#include "llvm/IR/LLVMContext.h"

class OpaqueAPFloat {
public:
  OpaqueAPFloat(const llvm::APFloat& val) : apFloat(val){

  }
  OpaqueAPFloat(llvm::APFloat&& val) : apFloat(val){

  }
  llvm::APFloat apFloat;
};

APFloatRef LLVMExtAPFloatFromAPFloat(APFloatRef ap, APFloatSemantics semantics, int* status){
  bool losesInfo;
  llvm::APFloat res(ap->apFloat);
  int opStatus;

  switch (semantics) {
  case apSemIEEEhalf:
    opStatus = res.convert(llvm::APFloat::IEEEhalf(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
    break;
  case apSemIEEEsingle:
    opStatus = res.convert(llvm::APFloat::IEEEsingle(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
    break;
  case apSemIEEEdouble:
    opStatus = res.convert(llvm::APFloat::IEEEdouble(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
    break;
  case apSemIEEEquad:
    opStatus = res.convert(llvm::APFloat::IEEEquad(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
    break;
  case apSemPPCDoubleDouble:
    opStatus = res.convert(llvm::APFloat::PPCDoubleDouble(),
               llvm::APFloat::rmNearestTiesToEven,
               &losesInfo);
    break;
  case apSemx87DoubleExtended:
    opStatus = res.convert(llvm::APFloat::x87DoubleExtended(),
               llvm::APFloat::rmNearestTiesToEven,
               &losesInfo);
    break;
  case apSemBogus:
    opStatus = res.convert(llvm::APFloat::Bogus(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
    break;
  default:llvm_unreachable("should not get here!");
  }

  if(status)
    *status = opStatus;

  return new OpaqueAPFloat(std::move(res));
}

APFloatRef LLVMExtAPFloatZero(APFloatSemantics semantics) {
  switch (semantics) {
  case apSemIEEEhalf:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::IEEEhalf()));
  case apSemIEEEsingle:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::IEEEsingle()));
  case apSemIEEEdouble:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::IEEEdouble()));
  case apSemIEEEquad:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::IEEEquad()));
  case apSemPPCDoubleDouble:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::PPCDoubleDouble()));
  case apSemx87DoubleExtended:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::x87DoubleExtended()));
  case apSemBogus:
    return new OpaqueAPFloat(llvm::APFloat(llvm::APFloat::Bogus()));
  default:
    llvm_unreachable("should not get here!");
  }
}
APFloatRef LLVMExtAPFloatFromDouble(double d, APFloatSemantics semantics, int* status) {
  llvm::APFloat ap(d);
  bool losesInfo;
  int opStatus;

  if(semantics != apSemIEEEdouble) {
    switch (semantics) {
    case apSemIEEEhalf:
      opStatus = ap.convert(llvm::APFloat::IEEEhalf(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
      break;
    case apSemIEEEsingle:
      opStatus = ap.convert(llvm::APFloat::IEEEsingle(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
      break;
    case apSemIEEEquad:
      opStatus = ap.convert(llvm::APFloat::IEEEquad(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
      break;
    case apSemPPCDoubleDouble:
      opStatus = ap.convert(llvm::APFloat::PPCDoubleDouble(),
                 llvm::APFloat::rmNearestTiesToEven,
                 &losesInfo);
      break;
    case apSemx87DoubleExtended:
      opStatus = ap.convert(llvm::APFloat::x87DoubleExtended(),
                 llvm::APFloat::rmNearestTiesToEven,
                 &losesInfo);
      break;
    case apSemBogus:
      opStatus = ap.convert(llvm::APFloat::Bogus(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
      break;
    default:llvm_unreachable("should not get here!");
    }
  }

  if(status)
    *status = opStatus;

  return new OpaqueAPFloat(std::move(ap));
}
APFloatRef LLVMExtAPFloatFromFloat(float d, APFloatSemantics semantics, int* status) {
  return LLVMExtAPFloatFromDouble(d, semantics, status);
}
void LLVMExtAPFloatDispose(APFloatRef ap) {
  delete ap;
}
int LLVMExtAPFloatFromString(APFloatRef ap, const char *str, int roundingMode) {
  return ap->apFloat.convertFromString(str, (llvm::APFloat::roundingMode)roundingMode);
}
int LLVMExtAPFloatCompare(APFloatRef ap1, APFloatRef ap2) {
  return ap1->apFloat.compare(ap2->apFloat);
}
int LLVMExtAPFloatAdd(APFloatRef ap1, APFloatRef ap2, int roundingMode) {
  return ap1->apFloat.add(ap2->apFloat, (llvm::APFloat::roundingMode)roundingMode);
}
int LLVMExtAPFloatSub(APFloatRef ap1, APFloatRef ap2, int roundingMode) {
  return ap1->apFloat.subtract(ap2->apFloat, (llvm::APFloat::roundingMode)roundingMode);
}
int LLVMExtAPFloatMult(APFloatRef ap1, APFloatRef ap2, int roundingMode) {
  return ap1->apFloat.multiply(ap2->apFloat, (llvm::APFloat::roundingMode)roundingMode);
}
int LLVMExtAPFloatDiv(APFloatRef ap1, APFloatRef ap2, int roundingMode) {
  return ap1->apFloat.divide(ap2->apFloat, (llvm::APFloat::roundingMode)roundingMode);
}
int LLVMExtAPFloatRem(APFloatRef ap1, APFloatRef ap2) {
  return ap1->apFloat.remainder(ap2->apFloat);
}
int LLVMExtAPFloatMod(APFloatRef ap1, APFloatRef ap2) {
  return ap1->apFloat.mod(ap2->apFloat);
}
int LLVMExtAPFloatRound(APFloatRef ap, int roundingMode) {
  return ap->apFloat.roundToIntegral((llvm::APFloat::roundingMode)roundingMode);
}
double LLVMExtAPFloatToDouble(APFloatRef ap) {
  llvm::APFloat apFloat(ap->apFloat);
  bool losesInfo;
  apFloat.convert(llvm::APFloat::IEEEdouble(), llvm::APFloat::rmNearestTiesToEven, &losesInfo);
  return apFloat.convertToDouble();
}
float LLVMExtAPFloatToFloat(APFloatRef ap) {
  return LLVMExtAPFloatToDouble(ap);
}
void *LLVMExtAPFloatToValue(APFloatRef ap) {
  LLVMContextRef globalContext = LLVMGetGlobalContext();
  llvm::LLVMContext & C = *llvm::unwrap(globalContext);
  LLVMValueRef valueRef = llvm::wrap(llvm::ConstantFP::get(C, ap->apFloat));
  return valueRef;
}
bool LLVMExtAPFloatIsNegative(APFloatRef ap) {
  return ap->apFloat.isNegative();
}
bool LLVMExtAPFloatIsNormal(APFloatRef ap) {
  return ap->apFloat.isNormal();
}
bool LLVMExtAPFloatIsFinite(APFloatRef ap) {
  return ap->apFloat.isFinite();
}
bool LLVMExtAPFloatIsZero(APFloatRef ap) {
  return ap->apFloat.isZero();
}
bool LLVMExtAPFloatIsDenormal(APFloatRef ap) {
  return ap->apFloat.isDenormal();
}
bool LLVMExtAPFloatIsInfinity(APFloatRef ap) {
  return ap->apFloat.isInfinity();
}
bool LLVMExtAPFloatIsNaN(APFloatRef ap) {
  return ap->apFloat.isNaN();
}
bool LLVMExtAPFloatIsSignaling(APFloatRef ap) {
  return ap->apFloat.isSignaling();
}
