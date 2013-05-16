#include "texture_loader.h"
#include <string>
#include <memory>
#include <SDL/SDL.h>
#include <GL/gl.h>
#include <SDL/SDL_image.h>
#include <iostream>
#include <list>
using namespace std;
void Texture::print_collisions(){
    cout<<"collision map"<<endl;
    for(int j =height-1 ; j >= 0;j--){
        for(int i =0;i<width;i++){
            cout<<collides(i,j);
        }
        cout<<endl;
    }

}
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
            } else {
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
    cout<<path<<endl;
    print_collisions();
    cout<<"#############"<<endl;
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
    int bpp = surface->format->BytesPerPixel;
    Uint8* p = (Uint8*)surface->pixels + y * surface->pitch + x * bpp;
    Uint32 pixelColor;
    
    switch(bpp)
    {
        case(1):
            pixelColor = *p;
            break;
        case(2):
            pixelColor = *(Uint16*)p;
            break;
        case(3):
            if(SDL_BYTEORDER == SDL_BIG_ENDIAN)
                pixelColor = p[0] << 16 | p[1] << 8 | p[2];
            else
                pixelColor = p[0] | p[1] << 8 | p[2] << 16;
            break;
        case(4):
            pixelColor = *(Uint32*)p;
            break;
    }
    
    Uint8 red, green, blue, alpha;
    SDL_GetRGBA(pixelColor, surface->format, &red, &green, &blue, &alpha);

    return alpha == SDL_ALPHA_OPAQUE ;

}
