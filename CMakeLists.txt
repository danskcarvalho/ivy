cmake_minimum_required(VERSION 3.6)
project(ivy)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

set(SOURCE_FILES src/Diagnostics/DiagMessage.cpp
                 src/Driver/Main.cpp)
add_executable(ivyc ${SOURCE_FILES})
target_include_directories(ivyc PRIVATE include)