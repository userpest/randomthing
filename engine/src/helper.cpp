#include "helper.h"
#include <string>
#include <cstdio>
#include <errno.h>
#include <cstdlib>
#include <sstream>
#include <unistd.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <iostream>

using namespace std;
bool exist(std::string path){
    struct stat info;
    if ( stat(path.c_str(), &info) == 0){
        return true;
    }else{
        return false;
    }
}

std::string get_path(std::string map_path, std::string object_name){
    std::string path = map_path + object_name;
    std::string alternative_path = "./"+object_name;
    if(exist(path)){
        return path;
    }else if(exist(alternative_path)){
        return alternative_path;
    }else{
        std::cerr<<"cannot find object: "<<object_name<<std::endl;
        exit(1);
    }
}

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

std::string load_string(FILE *fp){
    string str;
    char data[200];
    fscanf(fp, "%s",data);

    return string(data);
}

void save_string(FILE *fp, std::string str){
    fprintf(fp,"%s\n", str.c_str());
}

void save_bool(FILE*fp, bool val){
    int v = val ? 1:0;
    fprintf(fp, "%d\n", v);
}

void load_bool(FILE*fp, bool& val){
    int v;
    fscanf(fp, "%d", &v);
    val =  v>0;

}
