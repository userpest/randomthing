#include "game_objects.h"
#include <iostream>
#include <cstdlib>
#include <iterator>
#include "helper.h"
#include <errno.h>
#include <dirent.h>
#include "animation.h"
#include "engine.h"

using namespace std;

using namespace std;

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
        v_x = 10;
    if(move_left)
        v_x = -10;
    if(jump && touching_ground){
        v_y = 20;
    }
}

void Creature::load(std::string name, std::string _map_path){

    std::string creature_path = "./"+name;
    DIR *dir;
    struct dirent *ent;
    string animation_dir = creature_path + "/animations/";

    if ( (dir = opendir(animation_dir.c_str())) == NULL) {
        perror("cant open animations directory");
        exit(1);
    }

    /* print all the files and directories within directory */
    while ((ent = readdir (dir)) != NULL) {
        string animation_path = animation_dir+ent->d_name;
        animations[ent->d_name]=shared_ptr<Animation>(new Animation(animation_path));
    }

    closedir (dir);
}

Creature::Creature(std::string name,std::string _map_path){
    load(name,_map_path);
}

Creature::~Creature(){

}

void Creature::think(){
}

void Creature::collision(){

}

void Creature::add_object(std::string name, int _x, int _y){
    //also not the best solution
    Engine& engine = Engine::get_instance();
    shared_ptr<GameObject> obj(new Creature(name,map_path));
    obj->x = x + _x;
    obj->y = y+_y;
    engine.add_object(obj);

}

void GameObject::save(FILE* fp){
    fprintf(fp,"%d", v_x);
    fprintf(fp, "%d", v_y);
    fprintf(fp, "%d", hp);
    fprintf(fp, "%d", dmg);
    save_bool(fp,touching_ground);
    save_bool(fp,facing_right);
}

void GameObject::load(FILE *fp){
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

void Creature::load(FILE* fp){
    map_path=load_string(fp);
    creature_name =load_string(fp);
    string anim = load_string(fp);
    load(creature_name,map_path);
    GameObject::load(fp);
    set_animation(animations[anim].get());
}

void Creature::save(FILE *fp){
    save_string(fp,map_path);
    save_string(fp,creature_name);
    save_string(fp,animation_name);
    GameObject::save(fp);
}

