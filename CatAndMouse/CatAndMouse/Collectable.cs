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
	public class Collectable
	{
		public Sprite collectSprite = new Sprite();
		Collision collision = new Collision();
		MainGame game = null;

		public float despawnTimer = 5.0f;
		public int cheeseNumber = 0;

		public enum CollectableType { cheese = 1, extraLife = 2, fasterPlayer = 3, moreCheese = 4, }
			
		
		public int collectableType;

		public void Load(ContentManager content, MainGame theGame)
		{
			game = theGame;

			AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
			switch (collectableType)
			{
				case (int)CollectableType.cheese:
					animation.Load(content, "Cheese", 1, 1);
					break;

				case (int)CollectableType.extraLife:
					animation.Load(content, "PU_Life", 1, 1);
					break;

				case (int)CollectableType.fasterPlayer:
					animation.Load(content, "PU_FastPlayer", 1, 1);
					break;

				case (int)CollectableType.moreCheese:
					animation.Load(content, "PU_Cheese", 1, 1);
					break;


				case (int)CollectableType.SloMo:
					animation.Load(content, "PU_Cats", 1, 1);
					break;
			}

			

			collectSprite.AddAnimation(animation, 0, 3);

            collectSprite.isCollectable = true;

			Random random = new Random();
			

			float RandomX = random.Next(0, game.GraphicsDevice.Viewport.Width);
			float RandomY = random.Next(0, game.GraphicsDevice.Viewport.Height);


			collectSprite.position = new Vector2(RandomX, RandomY) ;

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			collectSprite.Draw(spriteBatch);
		}
		public void Update(float deltaTime)
		{
			collision.game = game;
			collectSprite.UpdateHitBox();

			despawnTimer -= deltaTime;

			if (despawnTimer <= 0)
			{

			}
		}
	}
}
