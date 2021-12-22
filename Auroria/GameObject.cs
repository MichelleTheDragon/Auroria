using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public abstract class GameObject
    {

        #region Fields

        protected Texture2D sprite;
        protected Texture2D[] sprites;
        protected int currentSprite = 0;

        protected float scale = 1.0f;
        protected float layer = 1.0f;
        protected Vector2 worldPos;
        public Vector2 WorldPos { get { return worldPos; } set { worldPos = value; } }
        public Rectangle rect;
        protected Vector2 origin;
        public Vector2 velocity;
        protected SpriteEffects effects;

        protected bool isSolid;
        public bool IsSolid { get { return isSolid; } }

        protected int[] tilePos;

        #endregion
        #region Properties
        #endregion
        #region Constructors

        /// <summary>
        ///     Sprite - Tile Position - World Position - is Solid
        /// </summary>
        /// <param name="sprite">Single Sprite</param>
        /// <param name="tilePos">Location of sprite if on tilesheet</param>
        /// <param name="worldPos">The objects location in the world</param>
        /// <param name="isSolid">Is the object solid (can't walk through)</param>
        public GameObject(Texture2D sprite, int[] tilePos, Vector2 worldPos, bool isSolid)
        {
            this.sprite = sprite;
            this.worldPos = worldPos;
            this.tilePos = tilePos;
            if (tilePos != null) //if the sprite is a tilesheet
            {
                rect = new Rectangle(tilePos[0] * 64, tilePos[1] * 64, 64, 64);
                origin = new Vector2(32, 32);
            }
            else 
            {
                rect = new Rectangle(0, 0, sprite.Width, sprite.Height);
                origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            }

            this.isSolid = isSolid;
        }

        #endregion
        #region Methods

        #region Collision

        /// <summary>
        ///     Returns true if GameObject is blocking on the right
        /// </summary>
        /// <param name="myGameObject"></param>
        /// <returns></returns>
        protected bool IsTouchingLeft(GameObject myGameObject)
        {
            return  this.worldPos.X + this.rect.Right - 10 + this.velocity.X > myGameObject.worldPos.X + myGameObject.rect.Left - myGameObject.tilePos[0] * 64 &&
                    this.worldPos.X + this.rect.Left + 10 < myGameObject.worldPos.X + myGameObject.rect.Left - myGameObject.tilePos[0] * 64 &&
                    this.worldPos.Y + this.rect.Bottom - 10 > myGameObject.worldPos.Y + myGameObject.rect.Top - myGameObject.tilePos[1] * 64 &&
                    this.worldPos.Y + this.rect.Top + 30 < myGameObject.worldPos.Y + myGameObject.rect.Bottom - myGameObject.tilePos[1] * 64;
        }
        /// <summary>
        ///     Returns true if GameObject is blocking on the left
        /// </summary>
        /// <param name="myGameObject"></param>
        /// <returns></returns>
        protected bool IsTouchingRight(GameObject myGameObject)
        {
            return this.worldPos.X + this.rect.Left + 10 + this.velocity.X < myGameObject.worldPos.X + myGameObject.rect.Right - myGameObject.tilePos[0] * 64 &&
                   this.worldPos.X + this.rect.Right - 10 > myGameObject.worldPos.X + myGameObject.rect.Right - myGameObject.tilePos[0] * 64 &&
                   this.worldPos.Y + this.rect.Bottom - 10 > myGameObject.worldPos.Y + myGameObject.rect.Top - myGameObject.tilePos[1] * 64 &&
                   this.worldPos.Y + this.rect.Top + 30 < myGameObject.worldPos.Y + myGameObject.rect.Bottom - myGameObject.tilePos[1] * 64;
        }
        /// <summary>
        ///     Returns true if GameObject is blocking bellow
        /// </summary>
        /// <param name="myGameObject"></param>
        /// <returns></returns>
        protected bool IsTouchingTop(GameObject myGameObject)
        {
            return this.worldPos.Y + this.rect.Bottom - 10 + this.velocity.Y > myGameObject.worldPos.Y + myGameObject.rect.Top - myGameObject.tilePos[1] * 64 &&
                   this.worldPos.Y + this.rect.Top + 30 < myGameObject.worldPos.Y + myGameObject.rect.Top - myGameObject.tilePos[1] * 64 &&
                   this.worldPos.X + this.rect.Right - 10 > myGameObject.worldPos.X + myGameObject.rect.Left - myGameObject.tilePos[0] * 64 &&
                   this.worldPos.X + this.rect.Left + 10 < myGameObject.worldPos.X + myGameObject.rect.Right - myGameObject.tilePos[0] * 64;
        }
        /// <summary>
        ///     Returns true if GameObject is blocking above
        /// </summary>
        /// <param name="myGameObject"></param>
        /// <returns></returns>
        protected bool IsTouchingBottom(GameObject myGameObject)
        {
            return this.worldPos.Y + this.rect.Top + 30 + this.velocity.Y < myGameObject.worldPos.Y + myGameObject.rect.Bottom - myGameObject.tilePos[1] * 64 &&
                   this.worldPos.Y + this.rect.Bottom - 10 > myGameObject.worldPos.Y + myGameObject.rect.Bottom - myGameObject.tilePos[1] * 64 &&
                   this.worldPos.X + this.rect.Right - 10 > myGameObject.worldPos.X + myGameObject.rect.Left - myGameObject.tilePos[0] * 64 &&
                   this.worldPos.X + this.rect.Left + 10 < myGameObject.worldPos.X + myGameObject.rect.Right - myGameObject.tilePos[0] * 64;
        }

        #endregion

        public void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        ///     Call to update the rectangle, if it changes tile at runtime
        /// </summary>
        /// <param name="height"></param>
        protected void ChangeSpriteTile(int height)
        {
            rect = new Rectangle(tilePos[0] * 64, tilePos[1] * height * 64, 64, 64);
        }

        /// <summary>
        ///     Draw the GameObject
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="worldOffset"></param>
        public void Draw(SpriteBatch spriteBatch, Vector2 worldOffset)
        {
            if (sprites == null) {
                spriteBatch.Draw(sprite, worldPos + worldOffset, rect, Color.White, 0.0f, origin, scale, effects, layer);
            } else
            {
                spriteBatch.Draw(sprites[currentSprite], worldPos + worldOffset, rect, Color.White, 0.0f, origin, scale, effects, layer);
            }
        }

        #endregion








    }
}
