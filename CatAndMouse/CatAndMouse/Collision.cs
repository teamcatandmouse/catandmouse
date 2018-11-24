using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
			Sprite playerPrediction = new Sprite();

			if  (IsColliding(hero, other))
           {
                if (other.isEnemy == true)
                {
                    game.Exit();
                }
                else if (other.isCollectable == true)
                {

				}
           }

            return hero;

               
        }






		/*
		 Sprite CollideLeft(Sprite hero, MainGame game)
		 {

		 }

		 Sprite CollideRight(Sprite hero, MainGame game)
		 {

		 }

		 Sprite CollideTop(Sprite hero, MainGame game)
		 {

		 }

		 Sprite CollideBottom(Sprite hero, MainGame game)
		 {

		 }
		 */

		public Sprite CollideWithCollect(Player cheese, Collectable collect, float deltaTime, MainGame theGame)
		{
			Sprite playerPrediction = new Sprite();
			playerPrediction.position = cheese.playerSprite.position;
			playerPrediction.objectWidth = cheese.playerSprite.objectWidth;
			playerPrediction.objectHeight = cheese.playerSprite.objectHeight;
			playerPrediction.offset = cheese.playerSprite.offset;
			playerPrediction.UpdateHitBox();

			playerPrediction.position += cheese.playerSprite.velocity * deltaTime;
			if (IsColliding(playerPrediction, collect.collectSprite))
			{
				theGame.collectable.Remove(collect);
				theGame.score += 10;

			}
			return cheese.playerSprite;
		}

	}
}
