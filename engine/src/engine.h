#pragma once
#include <SDL/SDL.h>
#define SCREEN_WIDTH  640
#define SCREEN_HEIGHT 480
#define SCREEN_BPP     16


class Engine{
    private:
        int videoFlags;
        SDL_Surface *surface;
        void init_GL();
        void resize_window(int width, int height);
        void draw_scene();
        void handle_events();
        void handle_keyboard();
        void quit(int code);
        void handle_key_down( SDL_keysym *keysym );
        void handle_key_up( SDL_keysym *keysym );
    public:
        void init();
        void game_loop();

};
