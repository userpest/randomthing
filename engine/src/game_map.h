#pragma once
#include <GL/gl.h>
#include <GL/glu.h>
#include <vector>
#include <map>
#include <vector>

class Tile{
    private:
        float x,y;
        Gluint handle;
    public:
        set(float x, float y , GLuint handle){this->x=x;this->y=y;this->handle=handle;};
        void show();

};

class GameMap{
    private:
        std::vector<vector<Tile> > tiles;
        TextureLoader t_loader;
        unsigned int width,height;
        map <unsigned short int id, Gluint handle>;
    public:
        GameMap(string path);
        void load(string path);
        show();

};
