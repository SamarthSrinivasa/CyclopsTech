cmake_minimum_required(VERSION 3.10)
project(DualCamera)

# Find OpenCV package
find_package(OpenCV REQUIRED)

# Include OpenCV headers
include_directories(${OpenCV_INCLUDE_DIRS})

# Add the executable
add_executable(DualCamera main.cpp)

# Link OpenCV libraries to the executable
target_link_libraries(DualCamera ${OpenCV_LIBS})