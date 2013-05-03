#pragma once
#include <GL/gl.h>
#include <map>
#include <string>
#include <memory>


class Texture{
    private:
        GLuint texture;
        float width,height;
    public:
        Texture(std::string path);
        ~Texture(){glDeleteTextures(1,&texture);};
        inline void set();

        float get_width(){return width;};
        float get_height(){return height;};

};

class TextureLoader: public Singleton<TextureLoader>{
    private:
        std::map<std::string,std::shared_ptr<Texture> > cache; 
    public:
        const std::shared_ptr<Texture>& operator[](std::string name); 

};
