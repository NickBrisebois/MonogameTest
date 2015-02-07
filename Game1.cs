
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace game{

	public class Game1 : Game{
	
		//													      Variables
		//								    				  -------------------
		GraphicsDeviceManager graphics;	//					  - Graphic Manager
		SpriteBatch spriteBatch; //							  - Sprite Batch
		private Texture2D background; // 					  - Background Texture
		int[,] level1; //					                  - Level Code
		public List<sprite> sprites = new List<sprite>(); //  - Array of sprites
		public sprite player; //							  - The player's sprite

		public Game1 (){
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;	
			graphics.PreferredBackBufferHeight = 1200;
			graphics.PreferredBackBufferWidth  = 1200;
			graphics.ApplyChanges ();

			this.level1 = new int[10,10] {
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
			};

		}


		protected override void Initialize (){
			//Init Stuff
			base.Initialize ();
		}


		protected override void LoadContent (){
			//Load Stuff
			spriteBatch = new SpriteBatch (GraphicsDevice);
			background = Content.Load<Texture2D> ("background.png");
			player = new sprite(Content.Load<Texture2D>("player.png"),10, 10);

			int x = 0;
			int y = 0;
			foreach (int i in level1) {
				++y;
				sprites.Add (new sprite (Content.Load<Texture2D> ("player.png"), y*66, x*66));
			}
		}



		protected override void Update (GameTime gameTime){
			//Update Stuff
			player.Move ();

			if (player.isMoving) {
				for (int i = 0; i < sprites.Count; i++) {
					Console.Write ("-");
					CheckCollision (player, sprites [i]);
				}
				player.isMoving = false;
			}

			base.Update (gameTime);
		}



		protected override void Draw (GameTime gameTime){
			//Draw Stuff

			//Clear before drawing
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue); 
            
			//Start drawing images
			spriteBatch.Begin ();

			spriteBatch.Draw (background, new Rectangle (0, 0, 1920, 1080), Color.White);
			spriteBatch.Draw (player.texture, player.location, Color.White);
			for (int i = 0; i < sprites.Count; i++) {
				spriteBatch.Draw (sprites [i].texture, sprites [i].location, Color.White);
			}

			spriteBatch.End ();

			base.Draw (gameTime);
		}


		public void CheckCollision(sprite p1, sprite p2){
			if (p1.BoundingBox.Intersects (p2.BoundingBox)) {


			}
		}


	}
}

