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

		public void Load(ContentManager content, MainGame theGame)
		{
			game = theGame;

			AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
			animation.Load(content, "Cheese", 1, 1);

			collectSprite.AddAnimation(animation, 0, 3);

            collectSprite.isCollectable = true;
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			collectSprite.Draw(spriteBatch);
		}
		public void Update(float deltaTime)
		{
			collision.game = game;
			collectSprite.UpdateHitBox();
		}
	}
}
