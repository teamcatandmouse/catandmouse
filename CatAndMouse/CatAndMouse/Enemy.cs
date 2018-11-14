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
    public class Enemy
    {
        public Sprite enemySprite = new Sprite();

        Texture2D myTexture;

        //float walkSpeed = 7500f;       
        Vector2 enemyVelocity = new Vector2(0, 0);
        Vector2 enemyOffset = new Vector2(0, 0);


        Collision collisions = new Collision();
        MainGame game = null;

        public void Load(ContentManager content, MainGame game)
        {
            enemySprite.Load(content, "WCat", true);
            this.game = game;

            enemySprite.velocity = Vector2.Zero;
            enemySprite.position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, 2);       

        }

        public void Update(float deltaTime)
        {
           // enemySprite.velocity = new Vector2(walkSpeed, 0) * deltaTime;
            enemySprite.position += enemySprite.velocity * deltaTime;




            enemySprite.Update(deltaTime);
            enemySprite.UpdateHitBox();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemySprite.Draw(spriteBatch);
        }



    }
}
