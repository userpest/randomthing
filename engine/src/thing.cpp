#include "engine.h"
int main( int argc, char **argv )
{
    Engine& game = Engine::get_instance();

    game.init();
    game.load_map("test_map/");
    game.game_loop();
}
