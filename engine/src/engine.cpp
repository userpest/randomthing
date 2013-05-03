#include "engine.h"
#include <cstdio>
#include <cstdlib>
#include <GL/gl.h>
#include <GL/glu.h>
#include <SDL/SDL.h>
#include "shapes.h"
#include "texture_loader.h"
#include <SDL/SDL_image.h>

using namespace std;
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
    if ( SDL_Init( SDL_INIT_VIDEO ) < 0 )
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
	default:
	    break;
	}

    return;
}

void Engine::handle_key_up(SDL_keysym *keysym){return;}

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

void Engine::draw_scene(){

    /* Clear The Screen And The Depth Buffer */
    glClear( GL_COLOR_BUFFER_BIT );
    Texture t("img.jpg"); 
    Texture t2("img2.jpg");
    Rectangle rect(20,20);
    /* Move Left 1.5 Units And Into The Screen 6.0 */
    glLoadIdentity();

    t2.set();
    rect.show(0,0);
    /* Draw it to the screen */
    SDL_GL_SwapBuffers( );


}

void Engine::game_loop(){
  while (true)
	{
        handle_events();
		draw_scene();
	}
}
