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
    public class Powerup 
    {
		public Sprite powerSprite = new Sprite();
		Collision collision = new Collision();
		MainGame game = null;

		public float despawnTimer = 5.0f;
		public int powerNumber = 0;


		public void Load(ContentManager content, MainGame theGame)
		{

			game = theGame;


			Random random = new Random();


			float RandomX = random.Next(0, game.GraphicsDevice.Viewport.Width);
			float RandomY = random.Next(0, game.GraphicsDevice.Viewport.Height);


			powerSprite.position = new Vector2(RandomX, RandomY);
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			powerSprite.Draw(spriteBatch);
		}

		public void Update(float deltaTime)
		{
			collision.game = game;
			powerSprite.UpdateHitBox();


			despawnTimer -= deltaTime;

			if (despawnTimer <= 0)
			{
				
			}

		}
	}
}
