#pragma once
#include "timer.h"
#include <string>

class Trigger{
    public:
        virtual void activate()=0;
        virtual ~Trigger(){};

};

class MapConnectingTrigger:public Trigger{
    private:
        std::string map_name;
        int player_x, player_y;
    public:
        MapConnectingTrigger(std::string _map_name, int x,int y ): map_name(_map_name),player_x(x), player_y(y){};
        virtual void activate();

};

class SpawningTrigger: public Trigger{
    private:
        int cooldown;
        int x_spawn;
        int y_spawn;
        int activation_count;
        Timer timer;
        std::string creature_name;
    public:
        SpawningTrigger(int x,int y, std::string _creature_name, int _activation_count,int _cooldown):
    cooldown(_cooldown),activation_count(_activation_count),timer(false),x_spawn(x), y_spawn(y),creature_name(_creature_name){};
        virtual void activate();

};
