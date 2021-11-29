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
        protected Texture2D sprite;

        protected float scale = 1.0f;
        protected float layer = 1.0f;
        protected Vector2 worldPos;
        protected Rectangle rect;
        protected Vector2 origin;
        protected SpriteEffects effects;

        protected bool isSolid;
        public bool IsSolid {get { return isSolid; } }



        public GameObject(Texture2D sprite, Vector2 worldPos, bool isSolid)
        {
            this.sprite = sprite;
            this.worldPos = worldPos;
            rect = new Rectangle(0, 0, sprite.Width, sprite.Height);
            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

            this.isSolid = isSolid;
        }

        public void LoadContent(ContentManager content)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, worldPos, rect, Color.White, 0.0f, origin, scale, effects, layer);
        }
    }
}
