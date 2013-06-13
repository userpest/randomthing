#pragma once
#include "animation.h"
#include <string>
#include <map>
#include <cstdio>
#include <memory>
#include "timer.h"
#include "helper.h"

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
        GameObject(Animation& anim){set_animation(&anim);
            set_size();};
        GameObject(int _x, int _y,Animation& anim): x(_x), y(_y){set_animation(&anim);};

        void set_animation(Animation* anim){current_animation=anim; 
            current_animation->start();
            set_size();
         };
        void show();
        
        bool collides(int _x,int _y){return current_animation->collides(_x,_y);};

        //overload for some collision processing
        virtual void collision(){return;};
        virtual void changed_direction(){return;};
        //overload this to do some animation swapping and such stuff
        
        virtual void think(){return;};
        //virtual ~GameObject(){};
        virtual void save(FILE* fp);
        virtual void load(FILE* fp);
};

std::shared_ptr<GameObject> load_creature(std::string name, int x, int y);
//loads creature with a given name and its starting coords
class Player: public GameObject{ 
    private: 
            Animation left,right; 
             void _shot(); 
             bool direction;
             Timer shoting_timer;
    public: 
        Player(int _x,int _y); 
        Player():Player(10,10){}; 
        bool move_left=false;
        bool move_right = false;
        bool jump =false;
        bool shot=false;

        virtual void think();
        virtual void changed_direction();
        virtual void load(FILE* fp);

};

class TestCreature: public GameObject{
    private:
        Animation anim;
        std::string name;
    public:
        TestCreature(int _x,int _y){
            name = "test";
            x=_x;
            y=_y;
            dmg = 10;
            anim.load("blue_square/");
            set_animation(&anim);
        };
        virtual void think(){
            v_x=10;
        };
        virtual void save(FILE *fp){
            save_string(fp,name);
            GameObject::save(fp);
        }
};
class Bullet: public GameObject{
    private:
        Animation anim;
        std::string name;
    public:
        Bullet(int _x,int _y,int v){
            //rly this could be more memory efficient
            name = "bullet";
            x=_x;
            y=_y;
            v_x=v;
            v_y = 0;
            dmg = 10;
            anim.load("creatures/bullet/");
            set_animation(&anim);
        };

        virtual void think(){
            if(v_x ==0 )
                hp = -1 ;

            v_y=1; 
        };

        virtual void collision(){
            hp = -1 ; 
        };
        virtual void save(FILE *fp){
            save_string(fp,name);
            GameObject::save(fp);
        }
        virtual void load(FILE *fp){
            GameObject::load(fp);
        };

};
