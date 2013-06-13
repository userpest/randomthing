#include <cstdio>


const unsigned short int BOTTOM = 0 ;
const unsigned short int AIR = 1;
int main(int argc, char *argv[]){
    FILE* fp;
    unsigned int width=30;
    unsigned int height=30;
    int player_x=100,player_y=100;

    fp = fopen(argv[1], "w");
    fprintf(fp,"%d %d %d %d\n", width, height, player_x,player_y);
    unsigned short int tile_id;
    tile_id = BOTTOM;
    for(int i= 0; i < width;i++){
        fprintf(fp,"%d ", tile_id);
    }
    fprintf(fp,"\n");
    tile_id = AIR; 
    for(int j = 0 ; j < height-1;j++){
        for(int i= 0; i < width;i++){
            fprintf(fp,"%d ", tile_id);
        }
        fprintf(fp,"\n");
    }
    

}

