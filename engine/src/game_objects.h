#pragma once
#include "animation.h"
#include <string>
#include <map>
#include <boost/python/tuple.hpp>
#include <boost/make_shared.hpp>
#include <boost/python.hpp>
#include <boost/python/ptr.hpp>
#include <cstdio>

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

class Player: public GameObject{ 
    private: 
            Animation left,right; 
             void _shot(); 
             bool direction;
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

class Creature:public GameObject{
    private:
        std::map <std::string , std::shared_ptr<Animation> > animations;
        PyThreadState* py_interpreter;
        boost::python::object script_think;
        boost::python::object script_collision;
        std::string map_path;
        std::string creature_name;
        //to be called only once per object lifetime
        void load(std::string name, std::string path);
        std::string animation_name;
    public:
        virtual void think();
        virtual void collision();
        void set_current_animation(std::string name);
        bool can_move(int x, int y);
        void move(int x,int y);
        void add_object(std::string name, int x, int y);
        boost::python::tuple get_player_pos();
        
        Creature(std::string name,std::string map_path);
        Creature(){};
        ~Creature();

        virtual void save(FILE* fp);
        virtual void load(FILE* fp);
};

