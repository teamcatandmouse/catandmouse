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

        MainGame game = null;
        float playerSpeed = 12500f;
        //float playerMaxSpeed = 400f;
       // float playerCurrentSpeed = 0f;
        Vector2 playerPosition = new Vector2(0, 0);
        Vector2 playerVelocity = new Vector2(0, 0);
        Vector2 playerOffset = new Vector2(0, 0);
        bool playerAlive = false;

        public Player()
        {

        }

        public void Load(ContentManager content, MainGame theGame)
        {
            playerSprite.Load(content, "Mouse", true);
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
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) == true)
            {
                localAcceleration.X = playerSpeed;
            }

            playerSprite.velocity = localAcceleration * deltaTime;
            playerSprite.position += playerSprite.velocity * deltaTime;

        }





    }
}
