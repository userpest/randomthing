#include "game_map.h"
#include "helper.h"
#include "shapes.h"
#include <errno.h>
#include <string>
#include <map>
#include <cstdlib>
#include <cstdio>
#include <cmath>
using namespace std;
void TileLoader::load_filenames(std::string& file){
   FILE* fp; 
    if ( (fp = fopen(file.c_str(),"r")) ==NULL){
        perror("loading tiles.txt");
        exit(1);
    }
    unsigned int id;
    char filename[200];
    while(fscanf(fp, "%u %200s", &id, filename)==2){
           data[id]=std::string(filename);
    }
}

void TileLoader::load_textures(std::string& path){
    FILE* fp;
    auto& t_loader = TextureLoader::get_instance();
    for(auto& i: data){
        unsigned int id = i.first;
        std::string name = i.second;
        std::string local_name = path+"tiles/"+name;
        std::string global_name = "./tiles/"+name;
        if ( file_exists(local_name)){
            textures[id] = t_loader[local_name];
        }else if (file_exists(global_name)){
            textures[id] = t_loader[global_name];
        }else{
            fprintf(stderr,"cannot load required tile %s\n", name.c_str());
            exit(1);
        }
    }    
}

TileLoader::TileLoader(std::string path){
    std::string local = path+"tiles.txt";
    std::string main = "./tiles.txt";
    load_filenames(main);
    load_filenames(local);
    load_textures(path);
}
const std::shared_ptr<Texture>& TileLoader::operator[](unsigned int id){
    return textures[id]; 
}

void map_error(){
    perror("error while loading map");
    std::exit(1); 
}
void GameMap::show(){
    for(auto& i: tiles){
        for(auto& j:i){
            j.show();
        }
    }
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
    TileLoader t_loader(path);
    for(int i = 0; i<width;i++){
        unsigned short int tile_id;
        tiles[i].resize(height);
        for(int j =0 ; j < height; j++){
            if(fread(&tile_id,sizeof(tile_id),1,fp)<sizeof(tile_id)){
                map_error();
            }
            Tile& t=tiles[i][j];
            t.set_size(TILE_WIDTH,TILE_HEIGHT);
            t.set_texture(t_loader[tile_id]);
            t.set_coords(i*TILE_WIDTH,j*TILE_HEIGHT);
        }
    }
}
bool GameMap::collides(int x, int y){
    int tilex = std::floor(x/TILE_WIDTH);
    int tiley = std::floor(y/TILE_HEIGHT); 
    x-=tilex*TILE_WIDTH;
    y-=tiley*TILE_HEIGHT;
    return tiles[tilex][tiley].collides(x,y);
}
