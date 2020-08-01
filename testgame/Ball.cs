using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testgame.Desktop
{

    public class Ball
    {
        public Texture2D Skin;
        public Vector2   Pos;  
        public float     X;   
        public float     Y;   
        public float     Spd;  
        public int       Ax;   
        public int       Ay;

        public Ball(Texture2D ballTexture,
                    Vector2   ballPosition,
                    float     ballSpeed,
                    int       ballXAccel,
                    int       ballYAccel){
            
            Skin = ballTexture;
            Pos  = ballPosition;
            X    = ballPosition.X;
            Y    = ballPosition.Y;
            Spd  = ballSpeed;
            Ax   = ballXAccel;
            Ay   = ballYAccel;
        }
    }
}
