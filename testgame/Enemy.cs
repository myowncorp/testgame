using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testgame.Desktop
{
	public class Enemy
	{
		public Enemy(Texture2D enemyTexture,
								 float enemySpeed,
								 int enemyDamage,
								 Path path)
		{
			Skin = enemyTexture;
			Speed = enemySpeed;
			Dmg = enemyDamage;
			Path = path ?? throw new ArgumentNullException();
		}

		public int Dmg { get; set; }
		public Path Path { get; }
		public Vector2 Pos => Path.GetLocationAtTime(pathPosition);
		public Texture2D Skin { get; set; }
		public float Speed { get; set; }

		public void UpdPos(GameTime time)
		{
			if (Path != null) pathPosition += (float)time.ElapsedGameTime.TotalSeconds * Speed;
		}

		private float pathPosition;
	}
}