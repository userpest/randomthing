#include "texture_loader.h"
#include <string>
#include <memory>
#include <SDL/SDL.h>
#include <GL/gl.h>
#include <SDL/SDL_image.h>
#include <iostream>
Texture::Texture(std::string path){
    GLenum texture_format;
    GLint  nOfColors;
    if (  surface = IMG_Load(path.c_str()) ) { 
    

    
            // get the number of channels in the SDL surface
            nOfColors = surface->format->BytesPerPixel;
//            printf("number of channels %d\n", nOfColors);
            if (nOfColors == 4)     // contains an alpha channel
            {
                    if (surface->format->Rmask == 0x000000ff)
                            texture_format = GL_RGBA;
                    else
                            texture_format = GL_BGRA;
            } 
            /*
            else if (nOfColors == 3)     // no alpha channel
            {
                    if (surface->format->Rmask == 0x000000ff)
                            texture_format = GL_RGB;
                    else
                            texture_format = GL_BGR;
            }*/
            else {
//                    printf("warning: the image is not truecolor..  this will probably break\n");
                std::cerr<<"Image:"<<path<< "does not posess alpha channel exiting..."<<std::endl;                    
                std::cerr<<"only: "<<nOfColors<<" channels found"<<std::endl;
                exit(1);
// this error should not go unhandled
            }
    
        // Have OpenGL generate a texture object handle for us
        glGenTextures( 1, &texture );
    
        // Bind the texture object
        glBindTexture( GL_TEXTURE_2D, texture );
    
        // Set the texture's stretching properties
            glTexParameteri( GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR );
            glTexParameteri( GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR );
    
        // Edit the texture object's image data using the information SDL_Surface gives us
        glTexImage2D( GL_TEXTURE_2D, 0, nOfColors, surface->w, surface->h, 0,
                        texture_format, GL_UNSIGNED_BYTE, surface->pixels );
    } 
    else {
        printf("SDL could not load image.bmp: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }    

    width = surface->w;
    height = surface -> h; 

}

const  std::shared_ptr<Texture>& TextureLoader::operator[](std::string name){

    if(cache.find(name) == cache.end()){
        std::shared_ptr<Texture>  p(new Texture(name)); 
        cache[name] = p ;
    }
    return cache[name];

}
bool Texture::collides(int _x, int _y){
    //switch to sdl coordinate system ( rotate by 180 degrees)
    int x = width - _x;
    int y = height - _y;
    Uint8 r,g,b,a;
    int bpp = surface->format->BytesPerPixel;

    /* calc pixel coords */
    Uint8 *p = (Uint8 *)surface->pixels + y * surface->pitch + x * bpp;
    SDL_GetRGBA(*p,surface->format, &r,&g,&b,&a); 

    if(a == 0xFF){
        return true;
    } else {
        return false;
    }
}
