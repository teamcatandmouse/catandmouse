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

        Texture2D texture;

        float walkSpeed = 7500f;
        Collision collisions = new Collision();
        MainGame game = null;

        public void Load(ContentManager content, MainGame game)
        {
            enemySprite.Load(content, "BCat", true);
            this.game = game;

            enemySprite.velocity = Vector2.Zero;
            //enemySprite.position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, 0);       

        }

        public void Update(float deltaTime)
        {
            collisions.game = game;
            enemySprite.Update(deltaTime);
            enemySprite.UpdateHitBox();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemySprite.Draw(spriteBatch);
        }



    }
}
