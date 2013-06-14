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
#include <cmath>

using namespace std;

TestCreature::TestCreature(int _x,int _y){
    name = "test";
    x=_x;
    y=_y;
    dmg = 10;
    anim.load("blue_square/");
    set_animation(&anim);
};
void TestCreature::think(){
    walk();
};

std::shared_ptr<GameObject> load_creature(std::string name, int x, int y){
    printf("loading %s #\n", name.c_str());
    shared_ptr<GameObject> ptr;

    if(strcmp(name.c_str(),"test")==0){
        puts("test_creature");
        ptr = shared_ptr<GameObject>(new TestCreature(x,y));
    }  

    if(strcmp(name.c_str(),"bullet")==0){
        ptr = shared_ptr<GameObject>(new Bullet(x,y,0));
    }
    if(strcmp(name.c_str(),"walker")==0){
        ptr = shared_ptr<GameObject>(new Walker(x,y));
    }
    if(strcmp(name.c_str(),"cameleon")==0){
        ptr = shared_ptr<GameObject>(new Cameleon(x,y));
    }
    if(strcmp(name.c_str(),"jumper")==0){
        ptr = shared_ptr<GameObject>(new Jumper(x,y));
    }
    if(strcmp(name.c_str(),"invisible")==0){
        ptr = shared_ptr<GameObject>(new Invisible(x,y));
    }
    if(strcmp(name.c_str(),"kamikaze")==0){
        ptr = shared_ptr<GameObject>(new Kamikaze(x,y));
    }
    if(strcmp(name.c_str(),"tracking_bullet")==0){
        ptr = shared_ptr<GameObject>(new TrackingBullet(x,y));
    }
    return ptr;
    
}
void WalkingCreature::walk(){
    //meh
    auto& eng = Engine::get_instance();
    if(eng.will_fall((GameObject*)this,move_direction,0) || !eng.can_move((GameObject*)this,move_direction,0)){
        if(!eng.will_fall((GameObject*)this,move_direction*-1,0)){
            move_direction*=-1;
            v_x = move_direction;
        }else{
            v_x = 0;
        }
    }else{
        v_x = move_direction;
    }


}
Walker::Walker(int _x,int _y){
    x = _x;
    y = _y;
    right.load("blue_square/");
    left.load("red_square/");
    explosion.load("red_square/");
    set_animation(&right);
    name="walker";
    dmg = 10;
    hp = 20;
}
void Walker::think(){
    if(!explodes)
        walk();

    auto& eng = Engine::get_instance();
    float dist = sqrt(pow(x-eng.player->x,2)+ pow(y-eng.player->y,2));
    if(dist < 40 && !explodes){
        set_animation(&explosion);
        explodes=true;
        explosion_timer.restart();
        v_x =0  ;
        v_y =0;
        puts("exploding");
    }

    if(explodes && explosion_timer.tss()>2000){
        hp = -1;
    }
}

Cameleon::Cameleon(int _x, int _y){
    x = _x;
    y = _y;
    dmg = 100;
    hp = 100;
    name = "cameleon";
    char names[1][100]={"red_square/"};
    anim.load(names[0]);
    set_animation(&anim);
};
Jumper::Jumper(int _x, int _y){
    x = _x;
    y = _y;
    dmg = 100;
    hp = 100;
    name = "jumper";
 
    right.load("blue_square/");
    left.load("red_square/");
    set_animation(&right);
}

void Jumper::think(){
    walk();
    auto& eng = Engine::get_instance();
    float dist = fabs(x-eng.player->x);
    if( !eng.will_fall((GameObject*)this,move_direction,0)){
        v_y=5;
        v_x=5*(int)sgn(move_direction);
    }else if(v_x ==0 && v_y == 0) {
        walk();
    }

    if( dist < 10 && eng.player->y > y){
        v_y+=15;
        v_x=0;
    }

};

Invisible::Invisible(int _x, int _y){
    anim.load("blue_square/");
    x = _x;
    y = _y;
    hp = 10;
    dmg = 10;
    name = "invisible";
    set_animation(&anim);
}

void Invisible::think(){
    walk();
};

Kamikaze::Kamikaze(int _x, int _y){
    x = _x;
    y = _y;
    hp = 200; 
    dmg = 100;
    name = "kamikaze";

    anim.load("red_square/");
    set_animation(&anim);
}
void Kamikaze::think(){
    auto& eng = Engine::get_instance();
    float dist = abs(x-eng.player->x);

    int dir = (int)sgn(eng.player->x-x);
    float ydist = abs(eng.player->y-y);
    if(dist < 300 && ydist<=30 && ! eng.will_fall((GameObject *)this,dir*10,0)){
        v_x+=dir*15;
    }else{
        walk();
    }


}

void Kamikaze::collision(){
    auto& eng = Engine::get_instance();
    int dir = (int)sgn(eng.player->x-x);
    if(shoting_timer.tss()>100){
        shared_ptr<GameObject> ptr(new TrackingBullet(x+22*dir, y+5));
        shoting_timer.restart();
        eng.add_object(ptr);
    }
}

TrackingBullet::TrackingBullet(int _x,int _y){
    x = _x;
    y = _y; 
    dmg = 100;
    hp = 100;
    name = "tracking_bullet";
    anim.load("creatures/bullet/");
    set_animation(&anim);
    auto& eng = Engine::get_instance();
    int xdir = (int)sgn(eng.player->x-x);
    int ydir= (int)sgn(eng.player->y-y+5);
    v_x = 10*xdir;
    v_y = 3*ydir+1;
 
}

void TrackingBullet::think(){
    if (v_x == 0 && v_y == 0 ){
        puts("goodbye");
        hp = -1; 
    }

    auto& eng = Engine::get_instance();
    int xdir = (int)sgn(eng.player->x-x);
    int ydir= (int)sgn(eng.player->y-y+5);
    v_x = 10*xdir;
    v_y = 3*ydir+1;
}

void TrackingBullet::collision(){
    //printf("collision\n");
    //hp = -1;
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
