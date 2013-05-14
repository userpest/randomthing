#pragma once
#include <GL/gl.h>
#include <map>
#include <string>
#include <memory>
#include "patterns.h"
#include <SDL/SDL.h>
#include <cstdio>
class Texture{
    private:
        GLuint texture;
        float width,height;
        SDL_Surface* surface;
    public:
        //in ogl coordinate system
        bool collides(int x,int y);
        Texture(std::string path);
        ~Texture(){printf("text destr %p\n", surface);glDeleteTextures(1,&texture);SDL_FreeSurface(surface);};
        inline void set(){glBindTexture(GL_TEXTURE_2D, texture);};

        float get_width(){return width;};
        float get_height(){return height;};

};

class TextureLoader: public Singleton<TextureLoader> {
    private:
        std::map<std::string,std::shared_ptr<Texture> > cache; 
    public:
        const std::shared_ptr<Texture>& operator[](std::string name); 

};
