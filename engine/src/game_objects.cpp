#include "game_objects.h"
#include <iostream>
using namespace std;
Player::Player(int _x , int _y){
    x = _x;
    y = _y;
    right.load("blue_square/");
    left.load("red_square/");
    set_animation(right);

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
        set_animation(right);

    if(!facing_right)
        set_animation(left);

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
