#pragma once
#include <SDL/SDL.h>
#define SCREEN_WIDTH  800
#define SCREEN_HEIGHT 600
#define SCREEN_BPP     16
#include "game_map.h"
#include "game_objects.h"
#include <vector>
#include "patterns.h"
#include <memory>

class Engine: public Singleton<Engine> {
    private:
        int videoFlags;
        SDL_Surface *surface;
        GameMap game_map; 
        std::vector <std::shared_ptr<GameObject> > objects;
        void init_GL();
        void resize_window(int width, int height);
        void draw_scene();
        void handle_events();
        void handle_keyboard();
        void quit(int code);
        void handle_key_down( SDL_keysym *keysym );
        void handle_key_up( SDL_keysym *keysym );
        void handle_movement();        
        void detect_collisions();
        void harvest_dead();
        void move_camera();
        bool objects_collide(std::shared_ptr<GameObject>& a, std::shared_ptr<GameObject>& b);

    public:
        std::shared_ptr<Player> player;

        void add_object(std::shared_ptr<GameObject>& obj){objects.push_back(obj);};
        void load_map(std::string path);
        bool can_move(GameObject* obj, int x, int y);
        void init();
        void game_loop();

};
