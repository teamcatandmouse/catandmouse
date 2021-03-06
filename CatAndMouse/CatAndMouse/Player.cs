﻿using System;
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
		public Sprite playerSprite = new Sprite();

		Collision collision = new Collision();

		MainGame game = null;
		public float playerSpeed = 12500f;
		float defaultPlayerSpeed = 12500f;
		public float speedMultiplyer = 1.5f;
		float fasterPlayer = 0f;
		float defaultFastPlayerTimer = 5f;
		//float playerMaxSpeed = 400f;
		// float playerCurrentSpeed = 0f;
		public Vector2 playerPosition = new Vector2(0, 0);
		Vector2 playerVelocity = new Vector2(0, 0);
		Vector2 playerOffset = new Vector2(0, 0);
		bool playerAlive = false;
		public bool isFaster = false;

		public Player()
		{

		}

		public void Load(ContentManager content, MainGame theGame)
		{
			playerSprite.Load(content, "Mouse", true);
			AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
			animation.Load(content, "M_WalkRight", 3, 5);
			playerSprite.AddAnimation(animation, 0, 1);
			playerSprite.Pause();

			game = theGame;

			playerSprite.velocity = Vector2.Zero;

			playerSprite.velocity = Vector2.Zero;
			playerSprite.position = new Vector2(theGame.GraphicsDevice.Viewport.Width / 2, theGame.GraphicsDevice.Viewport.Height / 2);

		}

		public void Update(float deltaTime)
		{
			UpdateInput(deltaTime);
			playerSprite.Update(deltaTime);
			playerSprite.UpdateHitBox();


            if (game.resetCats == false)
            {
                foreach (Cat cat in game.catSpawn.spawnedCats)
                {
                    playerSprite = collision.CollideWithObject(playerSprite, cat.enemy.enemySprite, game);
                }
            }

			for (int i = 0; i < game.collectables.Count; i++)
			{
				playerSprite = collision.CollideWithCollect(this, (Collectable)game.collectables[i], deltaTime, game);
			}

			if (isFaster ==true && fasterPlayer <= 0)
			{
				fasterPlayer = defaultFastPlayerTimer;
				playerSpeed *= speedMultiplyer;
			}

			CheckFastPlayerTimer(deltaTime);

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			playerSprite.Draw(spriteBatch);
		}

		private void UpdateInput(float deltaTime)
		{
			Vector2 localAcceleration = new Vector2(0, 0);

			if (Keyboard.GetState().IsKeyDown(Keys.Up) == true)
			{

				localAcceleration.Y = -playerSpeed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Down) == true)
			{
				localAcceleration.Y = playerSpeed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Left) == true)
			{
				localAcceleration.X = -playerSpeed;
				playerSprite.SetFlipped(true);
				playerSprite.Play();
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Right) == true)
			{

				localAcceleration.X = playerSpeed;
				playerSprite.SetFlipped(false);
				playerSprite.Play();
			}
			if (Keyboard.GetState().IsKeyUp(Keys.Right) == true && Keyboard.GetState().IsKeyUp(Keys.Left) == true)
			{
				playerSprite.Pause();
			}


			playerSprite.velocity = localAcceleration * deltaTime;
			playerSprite.position += playerSprite.velocity * deltaTime;

			if (playerSprite.position.X <= 0)
			{
				playerSprite.position.X = 0;
			}
			if (playerSprite.position.X + playerSprite.objectWidth >= game.GraphicsDevice.Viewport.Width)
			{
				playerSprite.position.X = game.GraphicsDevice.Viewport.Width - playerSprite.objectWidth;
			}
			if (playerSprite.position.Y <= 0)
			{
				playerSprite.position.Y = 0;
			}
			if (playerSprite.position.Y + playerSprite.objectHeight >= game.GraphicsDevice.Viewport.Height)
			{
				playerSprite.position.Y = game.GraphicsDevice.Viewport.Height - playerSprite.objectHeight;
			}


		}

		private void CheckFastPlayerTimer(float deltaTime)
		{
			if (fasterPlayer > 0)
			{
				fasterPlayer = deltaTime;
			}

			if (fasterPlayer <= 0)
			{
				isFaster = false;
				playerSpeed = defaultPlayerSpeed;
			}

		}





    }
}
