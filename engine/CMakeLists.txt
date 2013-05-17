cmake_minimum_required (VERSION 2.6)
project (randomthing)

find_package ( SDL REQUIRED)
include_directories(${SDL_INCLUDE_DIRS})
link_directories(${SDL_LIBRARY_DIRS})
add_definitions(${SDL_DEFINITIONS})

find_package(OpenGL REQUIRED)
include_directories(${OpenGL_INCLUDE_DIRS})
link_directories(${OpenGL_LIBRARY_DIRS})


find_Package ( SDL_image REQUIRED )

add_definitions(${SDL_DEFINITIONS})

find_package( Boost COMPONENTS
                system
                thread 
                python3
                REQUIRED )
include_directories(${Boost_INCLUDE_DIRS})
link_directories(${Boost_LIBRARY_DIRS})

find_package(PythonLibs REQUIRED)
include_directories(${PYTHON_INCLUDE_DIRS})
link_directories(${PYTHON_LIBRARIES})


file(GLOB SOURCES src/*.cpp )
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11 -ggdb")

add_executable(thing ${SOURCES})
target_link_libraries(thing 
    ${OPENGL_LIBRARIES} 
    ${SDL_LIBRARY}  
    ${SDLIMAGE_LIBRARY}
    ${Boost_LIBRARIES}
    ${PYTHON_LIBRARIES}
    )
