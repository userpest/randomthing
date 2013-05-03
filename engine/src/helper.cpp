#include "helper.h"
#include <string>
#include <cstdio>

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
