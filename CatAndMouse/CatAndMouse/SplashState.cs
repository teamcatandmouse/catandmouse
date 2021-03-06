﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CatAndMouse
{
   public class SplashState : AIE.State
   {
        SpriteFont font = null;
        float timer = 3;
            
        public SplashState() : base()
        {

        }

        public override void Update(ContentManager content, GameTime gameTime)
        { if (font == null)
            { font = content.Load<SpriteFont>("Arial"); } timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                AIE.StateManager.ChangeState("GAME");
                timer = 3;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(); spriteBatch.DrawString(font, "Splash", new Vector2(200, 200), Color.White); spriteBatch.End();
        }

        public override void CleanUp()
        {
            font = null;
            timer = 3;
        }

   }
}
