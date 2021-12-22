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
        /// <summary>
        ///     When creating a player object input an array of sprites, a spawn position, and send the GameWorld instance ("this")
        /// </summary>
        /// <param name="sprites"></param>
        /// <param name="worldPos"></param>
        /// <param name="myWorld"></param>
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


        /// <summary>
        ///     Call to move the player character
        /// </summary>
        /// <param name="moveDir"></param>
        /// <param name="gameTime"></param>
        public void Move(int moveDir, GameTime gameTime)
        {
            switch (moveDir) //Move: 1 = Up, 2 = Down, 3 = Left, 4 = right 
            {
                case 1: 
                    this.velocity.Y = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 1)
                    {
                        currentSprite = 1;
                    }
                    break;
                case 2:
                    this.velocity.Y = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 0)
                    {
                        currentSprite = 0;
                    }
                    break;
                case 3:
                    this.velocity.X = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 2)
                    {
                        currentSprite = 2;
                    }
                    break;
                case 4:
                    this.velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (currentSprite != 3)
                    {
                        currentSprite = 3;
                    }
                    break;
            }

            foreach (GameObject myGameObject in myWorld.MyGameObjects) //check if colliding with any solid objects
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
            worldPos += this.velocity; //move the player character
            myWorld.WorldOffset -= this.velocity; //move the entire world opposite of the movement, centering the player

            this.velocity = Vector2.Zero; //reset the variable 
        }

        #endregion
    }
}
