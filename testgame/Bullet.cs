using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace testgame.Desktop
{
    public class Bullet{ 
        public int       Ax        { get; set; }
        public int       Ay        { get; set; }
        public float     Spd       { get; set; }
        public Vector2   Bp        { get; set; }
        public float     X         { get; set; }
        public float     Y         { get; set; }
        public Texture2D BullText  { get; set; }

        public Bullet(Texture2D bulletimg, Vector2 bulletPos, int accelx, int accely, float bullspeed){
            BullText = bulletimg;
            Ax       = accelx;
            Ay       = accely;
            Spd      = bullspeed;
            Bp       = bulletPos;
            X        = bulletPos.X;
            Y        = bulletPos.Y;
        }



        public void UpdPos(GameTime gameTime)
        {
            if (this.Ax != 0)
            {
                var xChange = this.Spd;
                var xDir = xChange * this.Ax;
                var newX = (float)gameTime.ElapsedGameTime.TotalSeconds * xDir + this.Bp.X;
                this.Bp = new Vector2(newX, this.Bp.Y);
            }
            else
            {

                var yChange = this.Spd;
                var yDir = (yChange * this.Ay);
                var newY = (float)gameTime.ElapsedGameTime.TotalSeconds * yDir + this.Bp.Y;
                this.Bp = new Vector2(this.Bp.X, newY);
            }
       }
   }
}