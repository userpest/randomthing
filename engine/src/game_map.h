#pragma once
#include <GL/gl.h>
#include <GL/glu.h>
#include <vector>
#include <map>
#include <memory>
#include <string>

#include "texture_loader.h"

class Tile{
    private:
        Rectangle& rect;
        std::shared_ptr<Texture> texture;
        float x,y;
    public:
        Tile(float _x, float _y,Rectangle& _r, shared_ptr<Texture>& _texture)
            :rect(_r),texture(_texture),x(_x), y(_y){};
        void show(){texture->set();rect.show(x,y);};

};



class GameMap{
    private:
        std::vector< std::vector< Tile > > tiles;
        unsigned int width,height;
    public:
        GameMap(std::string& path){load(path);};
        void load(std::string& path);
        void show();

};

