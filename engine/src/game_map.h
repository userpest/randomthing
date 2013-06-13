#pragma once
#include <GL/gl.h>
#include <GL/glu.h>
#include <vector>
#include <map>
#include <memory>
#include <string>
#include <memory>
#include "texture_loader.h"
#include "shapes.h"
#include "game_objects.h"
#include <iostream>
#include <cstdio>
#include "triggers.h"

const float TILE_WIDTH=40;
const float TILE_HEIGHT=40;

class Tile{
    private:
        Rectangle rect;
        std::shared_ptr<Texture> texture;
        float x,y;
        std::shared_ptr<Trigger> trigger;
    public:
        void set_trigger(std::shared_ptr<Trigger> _trigger){trigger=_trigger;};
        void activate_trigger();
        Tile(){};
        Tile(float _x, float _y):x(_x), y(_y){};
        Tile(float _x, float _y,std::shared_ptr<Texture>& _texture)
            :texture(_texture),x(_x), y(_y){};
        void show(){texture->set();rect.show(x,y);};
        void set_texture(const std::shared_ptr<Texture>& _texture){texture = _texture;};
        void set_coords(float _x, float _y){x=_x;y=_y;};
        void set_size(float width,float height){rect.resize(width,height);};
        bool collides(int _x , int _y){return texture->collides(_x,_y);};

};

//supposed to be short lived
class TileLoader{
    private:
        std::map<unsigned int, std::string > data;
        std::map<unsigned int, std::shared_ptr<Texture> > textures;
        void load_filenames(std::string& file);
        void load_textures(std::string& path);
    public:
        TileLoader(std::string path);
        const std::shared_ptr<Texture>& operator[](unsigned int id);
};

class GameMap{
    private:
        std::vector< std::vector< Tile > > tiles;
        Rectangle tile_rect;
        std::string map_name;
        void load_triggers();
        void load_creatures();


        Rectangle background;
        std::shared_ptr<Texture> background_img;
    public:
        std::string get_name(){return map_name;};
        unsigned int width,height;
        GameMap(){};
        GameMap(std::string& path){load(path);};
        void load(std::string& path, bool load_everything = true);
        void show();
        void save(FILE *fp);
        void load(FILE *fp);
        bool collides(int x,int y);
        bool collides(std::shared_ptr<GameObject>& obj);
        bool collides(GameObject* obj);
        void activate_trigger(std::shared_ptr<GameObject>& obj);


};

