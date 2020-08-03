using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testgame.Desktop
{
    public class MovePattern
    {
        public Texture2D Pattern;
        public List<Vector2> Lop;
        public MovePattern(Texture2D pattern, List<Vector2> listofpoints)
        {
            Pattern = pattern;
            Lop     = listofpoints;
            
        }
    }
}
