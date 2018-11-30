using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended.ViewportAdapters;
using System.Collections;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;




namespace CatAndMouse
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player();
        //public Enemy enemy = new Enemy();
        public Cat cat = new Cat();
        public CatSpawn catSpawn = new CatSpawn();


        TiledMap map = null;
        TiledMapRenderer mapRenderer = null;


        SpriteFont scoreFont;
        public int score = 0;
        public int lives = 3;
        Texture2D heart = null;

		

		public float collectableSpawnTimer = 6.0f;
		float collectableSpawnDefaultTime = 6.0f;

		public ArrayList collectables = new ArrayList();
		

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 768;
            graphics.PreferredBackBufferHeight = 672;
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
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AIE.StateManager.CreateState("SPLASH", new SplashState());
            AIE.StateManager.CreateState("GAME", new SplashState());
            AIE.StateManager.CreateState("GAMEOVER", new SplashState());

            AIE.StateManager.PushState("SPLASH");

            player.Load(Content, this);
            cat.Load(Content, this);
            catSpawn.Load(Content, this);
			//collectable.Load(Content, this);

            //scoreFont = Content.Load<SpriteFont>("Score");


            scoreFont = Content.Load<SpriteFont>("Arial");
            heart = Content.Load<Texture2D>("Heart");
            map = Content.Load<TiledMap>("Level");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);

            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            AIE.StateManager.Update(Content, gameTime);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            player.Update(deltaTime);
            catSpawn.Update(deltaTime);

            foreach(Cat cat in catSpawn.spawnedCats)
            {
                cat.Update(deltaTime);
            }

            //cat.Update(deltaTime);

			CheckForCollectableSpawn(deltaTime);

            
			foreach (Collectable Cheese in collectables)
			{
				Cheese.Update(deltaTime);
			}
            

			// TODO: Add your update logic here

			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            AIE.StateManager.Draw(spriteBatch);

            spriteBatch.Begin();
            mapRenderer.Draw(map);           

            player.Draw(spriteBatch);
            cat.Draw(spriteBatch);
            
			foreach (Collectable Cheese in collectables)
			{
				Cheese.Draw(spriteBatch);
			}
            

			spriteBatch.DrawString(scoreFont, "Score: " + score.ToString(), new Vector2(28, 15), Color.DarkBlue);

            int loopCount = 0;

            while (loopCount < lives)
            {
                spriteBatch.Draw(heart, new Vector2(GraphicsDevice.Viewport.Width - 70 - loopCount * 69, 23),
                    Color.White);

                loopCount++;
            }
			spriteBatch.End();
           

            base.Draw(gameTime);
        }

		void CheckForCollectableSpawn(float deltaTime)
		{
			collectableSpawnTimer -= deltaTime;

			if (collectableSpawnTimer <= 0)
			{
				Random rand = new Random();
				int randomCollect = rand.Next(1, 5);

				switch (randomCollect)
				{

				}
			}
			
		}

    }
}
