#include "animation.h"
#include <string>
#include <cstdio>
#include <errno.h>
#include "helper.h"
#include <iostream>
#include "texture_loader.h"
#include <vector>
#include <memory>
#include <cmath>


Animation::Animation(std::string& path){
    load(path);
}

void Animation::load(std::string& path){
    int nr = 0 ;
    std::string name=path+"anim";
    std::string filename = name+int_to_str(nr)+".png";
    while(file_exists(filename)){
        TextureLoader& textures = TextureLoader::get_instance(); 
        frames.push_back(textures[filename]);
        nr++;
        std::string filename = name+int_to_str(nr)+".png";
    }
    if(frames.size()==0){
        fprintf(stderr,"no frames for animation");
        exit(1);
    }

    rect.resize(frames[0]->get_width(),frames[0]->get_height());
    animation_loop_time = frames.size()*FRAME_TIME;
    current_frame=frames[0];

}

void Animation::show(float x,float y){
    unsigned int looped_time;
    looped_time=animation_timer.tss()%animation_loop_time;
    unsigned int animation_index;
    animation_index = (unsigned int)std::floor(((float)looped_time)/FRAME_TIME);

    current_frame = frames[animation_index];
    current_frame->set();
    rect.show(x,y);
}
