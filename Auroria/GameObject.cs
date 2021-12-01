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
        protected Rectangle rect;
        protected Vector2 origin;
        protected SpriteEffects effects;

        protected bool isSolid;
        public bool IsSolid { get { return isSolid; } }

        protected int[] tilePos;

        #endregion
        #region Properties
        #endregion
        #region Constructors

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

        public void LoadContent(ContentManager content)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprites == null) {
                spriteBatch.Draw(sprite, worldPos, rect, Color.White, 0.0f, origin, scale, effects, layer);
            } else
            {
                spriteBatch.Draw(sprites[currentSprite], worldPos, rect, Color.White, 0.0f, origin, scale, effects, layer);
            }
        }

        #endregion








    }
}
