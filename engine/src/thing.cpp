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

    game.load_map("test_map/");
    game.game_loop();
}
