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
    public:
        Animation(std::string& path);
        void show(float x,float y);
        void start(){timer.restart();};
};
