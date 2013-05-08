#pragma once
#include <string>
#include <cstdio>
bool file_exists(std::string& path);
std::FILE* fopen_or_die(std::string filename, std::string mode);
std::string int_to_str(int num);
