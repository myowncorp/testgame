using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace testgame.Desktop

{
    public class Enemy
    {
        
        public Texture2D      Skin;  
        public Vector2        Pos;
        public float          Spd; 
        public int            Ax;
        public int            Ay;
        public int            Dmg;
        public List<Vector2>  Path;



        public Enemy(Texture2D     enemyTexture,
                     Vector2       enemyPos,
                     float         enemySpeed,
                     int           enemyXAccel,
                     int           enemyYAccel,
                     int           enemyDamage,
                     List<Vector2> enemyPath
                     ){


            Skin = enemyTexture;
            Pos  = enemyPos;
            Spd  = enemySpeed;
            Ax   = enemyXAccel;
            Ay   = enemyYAccel;
            Dmg  = enemyDamage;
            Path = enemyPath;
        }

        public void UpdPos(){ }
    }
}
