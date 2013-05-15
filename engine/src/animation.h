#pragma once
#include <vector>
#include "texture_loader.h"
#include <string>
#include "shapes.h"
#include <memory>
#include "timer.h"

const unsigned int FRAME_TIME = 30;

class Animation{
    private:
        std::vector <std::shared_ptr<Texture> > frames;
        Rectangle rect;
        Timer animation_timer;
        unsigned int animation_loop_time;
        std::shared_ptr<Texture> current_frame;
    public:
        Animation(){};
        Animation(std::string& path);
        void load(std::string& path);
        void show(float x,float y);
        void start(){animation_timer.restart();};
        bool collides(int x,int y){return current_frame->collides(x,y);};
        int get_height(){return current_frame->get_height();};
        int get_width(){return current_frame->get_width();};
};

