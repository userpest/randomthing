#include <cstdio>


const unsigned short int BOTTOM = 0 ;
const unsigned short int AIR = 1;
int main(int argc, char *argv[]){
    FILE* fp;
    unsigned int width=30;
    unsigned int height=30;
    fp = fopen(argv[1], "wb");
    fwrite(&width, sizeof(width),1, fp);
    fwrite(&height, sizeof(height), 1,fp);

    unsigned short int tile_id;
    tile_id = BOTTOM;
    for(int i= 0; i < width;i++){
        fwrite(&tile_id, sizeof(tile_id),1,fp);
    }
    tile_id = AIR; 
    for(int j = 0 ; j < height-1;j++){
        for(int i= 0; i < width;i++){
            fwrite(&tile_id, sizeof(tile_id),1,fp);
        }
    }
    

}

