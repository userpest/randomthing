cmake_minimum_required (VERSION 2.6)
project (randomthing)

find_package ( SDL REQUIRED)
include_directories(${SDL_INCLUDE_DIRS})
link_directories(${SDL_LIBRARY_DIRS})
add_definitions(${SDL_DEFINITIONS})
find_package(OpenGL REQUIRED)

include_directories(${OpenGL_INCLUDE_DIRS})
link_directories(${OpenGL_LIBRARY_DIRS})
add_definitions(${SDL_DEFINITIONS})


set (
    SOURCES
    src/thing.cpp    
    )
add_executable(thing ${SOURCES})
target_link_libraries(thing ${OPENGL_LIBRARIES} ${SDL_LIBRARY})
