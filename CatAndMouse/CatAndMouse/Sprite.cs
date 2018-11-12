using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CatAndMouse
{
	public class Sprite
	{
		public Vector2 position = Vector2.Zero;
		public Vector2 velocity = Vector2.Zero;
		public Vector2 offset = Vector2.Zero;

		Texture2D texture;

		public int objectWidth = 0;
		public int objectHeight = 0;

		public int theLeft = 0;
		public int theRight = 0;
		public int theTop = 0;
		public int theBottom = 0;

		public Sprite()
		{

		}

		public void Load(ContentManager content, string asset, bool useOffset)
		{
			texture = content.Load<Texture2D>(asset);
			objectWidth = texture.Bounds.Width;
			objectHeight = texture.Bounds.Height;

			if (useOffset == true)
			{
				offset = new Vector2(theLeft + objectWidth / 2, theTop + objectHeight / 2);
			}

			UpdateHitBox();
		}

        public void Update(float deltaTime)
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position + offset, Color.White);
        }



		public void UpdateHitBox()
		{
			theLeft = (int)position.X - (int)offset.X;
			theRight = theLeft + objectWidth;
			theTop = (int)position.Y - (int)offset.Y;
			theBottom = theTop + objectHeight;
		}


	}
}