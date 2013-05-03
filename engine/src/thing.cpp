#include "engine.h"
int main( int argc, char **argv )
{
    Engine game;
    game.init();
    game.game_loop();
}
