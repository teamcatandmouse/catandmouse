using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;


namespace CatAndMouse
{
   public class Player
    {
        Sprite playerSprite = new Sprite();
        
        MainGame game = null;
        float playerSpeed = 175;
        float playerRotateSpeed = 5;
        Vector2 playerPosition = new Vector2(0, 0);
        Vector2 playerOffset = new Vector2(0, 0);
        float playerAngle = 0;
        bool playerAlive = false;

        public Player()
        {

        }

        public void Load(ContentManager content, MainGame theGame)
        {
            playerSprite.Load(content, "Mouse", true);
        }

        public void Update(float deltaTime)
        {
            playerSprite.Update(deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch);
        }





    }
}
