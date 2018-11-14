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
	class Sprite
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

        List<AnimatedTexture> animations = new List<AnimatedTexture>();
        List<Vector2> animationOffsets = new List<Vector2>();
        int currentAnimation = 0;

        SpriteEffects effects = SpriteEffects.None;

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

        public void AddAnimation(AnimatedTexture animation, int xOffset = 0, int yOffset = 0)
        {
            animations.Add(animation);
            animationOffsets.Add(new Vector2(xOffset, yOffset));
        }

        public void Update(float deltaTime)
        {
            animations[currentAnimation].UpdateFrame(deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spritebatch.Draw(texture, position + offset, Color.White);
            animations[currentAnimation].DrawFrame(spriteBatch, position + animationOffsets[currentAnimation], effects);
        }



		public void UpdateHitBox()
		{
			theLeft = (int)position.X - (int)offset.X;
			theRight = theLeft + objectWidth;
			theTop = (int)position.Y - (int)offset.Y;
			theBottom = theTop + objectHeight;
		}

        public void SetFlipped(bool state)
        {
            if (state == true)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effects = SpriteEffects.None;
            }
        }
      
        public void Pause()
        {
            animations[currentAnimation].Pause();
        }

        public void Play()
        {
            animations[currentAnimation].Play();
        }


	}
}