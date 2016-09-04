cmake_minimum_required(VERSION 3.6)
project(ivy)

#LLVM Libraries
add_library(LLVMSupport STATIC IMPORTED)
set_property(TARGET LLVMSupport PROPERTY IMPORTED_LOCATION "/usr/local/lib/libLLVMSupport.a")

#Packages
find_package(Curses REQUIRED)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++14")
set(SOURCE_FILES src/Diagnostics/DiagMessage.cpp
                 src/Driver/Main.cpp src/Basic/SourceLocation.cpp)

add_executable(ivyc ${SOURCE_FILES})
target_include_directories(ivyc PRIVATE include)
#Link to Packaged Libraries
target_link_libraries(ivyc PRIVATE ${CURSES_LIBRARIES})
#Link to LLVM Libraries
target_link_libraries(ivyc PRIVATE LLVMSupport)