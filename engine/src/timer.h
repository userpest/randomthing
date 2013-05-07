#pragma once
#include <SDL/SDL.h>

class Timer{
    private:
        unsigned int start_time;
        unsigned int last_call_time;
    public:
        Timer(){
            restart();
        };
        void restart(){start_time = SDL_GetTicks();};
        unsigned int tslc(){
            unsigned int tmp;
            tmp = last_call_time;
            last_call_time = SDL_GetTicks();
            return SDL_GetTicks - tmp;
        };
        unsigned int tss(){last_call_time = SDL_GetTicks(); return SDL_GetTicks - start_time;}; 
};
