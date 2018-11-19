using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CatAndMouse
{
    class Collision
    {
        public MainGame game;
        
        


        public bool IsColliding(Sprite hero, Sprite otherSprite)
        {
            if (hero.theRight < otherSprite.theLeft ||
                hero.theLeft > otherSprite.theRight ||
                hero.theBottom < otherSprite.theTop ||
                hero.theTop > otherSprite.theBottom)
            {
                return false;
            }

            return true;
        }

        public Sprite CollideWithObject(Sprite hero, Sprite other, MainGame game)
        {
           if  (IsColliding(hero, other))
           {
                if (other.isEnemy == true)
                {
                    theGame.Exit;
                }
                else if (other.isCollectable == true)
                {

                }
           }

            return hero;

               
        }



    }
}
