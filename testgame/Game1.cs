using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace testgame.Desktop
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		public List<Vector2> testPattern;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.WhiteSmoke);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(
					player.Skin,
					player.Pos,
					Color.White);

			foreach (Bullet bullet in playerShots)
			{
				spriteBatch.Draw(
				bullet.BullText, bullet.Bp, Color.White);
			}
			foreach (Enemy enemy in enemyOnScreen)
			{
				spriteBatch.Draw(
				enemy.Skin, enemy.Pos, Color.White);
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run. This is
		/// where it can query for any required services and load any non-graphic related content.
		/// Calling base.Initialize will enumerate through any components and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			player = new Ball(Content.Load<Texture2D>("ball"),
							 new Vector2(graphics.PreferredBackBufferWidth / 2,
													 graphics.PreferredBackBufferHeight / 2),
												100f,
												0,
												0);
			enemyOnScreen.Add(CreateEnemy());
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			ballTexture = Content.Load<Texture2D>("ball");
			blueBullet = Content.Load<Texture2D>("blue-bullet");
			redEnemyText = Content.Load<Texture2D>("red-enemy");
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world, checking for collisions, gathering
		/// input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			Bullet bt;
			//new Path(new Vector2(100, -300), new Vector2(0, -200), new Vector2(100, -100)));
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic herevar kstate = Keyboard.GetState();
			var kstate = Keyboard.GetState();
			var gTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kstate.IsKeyDown(Keys.Up))
			{
				player.Pos.Y -= player.Spd * gTime;
				player.Ay = -1;
				player.Ax = 0;
			}
			if (kstate.IsKeyDown(Keys.Down))
			{
				player.Pos.Y += player.Spd * gTime;
				player.Ay = 1;
				player.Ax = 0;
			}
			if (kstate.IsKeyDown(Keys.Left))
			{
				player.Pos.X -= player.Spd * gTime;
				player.Ax = -1;
				player.Ay = 0;
			}
			if (kstate.IsKeyDown(Keys.Right))
			{
				player.Pos.X += player.Spd * gTime;
				player.Ax = 1;
				player.Ay = 0;
			}

			if (kstate.IsKeyDown(Keys.Space))
			{
				if (bullCounter <= 0)
				{
					bt = new Bullet(blueBullet, new Vector2(player.Pos.X, player.Pos.Y), player.Ax, player.Ay, 250, 50, .5);
					playerShots.Add(bt);           // Add the bullet to the batch that will be drawn
					bullCounter = bt.Interval;     // make the counter = to the bulltets firerat
				}
			}

			bullCounter -= gTime;

			player.UpdPos(gameTime, graphics);

			foreach (Bullet bullet in playerShots)
			{
				bullet.UpdPos(gameTime);
			}
			foreach (var enemy in enemyOnScreen)
			{
				enemy.UpdPos(gameTime);
			}

			base.Update(gameTime);
		}

		private Texture2D ballTexture;

		// graphic inits
		private Texture2D blueBullet;

		private double bullCounter = 0;

		private List<Enemy> enemyOnScreen = new List<Enemy>();

		private GraphicsDeviceManager graphics;

		private Ball player;

		private List<Bullet> playerShots = new List<Bullet>();

		private Texture2D redEnemyText;

		private SpriteBatch spriteBatch;

		private Enemy CreateEnemy()
		{
			return new Enemy(
					Content.Load<Texture2D>("red-enemy"),
					1,
					1,
					new Path(
						new Vector2(),
						new Vector2(400, 100),
						new Vector2(100, 300)
			));
		}

		// this counts the shot interval it will be set to .5 for example
	}
}