using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CatAndMouse
{
   public class Cat
    {
        MainGame game = null;
        public Enemy enemy = new Enemy();

        Random random = new Random();

        int nextPosX;
        int nextPosY;


        public void Load(ContentManager content, MainGame game)
        {
            int catType = random.Next(1, 4);

            switch (catType)
            {
                case 1:
                    // UpCat
                    enemy.myTexture = "WCat";
                    enemy.ywalkSpeed = -100f;

                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    enemy.enemySprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;
                case 2:
                    // DownCat
                    enemy.myTexture = "BCat";
                    enemy.ywalkSpeed = 100f;

                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    enemy.enemySprite.position = new Vector2(nextPosX, 0);
                    break;
                case 3:
                    // LeftCat
                    enemy.myTexture = "WCat";
                    enemy.xwalkSpeed = -100f;

                    nextPosY = random.Next(0, game.GraphicsDevice.Viewport.Height);
                    enemy.enemySprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, nextPosY);
                    break;
                case 4:
                    // RightCat
                    enemy.myTexture = "BCat";
                    enemy.xwalkSpeed = 100f;

                    nextPosY = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    enemy.enemySprite.position = new Vector2(0, nextPosY);
                    break;


            }

            

            enemy.Load(content, game);
        }

        public void Update(float deltaTime)
        {
            enemy.Update(deltaTime);
            /*
            switch (catType)
            {
                case 1:
                    //upCat
                    if (enemy.enemySprite.position.Y < 0)
                    {
                        game.catSpawn.spawnedCats.Remove(this);
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
            */

            //if (enemy.enemySprite.position)
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemy.Draw(spriteBatch);
        }
    }
}
