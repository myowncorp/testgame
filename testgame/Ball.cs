using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testgame.Desktop
{

    public class Ball
    {

        public Texture2D Skin;  
        public Vector2   Pos;
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
            Spd  = ballSpeed;
            Ax   = ballXAccel;
            Ay   = ballYAccel;
        }


         public void UpdPos(GameTime gametime, GraphicsDeviceManager graphics)
            {
          

                this.Pos.X = ballPosX(this.Pos.X);
                this.Pos.Y = ballPosY(this.Pos.Y);

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
