#include "engine.h"
#include <iostream>
#include "texture_loader.h"
#include <memory>
#include "timer.h"
using namespace std;
int main( int argc, char **argv )
{
    Engine& game = Engine::get_instance();
    TextureLoader& tloader = TextureLoader::get_instance();

    game.init();
    /*
    auto t = tloader[argv[1]];
    for(int i =0 ;i< t->get_height();i++){
        for(int j =0  ; j<t->get_width();j++){
            if(t->collides(i,j))
                cout<<i<<" "<<j<<" "<<endl;
        }
    }
    */
    game.load_map("test_map/");
//    game.load_map("map2/");
    game.game_loop();
}
