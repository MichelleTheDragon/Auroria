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
        protected Rectangle rect;
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
            if (tilePos != null)
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

        protected bool IsTouchingLeft(GameObject gameObject)
        {
            return this.rect.Right + this.velocity.X > gameObject.rect.Left &&
                   this.rect.Left < gameObject.rect.Left &&
                   this.rect.Bottom > gameObject.rect.Top &&
                   this.rect.Top < gameObject.rect.Bottom;
        }
        protected bool IsTouchingRight(GameObject gameObject)
        {
            return this.rect.Left + this.velocity.X < gameObject.rect.Right &&
                   this.rect.Right > gameObject.rect.Right &&
                   this.rect.Bottom > gameObject.rect.Top &&
                   this.rect.Top < gameObject.rect.Bottom;
        }
        protected bool IsTouchingTop(GameObject gameObject)
        {
            return this.rect.Bottom + this.velocity.Y > this.rect.Top &&
                   this.rect.Top < gameObject.rect.Top &&
                   this.rect.Right > gameObject.rect.Left &&
                   this.rect.Left < gameObject.rect.Right;  
        }
        protected bool IsTouchingBottom(GameObject gameObject)
        {
            return this.rect.Top + this.velocity.Y < this.rect.Bottom &&
                   this.rect.Bottom < gameObject.rect.Bottom &&
                   this.rect.Right > gameObject.rect.Left &&
                   this.rect.Left < gameObject.rect.Right;
        }

        #endregion

        public void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime, GameWorld gameWorld)
        {

        }

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
