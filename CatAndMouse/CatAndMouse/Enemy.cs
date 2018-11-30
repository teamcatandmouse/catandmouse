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

        public String myTexture;

        public float xwalkSpeed = 0f;
        public float ywalkSpeed = 0f;
        
        Collision collisions = new Collision();
        MainGame game = null;
        

        public void Load(ContentManager content, MainGame game)
        {
            //enemySprite.Load(content, "WCat", true);
            this.game = game;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, myTexture, 1, 0);
            enemySprite.AddAnimation(animation, 0, 1);
            enemySprite.Pause();

            enemySprite.velocity = Vector2.Zero;
            //enemySprite.position = new Vector2(game.GraphicsDevice.Viewport.Width / 200, 0);

            enemySprite.isEnemy = true;

        }

        public void Update(float deltaTime)
        {
            enemySprite.velocity = new Vector2(xwalkSpeed, ywalkSpeed);

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
