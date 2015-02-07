using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace game
{
	public class sprite
	{
		public Vector2 location;
		public Vector2 velocity;
		public Texture2D texture;
		public bool isMoving;
		//public jumpSpeed;

		public sprite(Texture2D sprite, int x, int y) {
			this.location.X = x;
			this.location.Y = y;
			this.isMoving   = false;
			this.texture    = sprite;
		}

		public Rectangle BoundingBox {	
			get {
				return new Rectangle (
					(int)location.X,
					(int)location.Y,
					texture.Width,
					texture.Height);
			}
		}

		public void Move() {

			KeyboardState newState = Keyboard.GetState();

			if (newState.IsKeyDown (Keys.D)) {
				this.velocity.X = 1;
				this.isMoving = true;
			}
			if (newState.IsKeyDown (Keys.A)) {
				this.velocity.X = -1;
				this.isMoving = true;
			}
			if (newState.IsKeyDown (Keys.W)) {
				this.velocity.Y = -1;
				this.isMoving = true;
			}
			if (newState.IsKeyDown (Keys.S)) {
				this.velocity.Y = 1;
				this.isMoving = true;
			}
			if (newState.IsKeyDown (Keys.Space)) {
				this.velocity.Y = -5;
				this.isMoving = true;
			}

			this.location += this.velocity;
			this.velocity.X = 0;
			this.velocity.Y = 0;

		}

	}
}

