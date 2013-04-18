#pragma once
#include <SDL/SDL.h>
#include <string>
#include "patterns.h"

class ImageLoader: public Singleton<ImageLoader> {
    private:
        std::map<std::string, SDL_Surface *> imgs;
    public:
        SDL_Surface* operator[](string name);
        ~ImageLoader();
};
