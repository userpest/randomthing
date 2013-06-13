#include "game_objects.h"
#include <iostream>
#include <cstdlib>
#include <iterator>
#include "helper.h"
#include <errno.h>
#include <dirent.h>
#include "animation.h"
#include "engine.h"
#include <cstring>

using namespace std;

std::shared_ptr<GameObject> load_creature(std::string name, int x, int y){
    printf("loading %s #\n", name.c_str());
    shared_ptr<GameObject> ptr;
    if(strcmp(name.c_str(),"test")==0){
        puts("test_creature");
        ptr = shared_ptr<GameObject>(new TestCreature(x,y));
    }  
    if(strcmp(name.c_str(),"bullet")==0){
        ptr = shared_ptr<Bullet>(new Bullet(x,y,0));
    }
    
    return ptr;
    
}



Player::Player(int _x , int _y){
    x = _x;
    y = _y;
    right.load("blue_square/");
    left.load("red_square/");
    set_animation(&right);

}

void GameObject::show(){
    think();
    if(v_x>0 && !facing_right){
        facing_right = true; 
        changed_direction();
    }
    if(v_x<0 && facing_right){
        facing_right = false;
        changed_direction();
    }

    current_animation->show(x,y);
};

void Player::changed_direction(){

    if(facing_right)
        set_animation(&right);

    if(!facing_right)
        set_animation(&left);

}

void Player::think(){
    if(move_right)
        v_x = 9;
    if(move_left)
        v_x = -9;
    if(jump && touching_ground){
        v_y = 15;
    }
    if(shot && shoting_timer.tss()>300){
        shoting_timer.restart();
        int xcoord,v;
        if(facing_right){
            xcoord = x + 20;
            v=9;
        }
        else{
            xcoord = x - 20;
            v=-9;
        }
        auto& eng = Engine::get_instance();
        shared_ptr<GameObject> bullet(new Bullet(xcoord,y+5,v));
        eng.add_object(bullet);
    }
}



void GameObject::save(FILE* fp){
    fprintf(fp,"%d %d\n",x,y);
    fprintf(fp,"%d\n", v_x);
    fprintf(fp, "%d\n", v_y);
    fprintf(fp, "%d\n", hp);
    fprintf(fp, "%d\n", dmg);
    save_bool(fp,touching_ground);
    save_bool(fp,facing_right);
}

void GameObject::load(FILE *fp){
    fscanf(fp, "%d %d", &x, &y);
    fscanf(fp,"%d", &v_x);
    fscanf(fp, "%d", &v_y);
    fscanf(fp, "%d", &hp);
    fscanf(fp, "%d", &dmg);
    load_bool(fp,touching_ground);
    load_bool(fp,facing_right);
}

void Player::load(FILE* fp){
    GameObject::load(fp);
    set_animation(&right);
}
