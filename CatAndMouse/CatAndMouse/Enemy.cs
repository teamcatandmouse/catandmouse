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

        float walkSpeed = 300f;       
        
        Collision collisions = new Collision();
        MainGame game = null;

        public void Load(ContentManager content, MainGame game)
        {
            //enemySprite.Load(content, "WCat", true);
            this.game = game;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "WCat", 1, 0);
            enemySprite.AddAnimation(animation, 0, 1);
            enemySprite.Pause();

            enemySprite.velocity = Vector2.Zero;
            enemySprite.position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, 2);       

        }

        public void Update(float deltaTime)
        {
            enemySprite.velocity = new Vector2(0, walkSpeed);

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
