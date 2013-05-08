#include "helper.h"
#include <string>
#include <cstdio>
#include <errno.h>
#include <cstdlib>
#include <sstream>

bool file_exists(std::string& path){
    FILE * fp;
    fp = fopen(path.c_str(), "r");
    if(fp == NULL){
        return false;
    } else{
        fclose(fp);
        return true;
    }
}
std::FILE* fopen_or_die(std::string filename, std::string mode){
    std::FILE *fp; 
    fp = std::fopen(filename.c_str(), mode.c_str());
    if(fp == NULL){
        std::string fail = "failed opening "+filename;
        perror(fail.c_str());
        std::exit(1);
    }
    return fp;
}
std::string int_to_str(int num){
    std::stringstream ss;
    ss << num;
    return ss.str();
}
