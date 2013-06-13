#include "triggers.h"
#include "engine.h"
#include "game_objects.h"
#include <memory>
using namespace std;
void MapConnectingTrigger::activate(){
    auto& eng = Engine::get_instance();
    eng.switch_map(map_name,player_x,player_y);
};

void SpawningTrigger::activate(){
    auto& eng = Engine::get_instance(); 

    if(activation_count == 0)
        return;

    if(timer.time_since_last_save()>cooldown){
        shared_ptr<GameObject> c = load_creature(creature_name, x_spawn,y_spawn);
        eng.add_object(c);
        timer.save();
        activation_count--;
    }

};
