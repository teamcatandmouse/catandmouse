using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

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


		public Sprite CollideWithCollect(Player player, Collectable collect, float deltaTime, MainGame theGame)
		{
			Sprite playerPrediction = new Sprite();
			playerPrediction.position = player.playerSprite.position;
			playerPrediction.objectWidth = player.playerSprite.objectWidth;
			playerPrediction.objectHeight = player.playerSprite.objectHeight;
			playerPrediction.offset = player.playerSprite.offset;
			playerPrediction.UpdateHitBox();

			playerPrediction.position += player.playerSprite.velocity * deltaTime;
			if (IsColliding(playerPrediction, collect.collectSprite))
			{
				if (collect.collectableType == (int)Collectable.CollectableType.cheese)
				{
					theGame.collectables.Remove(collect);
					theGame.score += 10;
					//getSoundInstance.Play();
				}

				

				else if (collect.collectableType == (int)Collectable.CollectableType.extraLife)
				{
					theGame.collectables.Remove(collect);
					theGame.lives += 1;
					//getSoundInstance.Play();
				}

				else if (collect.collectableType == (int)Collectable.CollectableType.moreCheese)
				{
					theGame.collectables.Remove(collect);
					theGame.score += 30;
					//getSoundInstance.Play();
				}

				else if (collect.collectableType == (int)Collectable.CollectableType.fasterPlayer)
				{
					theGame.collectables.Remove(collect);
					theGame.player.playerSpeed += 10000;
					//getSoundInstance.Play();
				}


			}
			return player.playerSprite;
		}

	}
}
