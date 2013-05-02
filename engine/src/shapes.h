#pragma once
#include "texture_loader.h"
class Rectangle{
    private:
        float width, height;
        float vertices[2*3*2];
        float texture_coords[] =  {0,1, 0,0, 1,0, 1,0, 1,1, 0,1} ; 

    public:
        Rectangle(float width, float height){resize(width,height);};
        void resize(float width, float height); 
        void show(float x, float y);
};
