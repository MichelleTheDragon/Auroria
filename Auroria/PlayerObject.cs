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
            scale = 0.02f;
            this.sprites = sprites;
        }

        #endregion
        #region Methods

        public void Move(int moveDir, GameTime gameTime)
        {
            switch (moveDir)
            {
                case 1:
                    if (currentSprite != 1)
                    {
                        currentSprite = 1;
                        rect = new Rectangle(0, 0, sprites[1].Width, sprites[1].Height);
                        origin = new Vector2(sprites[1].Width / 2, sprites[1].Height / 2);
                    }
                    worldPos.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 2:
                    if (currentSprite != 0)
                    {
                        currentSprite = 0;
                        rect = new Rectangle(0, 0, sprites[0].Width, sprites[0].Height);
                        origin = new Vector2(sprites[0].Width / 2, sprites[0].Height / 2);
                    }
                    worldPos.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 3:
                    if (currentSprite != 2)
                    {
                        currentSprite = 2;
                        rect = new Rectangle(0, 0, sprites[2].Width, sprites[2].Height);
                        origin = new Vector2(sprites[2].Width / 2, sprites[2].Height / 2);
                    }
                    worldPos.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 4:
                    if (currentSprite != 3)
                    {
                        currentSprite = 3;
                        rect = new Rectangle(0, 0, sprites[3].Width, sprites[3].Height);
                        origin = new Vector2(sprites[3].Width / 2, sprites[3].Height / 2);
                    }
                    worldPos.X += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
            }

            #endregion






        }
    }
}
