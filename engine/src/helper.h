#pragma once
#include <string>
#include <cstdio>
bool file_exists(std::string& path);
std::FILE* fopen_or_die(std::string filename, std::string mode);
std::string int_to_str(int num);
bool exist(std::string path);
std::string get_path(std::string map_path, std::string object_name);
template <typename T> int sgn(T val)
{
        return (T(0) < val) - (val < T(0));
};

void save_string(FILE* fp, std::string str);
std::string load_string(FILE* fp);
void save_bool(FILE*fp, bool val);
void load_bool(FILE*fp, bool& val);
