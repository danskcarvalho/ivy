#ifndef LLVM_CEXT
#define LLVM_CEXT

class  OpaqueAPFloat;
typedef OpaqueAPFloat* APFloatRef;

enum APFloatSemantics : int {
  apSemIEEEhalf = 0,
  apSemIEEEsingle = 1,
  apSemIEEEdouble = 2,
  apSemIEEEquad = 3,
  apSemPPCDoubleDouble = 4,
  apSemx87DoubleExtended = 5,
  apSemBogus = 6
};

extern "C" {

APFloatRef LLVMExtAPFloatZero(APFloatSemantics semantics);
APFloatRef LLVMExtAPFloatFromAPFloat(APFloatRef ap, APFloatSemantics semantics, int* status);
APFloatRef  LLVMExtAPFloatFromDouble(double d, APFloatSemantics semantics, int* status);
APFloatRef  LLVMExtAPFloatFromFloat(float d, APFloatSemantics semantics, int* status);
void LLVMExtAPFloatDispose(APFloatRef ap);
int LLVMExtAPFloatFromString(APFloatRef ap, const char* str, int roundingMode);

int LLVMExtAPFloatCompare(APFloatRef ap1, APFloatRef ap2);

int LLVMExtAPFloatAdd(APFloatRef ap1, APFloatRef ap2, int roundingMode);
int LLVMExtAPFloatSub(APFloatRef ap1, APFloatRef ap2, int roundingMode);
int LLVMExtAPFloatMult(APFloatRef ap1, APFloatRef ap2, int roundingMode);
int LLVMExtAPFloatDiv(APFloatRef ap1, APFloatRef ap2, int roundingMode);
int LLVMExtAPFloatRem(APFloatRef ap1, APFloatRef ap2);
int LLVMExtAPFloatMod(APFloatRef ap1, APFloatRef ap2);
int LLVMExtAPFloatRound(APFloatRef ap, int roundingMode);

double LLVMExtAPFloatToDouble(APFloatRef ap);
float LLVMExtAPFloatToFloat(APFloatRef ap);
void* LLVMExtAPFloatToValue(APFloatRef ap);

bool LLVMExtAPFloatIsNegative(APFloatRef ap);
bool LLVMExtAPFloatIsNormal(APFloatRef ap);
bool LLVMExtAPFloatIsFinite(APFloatRef ap);
bool LLVMExtAPFloatIsZero(APFloatRef ap);
bool LLVMExtAPFloatIsDenormal(APFloatRef ap);
bool LLVMExtAPFloatIsInfinity(APFloatRef ap);
bool LLVMExtAPFloatIsNaN(APFloatRef ap);
bool LLVMExtAPFloatIsSignaling(APFloatRef ap);

}

#endif //LLVM_CEXT
