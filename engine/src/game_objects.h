#pragma once
#include "animation.h"
#include <string>

//ugly eh
class GameObject{
    private:
        
        Animation *current_animation;
        void set_size(){width = current_animation->get_width(); height = current_animation->get_height();};
        
    public:
        int height,width;
        int x=0,y=0;

        //dummy speed implementation there's rly no need for vectors i think
        int v_x=0;
        int v_y=0;
        //object hp when it drops below 0 object gets deleted
        int hp=1;
        //object dmg on inpact usefull for projectiles
        int dmg=1;
        bool touching_ground = false;
        bool facing_right = true;

        GameObject(){};
        GameObject(Animation& anim){set_animation(anim);
            set_size();};
        GameObject(int _x, int _y,Animation& anim): x(_x), y(_y){set_animation(anim);};

        void set_animation(Animation& anim){current_animation=&anim; 
            current_animation->start();
            set_size();};
        void show();
        
        bool collides(int _x,int _y){return current_animation->collides(_x,_y);};

        //overload for some collision processing
        virtual void collision(){return;};
        virtual void changed_direction(){return;};
        //overload this to do some animation swapping and such stuff
        
        virtual void think(){return;};
        //virtual ~GameObject(){};

};

class Player: public GameObject{
    private:
        Animation left,right;
        bool last_direction=true;
        void _shot();
    public:
        //Player(){};
        Player(int _x,int _y); 
        bool move_left=false;
        bool move_right = false;
        bool jump =false;
        bool shot=false;

        virtual void think();
        virtual void changed_direction();

};

class Npc:public GameObject{
    public:
        virtual void think();

};
