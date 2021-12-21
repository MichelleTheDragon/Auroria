using Auroria.Output;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class PlayerObject : GameObject
    {

        #region Fields

        private float speed = 200.0f;
        public float Speed { get { return speed; } }
        private Vector2 movement = Vector2.Zero;
        public Vector2 Movement { get { return movement; } set { movement = value; } }

        private GameWorld myWorld;

        #endregion
        #region Properties
        #endregion
        #region Constructors

        public PlayerObject(Texture2D[] sprites, Vector2 worldPos, GameWorld myWorld) : base(sprites[0], null, worldPos, false)
        {
            this.myWorld = myWorld;
            this.sprites = sprites;
        }

        #endregion
        #region Methods

        public override void Update(GameTime gameTime)
        {
        }



        public void Move(int moveDir, GameTime gameTime)
        {
            switch (moveDir)
            {
                case 1:
                    this.velocity.Y = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 1)
                    {
                        currentSprite = 1;
                        //rect = new Rectangle(sprites[1].Width / 2, sprites[1].Height / 2, (int)(sprites[1].Width * scale), (int)(sprites[1].Height * scale));
                        //origin = new Vector2(sprites[1].Width / 2, sprites[1].Height / 2);
                    }
                    //myWorld.WorldOffset = new Vector2(myWorld.WorldOffset.X, myWorld.WorldOffset.Y + (float)gameTime.ElapsedGameTime.TotalSeconds * speed);
                    //worldPos.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 2:
                    this.velocity.Y = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 0)
                    {
                        currentSprite = 0;
                        //rect = new Rectangle(sprites[0].Width / 2, sprites[0].Height / 2, (int)(sprites[0].Width * scale), (int)(sprites[0].Height * scale));
                        //origin = new Vector2(sprites[0].Width / 2, sprites[0].Height / 2);
                    }
                    //myWorld.WorldOffset = new Vector2(myWorld.WorldOffset.X, myWorld.WorldOffset.Y - (float)gameTime.ElapsedGameTime.TotalSeconds * speed);
                    //worldPos.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 3:
                    this.velocity.X = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 2)
                    {
                        currentSprite = 2;
                        //rect = new Rectangle(0,0, (int)(sprites[2].Width * scale), (int)(sprites[2].Height * scale));
                        //origin = new Vector2(sprites[2].Width / 2, sprites[2].Height / 2);
                    }
                    //myWorld.WorldOffset = new Vector2(myWorld.WorldOffset.X + (float)gameTime.ElapsedGameTime.TotalSeconds * speed, myWorld.WorldOffset.Y);
                    //worldPos.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 4:
                    this.velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 3)
                    {
                        currentSprite = 3;
                        //rect = new Rectangle(sprites[3].Width / 2 - (int)(sprites[3].Width * scale)/2, sprites[3].Height / 2 - (int)(sprites[3].Height * scale) / 2, (int)(sprites[3].Width * scale), (int)(sprites[3].Height * scale));
                        //origin = new Vector2(sprites[3].Width / 2, sprites[3].Height / 2);
                    }
                    //myWorld.WorldOffset = new Vector2(myWorld.WorldOffset.X - (float)gameTime.ElapsedGameTime.TotalSeconds * speed, myWorld.WorldOffset.Y);
                    //worldPos.X += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
            }

            foreach (GameObject myGameObject in myWorld.MyGameObjects)
            {
                if (myGameObject.IsSolid == true)
                {
                    if ((this.velocity.X > 0 && this.IsTouchingLeft(myGameObject)) || (this.velocity.X < 0 && this.IsTouchingRight(myGameObject)))
                    {
                        this.velocity.X = 0;
                    }

                    if ((this.velocity.Y > 0 && this.IsTouchingTop(myGameObject)) || (this.velocity.Y < 0 && this.IsTouchingBottom(myGameObject)))
                    {
                        this.velocity.Y = 0;
                    }
                }
            }
            worldPos += this.velocity;
            myWorld.WorldOffset -= this.velocity;

            this.velocity = Vector2.Zero;
        }

        #endregion
    }
}
