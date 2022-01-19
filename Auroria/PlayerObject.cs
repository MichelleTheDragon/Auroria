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
        public PlayerObject(Texture2D sprites, int[] tilePos, Vector2 worldPos, GameWorld myWorld, GraphicsDeviceManager graphics) : base(sprites, tilePos, worldPos, false)
        {
            this.myWorld = myWorld;
            this.sprite = sprites;
            this.isPlayer = true;
            myWorld.WorldOffset = new Vector2(- worldPos.X + graphics.GraphicsDevice.Viewport.Width / 2, - worldPos.Y + graphics.GraphicsDevice.Viewport.Height / 2);
            this.rectPlayer = new Rectangle(0, 0, 64, 64);
        }

        #endregion
        #region Methods

        public override void Update(GameTime gameTime)
        {
            if (isActive == true)
            {
                animationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimer >= 2.0f)
                {
                    animationTimer = 0.0f;
                    tilePos[0]++;
                    if (tilePos[0] > 3)
                    {
                        tilePos[0] = 0;
                    }
                    ChangeSpriteTile();
                }
            }
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
                    if (tilePos[1] != 3)
                    {
                        tilePos[1] = 3;
                        ChangeSpriteTile();
                    }
                    break;
                case 2:
                    this.velocity.Y = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (tilePos[1] != 0)
                    {
                        tilePos[1] = 0;
                        ChangeSpriteTile();
                    }
                    break;
                case 3:
                    this.velocity.X = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (tilePos[1] != 2)
                    {
                        tilePos[1] = 2;
                        ChangeSpriteTile();
                    }
                    break;
                case 4:
                    this.velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    if (tilePos[1] != 1)
                    {
                        tilePos[1] = 1;
                        ChangeSpriteTile();
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
