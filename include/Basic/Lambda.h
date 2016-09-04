//=- Basic/Lambda.h - Helper Macros for Lambda -*- C++ -*-=====================//
//
//                               Ivy Compiler
//
// This file is distributed under the Open Source License.
// See LICENSE.TXT for details.
//
//===----------------------------------------------------------------------===//
//
// This file contains macros to use lambda more concisely.
//
//===----------------------------------------------------------------------===//

#ifndef IVY_BASIC_LAMBDA
#define IVY_BASIC_LAMBDA
#define IVY_BASIC_LAMBDA_NARG(...)  \
        IVY_BASIC_LAMBDA_NARG_(__VA_ARGS__, IVY_BASIC_LAMBDA_RSEQ_N())
#define IVY_BASIC_LAMBDA_NARG_(...) \
        IVY_BASIC_LAMBDA_ARG_N(__VA_ARGS__)
#define IVY_BASIC_LAMBDA_ARG_N(                   \
        _1, _2, _3, _4, _5, _6, _7, _8, _9,_10,   \
        _11,_12,_13,_14,_15,_16,_17,_18,_19,_20,  \
        _21,_22,_23,_24,_25,_26,_27,_28,_29,_30,  \
        _31,_32,_33,_34,_35,_36,_37,_38,_39,_40,  \
        _41,_42,_43,_44,_45,_46,_47,_48,_49,_50,  \
        _51,_52,_53,_54,_55,_56,_57,_58,_59,_60,  \
        _61,_62,_63,N,...) N
#define IVY_BASIC_LAMBDA_RSEQ_N()       \
        63,62,61,60,                    \
        59,58,57,56,55,54,53,52,51,50,  \
        49,48,47,46,45,44,43,42,41,40,  \
        39,38,37,36,35,34,33,32,31,30,  \
        29,28,27,26,25,24,23,22,21,20,  \
        19,18,17,16,15,14,13,12,11,10,  \
        9,8,7,6,5,4,3,2,1,0

#define IVY_BASIC_LAMBDA_CAT(A, B)              A ## B
#define IVY_BASIC_LAMBDA_SELECT(NAME, NUM)      IVY_BASIC_LAMBDA_CAT(NAME, NUM)
#define IVY_BASIC_LAMBDA_VA_SELECT(NAME, ...)   IVY_BASIC_LAMBDA_SELECT(NAME, IVY_BASIC_LAMBDA_NARG(__VA_ARGS__))(__VA_ARGS__)

#define IvyLambda_1(P0)                                           ([&](){return (P0);})
#define IvyLambda_2(P0, P1)                                       ([&](P0){return (P1);})
#define IvyLambda_3(P0, P1, P2)                                   ([&](P0, P1){return (P2);})
#define IvyLambda_4(P0, P1, P2, P3)                               ([&](P0, P1, P2){return (P3);})
#define IvyLambda_5(P0, P1, P2, P3, P4)                           ([&](P0, P1, P2, P3){return (P4);})
#define IvyLambda_6(P0, P1, P2, P3, P4, P5)                       ([&](P0, P1, P2, P3, P4){return (P5);})
#define IvyLambda_7(P0, P1, P2, P3, P4, P5, P6)                   ([&](P0, P1, P2, P3, P4, P5){return (P6);})
#define IvyLambda_8(P0, P1, P2, P3, P4, P5, P6, P7)               ([&](P0, P1, P2, P3, P4, P5, P6){return (P7);})
#define IvyLambda_9(P0, P1, P2, P3, P4, P5, P6, P7, P8)           ([&](P0, P1, P2, P3, P4, P5, P6, P7){return (P8);})
#define IvyLambda_10(P0, P1, P2, P3, P4, P5, P6, P7, P8, P9)      ([&](P0, P1, P2, P3, P4, P5, P6, P7, P8){return (P9);})

#define IvyGenLambda_1(P0)                                        ([&](){return (P0);})
#define IvyGenLambda_2(P0, P1)                                    ([&](const auto& P0){return (P1);})
#define IvyGenLambda_3(P0, P1, P2)                                ([&](const auto& P0, const auto& P1){return (P2);})
#define IvyGenLambda_4(P0, P1, P2, P3)                            ([&](const auto& P0, const auto& P1, const auto& P2){return (P3);})
#define IvyGenLambda_5(P0, P1, P2, P3, P4)                        ([&](const auto& P0, const auto& P1, const auto& P2, const auto& P3){return (P4);})
#define IvyGenLambda_6(P0, P1, P2, P3, P4, P5)                    ([&](const auto& P0, const auto& P1, const auto& P2, const auto& P3, const auto& P4){return (P5);})
#define IvyGenLambda_7(P0, P1, P2, P3, P4, P5, P6)                ([&](const auto& P0, const auto& P1, const auto& P2, const auto& P3, const auto& P4, const auto& P5){return (P6);})
#define IvyGenLambda_8(P0, P1, P2, P3, P4, P5, P6, P7)            ([&](const auto& P0, const auto& P1, const auto& P2, const auto& P3, const auto& P4, const auto& P5, const auto& P6){return (P7);})
#define IvyGenLambda_9(P0, P1, P2, P3, P4, P5, P6, P7, P8)        ([&](const auto& P0, const auto& P1, const auto& P2, const auto& P3, const auto& P4, const auto& P5, const auto& P6, const auto& P7){return (P8);})
#define IvyGenLambda_10(P0, P1, P2, P3, P4, P5, P6, P7, P8, P9)   ([&](const auto& P0, const auto& P1, const auto& P2, const auto& P3, const auto& P4, const auto& P5, const auto& P6, const auto& P7, const auto& P8){return (P9);})

#define IvyLambda(...)     IVY_BASIC_LAMBDA_VA_SELECT(IvyLambda_, __VA_ARGS__)
#define IvyGenLambda(...)  IVY_BASIC_LAMBDA_VA_SELECT(IvyGenLambda_, __VA_ARGS__)
#endif
