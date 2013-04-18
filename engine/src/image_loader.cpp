#include <map>
#include <string>
#include <SDL/SDL.h>
#include <SDL/SDL_image.h>
#include <cstdio>
#include "image_loader.h"

SDL_Surface* ImageLoader::operator[](string name){
    std::map<string,SDL_Surface*>::iterator i;
    i = imgs.find(name)

    if( i != imgs.end()){
        return *i;
    }else{
        SDL_Surface * image;
        image=IMG_Load(name.c_str());
        if(!image) {
            std::printf("IMG_Load: %s\n", IMG_GetError());
                //handle error like a boss eh
                exit(1);
        }
        imgs[name]=image;
        return image;
    }

}

ImageLoader::~ImageLoader(){
    for(std::map<string,SDL_Surface *>::iterator i = imgs.begin();i!=imgs.end();i++){
        delete i->second; 
    }    
}
