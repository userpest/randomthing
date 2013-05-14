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
        int x,y;

        //dummy speed implementation there's rly no need for vectors i think
        int v_x=0;
        int v_y=0;
        //object hp when it drops below 0 object gets deleted
        int hp=1;
        //object dmg on inpact usefull for projectiles
        int dmg=1;
        bool touching_ground = false;
        bool facing_right = false;

        GameObject():current_animation(nullptr){};
        GameObject(Animation& anim){set_animation(anim);set_size();};

        void set_animation(Animation& anim){current_animation=&anim; current_animation->start();};
        void show(){ if(x>0) facing_right = true; if (x<0) facing_right = false; current_animation->show(x,y);};

        bool collides(int _x,int _y){return current_animation->collides(_x,_y);};

        //overload for some collision processing
        virtual void collision(){return;};

        //overload this to do some animation swapping and such stuff
        
        virtual void think(){return;};
        //virtual ~GameObject(){};

};

class Player: public GameObject{
    private:
        Animation move_left_a,move_right_a,jump_left_a,jump_right_a, stand_left_a, stand_right_a;

        void _shot();
    public:
        //Player(){};
        bool move_left=false;
        bool move_right = false;
        bool jump =false;
        bool shot=false;

        virtual void think(){return;};

};

class Npc:public GameObject{
    public:
        virtual void think();

};
