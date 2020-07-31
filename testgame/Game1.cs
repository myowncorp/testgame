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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Bullet> playerShots = new List<Bullet>();
        // blueBullet
        Texture2D blueBullet;

        // Ball
        Texture2D ballTexture;
        Vector2 ballPosition;
        float ballSpeed;
        int ballXAccel;
        int ballYAccel;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(graphics.PreferredBackBufferWidth / 2,
                 graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;
            ballXAccel = 0;
            ballYAccel = 0;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
            blueBullet = Content.Load<Texture2D>("blue-bullet");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Bullet bt;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic herevar kstate = Keyboard.GetState();
            var kstate = Keyboard.GetState();
            var gTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            ballPosition = ballPositioner(ballPosition);
            if (kstate.IsKeyDown(Keys.Up))
            {
                ballPosition.Y -= ballSpeed * gTime;
                ballYAccel = -1;
                ballXAccel =  0;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                ballPosition.Y += ballSpeed * gTime;
                ballYAccel = 1;
                ballXAccel = 0;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                ballPosition.X -= ballSpeed * gTime;
                ballXAccel = -1;
                ballYAccel =  0;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                ballPosition.X += ballSpeed * gTime;
                ballXAccel = 1;
                ballYAccel = 0;
            }
            if (kstate.IsKeyDown(Keys.Space))
            {
                bt = new Bullet(blueBullet, new Vector2(ballPosition.X, ballPosition.Y), ballXAccel, ballYAccel, 250);
                playerShots.Add(bt);
            }

           
            Vector2 ballPositioner(Vector2 bp)
            {
                Vector2 newBp;

                newBp.X = ballPosX(bp.X);
                newBp.Y = ballPosY(bp.Y);

                float ballPosX(float x)
                {
                    float newX;

                    if (ballCollideX(x))
                        newX = graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
                    else
                        newX = x;

                    return newX;
                }

                float ballPosY(float y)
                {
                    float newY;

                    if (ballCollideY(y))
                        newY = graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                    else
                        newY = y;

                    return newY;
                }

                bool ballCollideX(float x)
                {
                    if (x > (graphics.PreferredBackBufferWidth - ballTexture.Width / 2))
                        return true;
                    else if (x < (0 + ballTexture.Width / 2))
                        return true;
                    else
                        return false;
                }

                bool ballCollideY(float y)
                {
                    if (y > (graphics.PreferredBackBufferHeight - ballTexture.Height / 2))
                        return true;
                    else
                        return false;
                }

                return newBp;
            }
           
            foreach (Bullet bullet in playerShots)
            {
                bullet.UpdPos(gameTime);
            }



            base.Update(gameTime);
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
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
            foreach (Bullet bullet in playerShots)
            {
                spriteBatch.Draw(
                bullet.BullText, bullet.Bp, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
