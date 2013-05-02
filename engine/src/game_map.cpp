#include "game_map.h"
#include <errno.h>
#include <string>
#include <map>
#include <cstdlib>
using namespace std;


void map_error(){
    perror("error while loading map");
    std::exit(1); 
}
void GameMap::load(string& path){
    FILE* fp;
    string name;
    name = path+"map";
    fp = fopen(name.c_str(), "rb");
    if(fp == NULL){
        map_error();
    }
    if(fread(&width,sizeof(width),1,fp) < sizeof(width)){
        map_error();
    }
    if(fread(&height,sizeof(height),1,fp)<sizeof(height)){
        map_error();
    }

    tiles.resize(width);

    for(int i = 0; i<width;i++){
        unsigned short int tile_id;
        tiles[i].resize(height);
        for(int j =0 ; j < height; j++){
            if(fread(&tile_id,sizeof(tile_id),1,fp)<sizeof(tile_id)){
                map_error();
            }
           // tiles[i][j].set(i,j,t_loader[tile_id]);
        }
    }
}
