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
        std::string map_path = eng.get_map_name();
        shared_ptr<GameObject> creature = make_shared<Creature>(creature_name,map_path);
        creature->x = x_spawn;
        creature->y = y_spawn;
        eng.add_object(creature);
        timer.save();
        activation_count--;
    }

};
