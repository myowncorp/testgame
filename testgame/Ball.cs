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


         public void UpdPos(GameTime gametime, GraphicsDeviceManager graphics)
            {
          

                this.X = ballPosX(this.X);
                this.Y = ballPosY(this.Y);

                float ballPosX(float x)
                {
                    float newX;

                    if (ballCollideX(x))
                        newX = graphics.PreferredBackBufferWidth - this.Skin.Width / 2;
                    else
                        newX = x;

                    return newX;
                }

                float ballPosY(float y)
                {
                    float newY;

                    if (ballCollideY(y))
                        newY = graphics.PreferredBackBufferHeight - this.Skin.Height / 2;
                    else
                        newY = y;

                    return newY;
                }

                bool ballCollideX(float x)
                {
                    if (x > (graphics.PreferredBackBufferWidth - this.Skin.Width / 2))
                        return true;
                    else if (x < (0 + this.Skin.Width / 2))
                        return true;
                    else
                        return false;
                }

                bool ballCollideY(float y)
                {
                    if (y > (graphics.PreferredBackBufferHeight - this.Skin.Height / 2))
                        return true;
                    else
                        return false;
               }
            }
    }
}
