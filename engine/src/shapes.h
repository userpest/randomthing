#pragma once
#include "texture_loader.h"
class Rectangle{
    private:
        float width=1, height=1;
        float vertices[2*3*2];
//        float texture_coords[2*3*2] =  {1,0, 1,1, 0,1, 0,1, 0,0, 1,0 } ; 
        float texture_coords[2*3*2] =  {0,0, 0,1, 1,1, 1,1, 1,0, 0,0 } ; 





    public:
        Rectangle(){};
        Rectangle(float width, float height){resize(width,height);};
        void resize(float width, float height); 
        void show(float x, float y);
};
