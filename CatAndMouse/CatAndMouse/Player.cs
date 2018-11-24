using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;


namespace CatAndMouse
{
   class Player
    {
        public Sprite playerSprite = new Sprite();

        Collision collision = new Collision();

        MainGame game = null;
        float playerSpeed = 12500f;
        //float playerMaxSpeed = 400f;
       // float playerCurrentSpeed = 0f;
        public Vector2 playerPosition = new Vector2(0, 0);
        Vector2 playerVelocity = new Vector2(0, 0);
        Vector2 playerOffset = new Vector2(0, 0);
        bool playerAlive = false;

        public Player()
        {

        }

        public void Load(ContentManager content, MainGame theGame)
        {
            playerSprite.Load(content, "Mouse", true);
            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "M_WalkRight", 3, 5);
            playerSprite.AddAnimation(animation, 0, 1);
            playerSprite.Pause();

            game = theGame;

            playerSprite.velocity = Vector2.Zero;

            playerSprite.velocity = Vector2.Zero;
            playerSprite.position = new Vector2(theGame.GraphicsDevice.Viewport.Width / 2, 0);
           
        }

        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
            playerSprite.UpdateHitBox();

            playerSprite = collision.CollideWithObject(playerSprite, game.enemy.enemySprite, game);


			for (int i = 0; i < game.collectables.Count; i++)
			{
				playerSprite = collision.CollideWithCollect(this, game.collectables[i], deltaTime, game);
			}
		}

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch);
        }

        private void UpdateInput(float deltaTime)
        {
            Vector2 localAcceleration = new Vector2(0, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Up) == true)
            {

                localAcceleration.Y = -playerSpeed;                                            
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) == true)
            {
                localAcceleration.Y = playerSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) == true)
            {
                localAcceleration.X = -playerSpeed;
                playerSprite.SetFlipped(true);
                playerSprite.Play();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) == true)
            {

                localAcceleration.X = playerSpeed;
                playerSprite.SetFlipped(false);
                playerSprite.Play();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Right) == true && Keyboard.GetState().IsKeyUp(Keys.Left) == true)
            {
                playerSprite.Pause();
            }


            playerSprite.velocity = localAcceleration * deltaTime;
            playerSprite.position += playerSprite.velocity * deltaTime;

        }





    }
}
