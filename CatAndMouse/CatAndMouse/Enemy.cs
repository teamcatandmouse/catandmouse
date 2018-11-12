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
        float walkSpeed = 7500f;
        public Sprite enemySprite = new Sprite();
        Collision collisions = new Collision();
        MainGame game = null;

        public void Load(ContentManager content, MainGame game)
        {
            this.game = game;

            
            animation.Load(content, "", 4, 5);


            enemySprite.AddAnimation(animation, 16, 0);
            enemySprite.width = 64;
            enemySprite.height = 64;
            enemySprite.offset = new Vector2(8, 8);

        }

        public void Update(float deltaTime)
        {
            enemySprite.velocity = new Vector2(walkSpeed, 0) * deltaTime;
            enemySprite.position += enemySprite.velocity * deltaTime;

            collisions.game = game;
            




        }




    }
}
