using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testgame.Desktop
{

    public class Ball
    {
        public Texture2D Skin  { get; set; }
        public Vector2   Pos   { get; set; }
        public float     X     { get; set; }
        public float     Y     { get; set; }
        public float     Spd   { get; set; }
        public int       Ax    { get; set; }
        public int       Ay    { get; set; }

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
