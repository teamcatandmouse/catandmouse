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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;




namespace CatAndMouse
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Player player = new Player();
        //public Enemy enemy = new Enemy();
        public Cat cat = new Cat();
        public CatSpawn catSpawn = new CatSpawn();

		SoundEffect getSound;
		SoundEffectInstance getSoundInstance;


		TiledMap map = null;
        TiledMapRenderer mapRenderer = null;

		Song gameMusic;

        Texture2D gameOver = null;
        Texture2D title = null;
        Texture2D howToPlay = null;
        SpriteFont scoreFont;
        public int score = 0;
        public int lives = 3;
        Texture2D heart = null;

        const int STATE_SPLASH = 0;
        const int STATE_INST = 1;
        const int STATE_GAME = 2;
        const int STATE_GAMEOVER = 3;

        int gameState = STATE_SPLASH;

		public float collectableSpawnTimer = 6.0f;
		float collectableSpawnDefaultTime = 6.0f;

		public ArrayList collectables = new ArrayList();

        public bool resetCats = false;

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

           

            player.Load(Content, this);
            cat.Load(Content, this);
            catSpawn.Load(Content, this);
            //collectable.Load(Content, this);

            //scoreFont = Content.Load<SpriteFont>("Score");


            scoreFont = Content.Load<SpriteFont>("Arial");
            heart = Content.Load<Texture2D>("Heart");
            map = Content.Load<TiledMap>("Level");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);


			gameMusic = Content.Load<Song>("fast_music");
			MediaPlayer.Play(gameMusic);

			getSound = Content.Load<SoundEffect>("get");
			getSoundInstance = getSound.CreateInstance();

            gameOver = Content.Load<Texture2D>("GameOver");
            title = Content.Load<Texture2D>("Title2");
            howToPlay = Content.Load<Texture2D>("HTP");
            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

     

            switch (gameState)
            {
                case STATE_SPLASH:
                    UpdateSplashState(deltaTime);
                    break;
                case STATE_INST:
                    UpdateInstState(deltaTime);
                    break;
                case STATE_GAME:
                    UpdateGameState(deltaTime);
                    break;
                case STATE_GAMEOVER:
                    UpdateGameOverState(deltaTime);
                    break;
            }

            base.Update(gameTime);

        }


        private void UpdateSplashState(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                gameState = STATE_GAME;
               
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.RightShift) == true) 
            {
                gameState = STATE_INST;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) == true)
            {
                gameState = STATE_INST;
            }
        }

       private void DrawSplashState(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            mapRenderer.Draw(map);
            spriteBatch.Draw(title, Vector2.Zero, Color.White);         
            spriteBatch.End();

        }

        private void UpdateInstState(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                gameState = STATE_GAME;
                InitGame();
            }
        }

        private void DrawInstState(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(howToPlay, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        public void UpdateGameState(float deltaTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(deltaTime);
            catSpawn.Update(deltaTime);

            if (resetCats == false)
            {
                foreach (Cat cat in catSpawn.spawnedCats)
                {
                    cat.Update(deltaTime);
                }
            }

            else if (resetCats == true)
            {
                catSpawn.spawnedCats.Clear();
                resetCats = false;
            }
            

            //cat.Update(deltaTime);

            CheckForCollectableSpawn(deltaTime);


            foreach (Collectable Cheese in collectables)
            {
                Cheese.Update(deltaTime);
            }

            if (lives <= 0)
            {
                
                gameState = STATE_GAMEOVER;

            }

            
            // TODO: Add your update logic here


        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
  

       void DrawGameState(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            mapRenderer.Draw(map);
            player.Draw(spriteBatch);
            cat.Draw(spriteBatch);

            if (resetCats == false)
            {
                foreach (Cat cat in catSpawn.spawnedCats)
                {
                    cat.Draw(spriteBatch);
                }
            }
         


            foreach (Collectable Cheese in collectables)
            {
                Cheese.Draw(spriteBatch);
            }

            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.DrawString(scoreFont, "Score: " + score.ToString(), new Vector2(28, 15), Color.DarkBlue);
            
            int loopCount = 0;

            while (loopCount < lives)
            {
                spriteBatch.Draw(heart, new Vector2(GraphicsDevice.Viewport.Width - 70 - loopCount * 69, 23),
                    Color.White);

                loopCount++;
            }

            spriteBatch.End();

         
            
        }

       

        private void UpdateGameOverState(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                gameState = STATE_INST;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                gameState = STATE_SPLASH;
            }

       
            



        }

        private void DrawGameOverState(SpriteBatch spriteBatch)
        {
    
            spriteBatch.Begin();
            mapRenderer.Draw(map);
            spriteBatch.Draw(gameOver, Vector2.Zero, Color.White);
            spriteBatch.DrawString(scoreFont, "Score: " + score.ToString(), new Vector2(325, 350), Color.DarkBlue);
            spriteBatch.End();

        }
        protected override void Draw(GameTime gameTime)
        {
            //spriteBatch.Begin();

            switch (gameState)
            {
                case STATE_SPLASH:
                    DrawSplashState(spriteBatch);
                    break;
                case STATE_INST:
                    DrawInstState(spriteBatch);
                    break;
                case STATE_GAME:
                    DrawGameState(spriteBatch);
                    break;
                case STATE_GAMEOVER:
                    DrawGameOverState(spriteBatch);
                    break;

            }

            //spriteBatch.End();

            base.Draw(gameTime);
        }

        void CheckForCollectableSpawn(float deltaTime)
		{
			collectableSpawnTimer -= deltaTime;

			if (collectableSpawnTimer <= 0)
			{
				Random rand = new Random();
				int randomCollect = rand.Next(1, 5);

				Collectable collect = new Collectable();

				switch (randomCollect)
				{
					case 1:
						collect.collectableType = 1;
						collect.Load(Content, this);
						
						collectables.Add(collect);

						break;

					

					case 2:
						collect.collectableType = (int)Collectable.CollectableType.extraLife;
						collect.Load(Content, this);
						
						collectables.Add(collect);

						break;


					case 3:
						collect.collectableType = (int)Collectable.CollectableType.fasterPlayer;
						collect.Load(Content, this);
						
						collectables.Add(collect);

						break;

					case 4:
						collect.collectableType = (int)Collectable.CollectableType.moreCheese;
						collect.Load(Content, this);
				
						collectables.Add(collect);

						break;
				}

				collectableSpawnTimer = collectableSpawnDefaultTime;
			}

		}

        void InitGame()
        {
            score = 0;
            lives = 3;
            catSpawn.spawnedCats.Clear();
            collectables.Clear();
        }


    }
}
