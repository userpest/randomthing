#include "engine.h"
#include <cstdio>
#include <cstdlib>
#include <GL/gl.h>
#include <GL/glu.h>
#include <SDL/SDL.h>
#include "shapes.h"
#include "texture_loader.h"
#include <SDL/SDL_image.h>
#include <algorithm>
#include "game_objects.h"
#include "helper.h"
#include <iostream>
#include <iostream>
#include <fstream>

using namespace std;

bool Engine::can_move(GameObject* obj, int x, int y){
    obj->x+=x;
    obj->y+=y;
    bool ret = game_map.collides(obj);           
    obj->x-=x;
    obj->y-=y;
    return !ret;
}

void Engine::load_map(std::string path){
    objects.resize(0);
    player = shared_ptr<Player>(new Player(100,150));
    objects.push_back(player);
    game_map.load(path);
    player->x = game_map.player_x;
    player->y = game_map.player_y;
}

void Engine::switch_map(string path, int x, int y){
    load_map(path);
    player->x = x;
    player->y = y;
    game_loop();
};

void Engine::save_game(std::string filename){
    FILE *save;
    int entries = objects.size();
    save = fopen(filename.c_str(), "wb");
    if(save == NULL){
        cout<<"cant save exiting..."<<endl;
        exit(1);
    }

    game_map.save(save);
    fprintf(save,"%d", entries-1);
    player->save(save);
    for(auto& object: objects){
        if(object.get() != player.get())
            object->save(save);
    }

    fclose(save);
};

void Engine::load_game(std::string filename){
    objects.clear();
    int entries;
    FILE* save;
    save = fopen(filename.c_str(),"rb");
    if(save == NULL){
        cout<<"cant open the save"<<endl;
        exit(1);
    }

    game_map.load(save);
    fscanf(save,"%d", &entries);
    player = shared_ptr<Player>(new Player(100,150));
    player->load(save);

    for(int i = 0 ; i < entries;i++){
        shared_ptr<Creature> creature = make_shared<Creature>();
        creature->load(save);
        shared_ptr<GameObject> ptr = creature;
        add_object(ptr);
    }

    fclose(save);
};
void Engine::detect_collisions(){

    for(auto& i: objects){
        for(auto&j: objects){
            //we cant collision check with self
            if(i != j && objects_collide(i,j)){
                j->hp -= i->dmg;
                i->hp -= j->dmg;
                i->collision();
                j->collision();
            }
        }
    }

};

bool Engine::objects_collide(std::shared_ptr<GameObject>& a, std::shared_ptr<GameObject>& b){

    //calculate overlapping area
    int overlapx_start = max(a->x,b->x);
    int overlapx_stop = min(a->x+a->width, b->x+b->width);
    int overlapy_start = max(a->y,b->y);
    int overlapy_stop = min(a->y+a->height, b->y+b->height);

    //quit if there is no overlap
    if(overlapx_stop < overlapy_start || overlapx_stop < overlapy_start)
        return false;

    //calculate overlap coords in texture coord system
    int a_start_x = overlapx_start - a->x;
    int b_start_x = overlapx_start - b->x;
    int a_start_y = overlapy_start - a->y;
    int b_start_y = overlapy_start - b->y;

    //calculate overlap size
    int x_range = overlapx_stop - overlapx_start;
    int y_range = overlapy_stop - overlapy_start;

    //check overlap area for collisions
    for(int x = 0; x< x_range ;x++){
        for(int y= 0 ; y <y_range;y++){
            if( a->collides(a_start_x+ x, a_start_y + y) 
                    && 
                b->collides(b_start_x + x,b_start_y + y) ){
                return true;
            }        
        }
    }

    return false;
};

void Engine::resize_window( int width, int height )
{
    /* Height / width ration */
    GLfloat ratio;

    /* Protect against a divide by zero */
    if ( height == 0 )
	height = 1;

    ratio = ( GLfloat )width / ( GLfloat )height;

    /* Setup our viewport. */
    glViewport( 0, 0, ( GLsizei )width, ( GLsizei )height );

    /* change to the projection matrix and set our viewing volume. */
    glMatrixMode( GL_PROJECTION );
    glLoadIdentity( );

    /* Set our perspective */
//    gluPerspective( 45.0f, ratio, 0.1f, 100.0f );
    glOrtho(0,width,0,height,0,1);
    /* Make sure we're chaning the model view and not the projection */
    glMatrixMode( GL_MODELVIEW );

    /* Reset The View */
    glLoadIdentity( );

}

void Engine::quit( int returnCode )
{
    /* clean up the window */
    SDL_Quit( );

    /* and exit appropriately */
    exit( returnCode );
}

void Engine::init(){
/* Flags to pass to SDL_SetVideoMode */
    int videoFlags;
    /* main loop variable */
    const SDL_VideoInfo *videoInfo;

    /* initialize SDL */
    if ( SDL_Init( SDL_INIT_VIDEO |SDL_INIT_TIMER) < 0 )
	{ fprintf( stderr, "Video initialization failed: %s\n",
		     SDL_GetError( ) );
	    quit( 1 );
	}

    /* Fetch the video info */
    videoInfo = SDL_GetVideoInfo( );

    if ( !videoInfo )
	{
	    fprintf( stderr, "Video query failed: %s\n",
		     SDL_GetError( ) );
	    quit( 1 );
	}

    if(IMG_Init(IMG_INIT_PNG | IMG_INIT_JPG)<0){
        fprintf(stderr, "img init %s\n", IMG_GetError());
        quit ( 1);

    }
    /* the flags to pass to SDL_SetVideoMode */
    videoFlags  = SDL_OPENGL;          /* Enable OpenGL in SDL */
    videoFlags |= SDL_GL_DOUBLEBUFFER; /* Enable double buffering */
    videoFlags |= SDL_HWPALETTE;       /* Store the palette in hardware */
    videoFlags |= SDL_RESIZABLE;       /* Enable window resizing */

    /* This checks to see if surfaces can be stored in memory */
    if ( videoInfo->hw_available )
	videoFlags |= SDL_HWSURFACE;
    else
	videoFlags |= SDL_SWSURFACE;

    /* This checks if hardware blits can be done */
    if ( videoInfo->blit_hw )
	videoFlags |= SDL_HWACCEL;

    /* Sets up OpenGL double buffering */
    SDL_GL_SetAttribute( SDL_GL_DOUBLEBUFFER, 1 );

    /* get a SDL surface */
    surface = SDL_SetVideoMode( SCREEN_WIDTH, SCREEN_HEIGHT, SCREEN_BPP,
				videoFlags );

    /* Verify there is a surface */
    if ( !surface )
	{
	    fprintf( stderr,  "Video mode set failed: %s\n", SDL_GetError( ) );
	    quit( 1 );
	}

    /* initialize OpenGL */
    init_GL( );

    /* resize the initial window */
    resize_window( SCREEN_WIDTH, SCREEN_HEIGHT );

}
void Engine::init_GL( )
{

    /* Enable smooth shading */
    glShadeModel( GL_SMOOTH );

    /* Set the background black */
    glClearColor( 0.0f, 0.0f, 0.0f, 0.0f );

    /* Depth buffer setup */
    glClearDepth( 1.0f );

    /* Enables Depth Testing */
    glDisable( GL_DEPTH_TEST );
    glEnable(GL_TEXTURE_2D);

    //enable blending for imgs with alpha
    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

    /* The Type Of Depth Test To Do */
    glDepthFunc( GL_LEQUAL );

    /* Really Nice Perspective Calculations */
    glHint( GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST );

}

void Engine::handle_key_down( SDL_keysym *keysym )
{
    switch ( keysym->sym )
	{
	case SDLK_ESCAPE:
	    /* ESC key was pressed */
	    quit( 0 );
	    break;
	case SDLK_F1:
	    /* F1 key was pressed
	     * this toggles fullscreen mode
	     */
	    SDL_WM_ToggleFullScreen( surface );
	    break;

    case SDLK_a:
        player->move_left=true;
        break;

    case SDLK_d:
        player->move_right=true;
        break;

    case SDLK_w:
        player->jump=true;
        break;

    case SDLK_SPACE:
        player->shot=true;
        break;

	default:
	    break;
	}

    return;
}

void Engine::handle_key_up(SDL_keysym *keysym){

    switch ( keysym->sym )
	{

    case SDLK_a:
        player->move_left=false;
        break;

    case SDLK_d:
        player->move_right=false;
        break;

    case SDLK_w:
        player->jump=false;
        break;

    case SDLK_SPACE:
        player->shot=false;
        break;

	default:
	    break;
	}

}

void Engine::handle_events(){

        SDL_Event event;

	    while ( SDL_PollEvent( &event ) )
		{
		    switch( event.type )
			{
			case SDL_ACTIVEEVENT:
                break;			    
			case SDL_VIDEORESIZE:
			    /* handle resize event */
			    surface = SDL_SetVideoMode( event.resize.w,
							event.resize.h,
							16, videoFlags );
			    if ( !surface )
				{
				    fprintf( stderr, "Could not get a surface after resize: %s\n", SDL_GetError( ) );
				    quit( 1 );
				}
			    resize_window( event.resize.w, event.resize.h );
			    break;
			case SDL_KEYDOWN:
			    /* handle key presses */
			    handle_key_down( &event.key.keysym );
			    break;
            case SDL_KEYUP:
                handle_key_up(&event.key.keysym);
                break;
			case SDL_QUIT:
			    /* handle quit requests */
                exit(1);
			    break;
			default:
			    break;
			}
		}

}

void Engine::move_camera(){
    float move_x,move_y;
    float screen_half_x = ((float)SCREEN_WIDTH)/2; 
    float screen_half_y = ((float)SCREEN_HEIGHT)/2;
    
    if( (player->x +screen_half_x) > game_map.width ){

        move_x = -(float)(game_map.width-SCREEN_WIDTH);

    }else if(player->x < screen_half_x){

        move_x=0;

    } else{

        move_x = -(player->x-screen_half_x);

    }

    if( (player->y + screen_half_y) > game_map.height ){

        move_y = -(float)(game_map.height - SCREEN_HEIGHT);

    }else if(player->y < screen_half_y){

        move_y=0;

    } else{

        move_y = -(player->y-screen_half_y);

    }
    glTranslatef(move_x,move_y,0); 

}

void Engine::draw_scene(){

    glClear( GL_COLOR_BUFFER_BIT );
    glLoadIdentity();
    move_camera();
    game_map.show();
    
    for(auto& i : objects){
        i->show();
    }

    
    SDL_GL_SwapBuffers( );
}

void Engine::handle_movement(){

    for(auto& i: objects){

        i->v_y-=1;

        int vx = i->v_x,vy = i->v_y;
        int stepx =-sgn(vx), stepy = -sgn(vy);
        //gravity

        if(i->v_y != 0 ){
            i->touching_ground = false;
        }

        //TODO: change into something what makes at least a tiny bit more sense
        i->x +=vx;
        i->y +=vy;
        while(game_map.collides(i) && ( vx != 0 || vy != 0)){
            if(vx!=0){
                vx+=stepx;
                i->x+=stepx;
            }
            if(vy!=0){
                vy+=stepy;
                i->y+=stepy;
            }
        }

        //if we cant move on y axis stop such movement
        if(vy == 0 ){
            //if we cant move down that means that we've hit the ground
            if(i->v_y < 0 ){
                i->touching_ground = true;
            }
            i->v_y=0;
        }

        //basically if we did hit something or we're touching the ground stop movement on x axis
        if(i->touching_ground || vx == 0 ){
            i->v_x=0;
        }

    }

}

void Engine::harvest_dead(){

    for(auto i = objects.begin(); i!=objects.end(); i++){
        if ( (*i)->hp < 0){
            objects.erase(i);
        }
    }

}
void Engine::game_loop(){
  while (true)
	{
        handle_events();
        handle_movement();
        detect_collisions();
        harvest_dead();
		draw_scene();
        SDL_Delay(30);
	}
}
