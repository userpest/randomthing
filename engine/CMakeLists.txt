cmake_minimum_required (VERSION 2.6)
project (randomthing)

Find_Package ( SD REQUIRED)
set (
    SOURCES
    thing.cpp    
    )
add_executable(thing thing.cpp)
