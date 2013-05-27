#include "game_objects.h"
#include <iostream>
#include <cstdlib>
#include <iterator>
#include "helper.h"
#include <boost/python/ptr.hpp>
#include <errno.h>
#include <dirent.h>
#include "animation.h"
#include "engine.h"
using namespace boost::python;
BOOST_PYTHON_MODULE(Creature){
        class_<GameObject>("GameObject", no_init)
        .def_readwrite("x", &GameObject::x)
        .def_readwrite("y", &GameObject::y)
        .def_readwrite("dmg", &GameObject::dmg)
        .def_readwrite("hp", &GameObject::hp);


    class_<Creature, bases<GameObject> >("Creature", no_init)
        .def("set_animation", &Creature::set_current_animation)
        .def("can_move", &Creature::can_move)
        .def("move", &Creature::move)
        .def("get_player_pos",&Creature::get_player_pos)
        .def("add_object", &Creature::add_object);
};


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

Creature::Creature(std::string name,std::string _map_path){
    py_interpreter = Py_NewInterpreter();
    if(py_interpreter == NULL){
        cerr<<"Cant create new interpreter "<<endl;
        exit(1);
    }
    map_path = _map_path;
    string creature_path = get_path(map_path,name); 
    
    try{
       string script_path = creature_path+"/script.py";
        FILE *script;
        script = fopen_or_die(script_path, "r");
        PyRun_SimpleFileEx(script, "script.py", 1);

        object main = object(handle<>(borrowed(
                    PyImport_AddModule("__main__")
                )));
        object script_init = main.attr("init");
        script_think = main.attr("think");
        script_collision = main.attr("collision");
        script_init(ptr(this));

    }
    catch(error_already_set){
        PyErr_Print();
        exit(1);
    }
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

Creature::~Creature(){
    Py_EndInterpreter(py_interpreter);

}

void Creature::think(){
    try{
    PyThreadState_Swap(py_interpreter);
    script_think();
    }catch(error_already_set){
        PyErr_Print();
        exit(1);
    }

}

void Creature::collision(){
    try{
    PyThreadState_Swap(py_interpreter);
    script_collision();
    }catch(error_already_set){
        PyErr_Print();
        exit(1);
    }

}
void Creature::set_current_animation(std::string name){
    set_animation(animations[name].get());
}

bool Creature::can_move(int _x, int _y){
    //not the most beautiful solution
    Engine& engine = Engine::get_instance();
    return engine.can_move(this,_x,_y);
}
void Creature::move(int _x,int _y){
    v_x+=_x;
    v_y+=y;
}

void Creature::add_object(std::string name, int _x, int _y){
    //also not the best solution
    Engine& engine = Engine::get_instance();
    shared_ptr<GameObject> obj(new Creature(name,map_path));
    obj->x = x + _x;
    obj->y = y+_y;
    engine.add_object(obj);
}
boost::python::tuple Creature::get_player_pos(){
    Engine& engine = Engine::get_instance();
    return boost::python::make_tuple(engine.player->x,engine.player->y);

}
