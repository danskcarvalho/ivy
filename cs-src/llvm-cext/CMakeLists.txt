cmake_minimum_required(VERSION 3.6)
project(llvm_cext)

#LLVM Libraries
add_library(LLVMLib SHARED IMPORTED)
set_property(TARGET LLVMLib PROPERTY IMPORTED_LOCATION "/usr/local/lib/libLLVM.dylib")

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

set(SOURCE_FILES CExtensions.cpp CExtensions.h)
add_library(llvm_cext SHARED ${SOURCE_FILES})
target_include_directories(llvm_cext PRIVATE /usr/local/include)
#Link to LLVM Libraries
target_link_libraries(llvm_cext PRIVATE LLVMLib)