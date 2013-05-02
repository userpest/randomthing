#include "shapes.h"
#include <vector>
#include <GL/gl.h>
void Rectangle::resize(float width, float height){
    auto resized= std::vector<float>({0,height, 0,0, width,0, width,0, width,height, 0,height});
    copy(resized.begin(), resized.end(), vertices);
}
void Rectangle::show(float x,float y){

    glEnableClientState(GL_VERTEX_ARRAY);
    glEnableClientState(GL_TEXTURE_COORD_ARRAY);

    glPushMatrix();
    glTranslatef(x,y,0);

    glVertexPointer(2,GL_FLOAT, 0,vertices);
    glTexCoordPointer(2,GL_FLOAT,0,texture_coords); 
    glDrawArrays(GL_TRIANGLES, 0, 2*3*2);

    glPopMatrix();

    glDisableClientState(GL_VERTEX_ARRAY);
    glDisableClientState(GL_TEXTURE_COORD_ARRAY);
}
