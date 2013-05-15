#include "engine.h"
#include <iostream>
#include "texture_loader.h"
#include <memory>

using namespace std;
int main( int argc, char **argv )
{
    Engine& game = Engine::get_instance();
    TextureLoader& tloader = TextureLoader::get_instance();

    game.init();

    shared_ptr<Texture> t = tloader["wilber.png"];
    /*
    for(int i = 0 ;i < t->get_height();i++){
       for(int j =0 ; j < t->get_width();j++){
           t->collides(j,i);
     //       if(t->collides(j,i))
      //          cout<<"1 ";
       //     else
        //        cout<<"0 "; 
        } 
        cout<<endl;
    }
    */
    for(int i = 0 ; i < t->get_width();i++){
        t->collides(i,50);
    }
    puts("");
    //game.load_map("test_map/");
    //game.game_loop();
}
