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
#include "engine.h"

using namespace std;
void Tile::activate_trigger(){
    if(trigger.get() != nullptr){
        trigger->activate();
    }

};

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
    std::string local = "maps/"+path+"tiles.txt";
    std::string main = "./tiles.txt";
    load_filenames(main);
    load_filenames(local);
    path = "maps/"+path;
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
    glPushMatrix(); 
    glLoadIdentity(); 
    background_img->set(); 
 
    background.show(0,0); 

    glPopMatrix(); 
    for(auto& i: tiles){
        for(auto& j:i){
            j.show();
        }
    }
}
void GameMap::load(string& path, bool load_everything ){
    map_name = path+"/";
    FILE* fp;
    string name;

    path = path + '/';
    name = "maps/"+path+"map";
    fp = fopen(name.c_str(), "r");
    if(fp == NULL){
        map_error();
    }
    //read map size
    fscanf(fp, "%d %d %d %d", &width,&height,&player_x,&player_y);

    background.resize(SCREEN_WIDTH,SCREEN_HEIGHT);

    auto& textures_loader = TextureLoader::get_instance();
    std::string bg_name= "maps/"+path+"/background.png";
    background_img = textures_loader[bg_name];
    //load tile textures
    TileLoader t_loader(path);

    tiles.resize(width);
    for(int i = 0 ; i < width;i++){    
        tiles[i].resize(height);
    }
    //read tiles
    //printf("%d %d\n", width,height);
    puts("##########################");
    for(int j = 0; j<height;j++){
        int tile_id;
        for(int i =0 ; i < width; i++){
            if(fscanf(fp,"%d", &tile_id)<1){
                map_error();
            }
            printf("%d ", tile_id); 
            Tile& t=tiles[i][j];
            t.set_size(TILE_WIDTH,TILE_HEIGHT);
            t.set_texture(t_loader[tile_id]);
            t.set_coords(i*TILE_WIDTH,j*TILE_HEIGHT);
        }
        puts("");
    }
    puts("#########################");
    height = height*TILE_HEIGHT;
    width = width *TILE_WIDTH;
    load_triggers();    
    if(load_everything){
        load_creatures();
    }

}
bool GameMap::collides(int x, int y){

    if( x < 0 || y < 0 || x >= width || y >= height)
        return true;
    int w = (int)TILE_WIDTH;
    int h = (int)TILE_HEIGHT;
    int tilex = (x-x%w)/w;
    int tiley = (y-y%h)/h; 
    x-=tilex*w;
    y-=tiley*h;
    return tiles[tilex][tiley].collides(x,y);
}

bool GameMap::collides(std::shared_ptr<GameObject>& obj){
    return collides(obj.get());
}
bool GameMap::collides(GameObject* obj){
    for(int i = 0 ; i < obj->width;i++){
        for(int j=0 ; j < obj->height;j++){
            if(collides(obj->x+i,obj->y+j) && obj->collides(i,j)){
                return true;
            }
        }
    }
    return false;
}
void GameMap::save(FILE *fp){
    save_string(fp, map_name);
};

void GameMap::load(FILE *fp){
    string name= load_string(fp);
    load(name,false);
};

void GameMap::load_triggers(){
    std::string path = "maps/"+map_name+"/triggers.txt";
    FILE* fp;
    fp = fopen(path.c_str(), "r");
    if(fp == NULL){
        cerr<<"cant find triggers.txt for map exiting"<<endl;
        cout<<map_name;
        exit(1);
    }

    int x,y,type;
    int spawn_x,spawn_y;
    char name[200];

    string testing;
    shared_ptr<Trigger> ptr ;
    while(fscanf(fp, "%d %d %d", &type,&x,&y) == 3){
        switch(type){
            case 0 : 
                fscanf(fp, "%d %d %s", &spawn_x, &spawn_y, name);
                ptr = shared_ptr<MapConnectingTrigger>(new MapConnectingTrigger(name,spawn_x, spawn_y));
                tiles[x][y].set_trigger(ptr);
                break;
            case 1:
                int activation_count, cooldown;
                fscanf(fp, "%d %d %s %d %d", &activation_count, &cooldown, name ,&spawn_x,&spawn_y);
                ptr = shared_ptr<SpawningTrigger>(new SpawningTrigger(spawn_x,spawn_y,name,activation_count,cooldown));
                break;
            default:
                cerr<<"cannot determine type"<<type<<endl;
                exit(1);
                break;

        };
        tiles[x][y].set_trigger(ptr);
    }

    fclose(fp);

}
void GameMap::load_creatures(){
    char name[200];
    FILE* fp;
    string path = "maps/"+map_name+"/creatures.txt";
    fp = fopen(path.c_str(), "r");
    if(fp == NULL){
        cerr<<"cant find creatures.txt for map exiting"<<endl;
        cout<<path;
        exit(1);
    }

    auto& eng = Engine::get_instance();
    int x,y;
    while(fscanf(fp,"%d %d %s", &x, &y,name)==3){
        shared_ptr<GameObject> ptr =  load_creature(name, x,y);
        eng.add_object(ptr);
    } 
    fclose(fp);
};

void GameMap::activate_trigger(shared_ptr<Player>& obj){
    int tilex = (obj->x-obj->x%(int)TILE_WIDTH)/(int)TILE_WIDTH;
    int tiley = (obj->y-obj->y%(int)TILE_HEIGHT)/(int)TILE_HEIGHT;
    tiles[tilex][tiley].activate_trigger();
}
