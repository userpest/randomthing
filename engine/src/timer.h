#pragma once
#include <SDL/SDL.h>

class Timer{
    private:
        unsigned int start_time;
        unsigned int last_call_time;
    public:
        Timer(bool activate= true){
            if (activate){
                restart();
            }else{
               start_time=0; 
            }
        };
        void restart(){start_time = SDL_GetTicks();};
        unsigned int tslc(){
            unsigned int tmp;
            tmp = last_call_time;
            last_call_time = SDL_GetTicks();
            return SDL_GetTicks() - tmp;
        };
        unsigned int time_since_last_save() const{
            return SDL_GetTicks()- last_call_time; 
        };
        void save(){
            last_call_time = SDL_GetTicks();

        };
        unsigned int tss(){
            last_call_time = SDL_GetTicks();
            return SDL_GetTicks() - start_time;
        }; 
};
