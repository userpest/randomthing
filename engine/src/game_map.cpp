#include "game_map.h"
#include "helper.h"
#include "shapes.h"
#include <errno.h>
#include <string>
#include <map>
#include <cstdlib>
#include <cstdio>
#include <cmath>
#include <iostream>
#include "helper.h"

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

    auto& t_loader = TextureLoader::get_instance();
    for(auto& i: data){
        unsigned int id = i.first;
        std::string name ="tiles/"+i.second;
        std::string file_path = get_path(path,name);
        textures[id] = t_loader[file_path];
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
    //read map size
    if(fread(&width,sizeof(width),1,fp) < 1){
        map_error();
    }
    if(fread(&height,sizeof(height),1,fp)< 1){
        map_error();
    }

    //load tile textures
    TileLoader t_loader(path);

    tiles.resize(width);
    for(int i = 0 ; i < width;i++){    
        tiles[i].resize(height);
    }
    //read tiles
    for(int j = 0; j<height;j++){
        unsigned short int tile_id;
        for(int i =0 ; i < width; i++){
            if(fread(&tile_id,sizeof(tile_id),1,fp)<1){
                map_error();
            }

            Tile& t=tiles[i][j];
            t.set_size(TILE_WIDTH,TILE_HEIGHT);
            t.set_texture(t_loader[tile_id]);
            t.set_coords(i*TILE_WIDTH,j*TILE_HEIGHT);
        }
    }
    height = height*TILE_HEIGHT;
    width = width *TILE_WIDTH;

}
bool GameMap::collides(int x, int y){

    if( x < 0 || y < 0 || x > width || y > height)
        return true;

    int tilex = std::floor(x/TILE_WIDTH);
    int tiley = std::floor(y/TILE_HEIGHT); 
    x-=tilex*TILE_WIDTH;
    y-=tiley*TILE_HEIGHT;
    return tiles[tilex][tiley].collides(x,y);
}

bool GameMap::collides(GameObject& obj){
    for(int i = 0 ; i < obj.width;i++){
        for(int j=0 ; j < obj.height;j++){
            if(collides(obj.x+i,obj.y+j)){
                return true;
            }
        }
    }
    return false;
}
