using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class Img : Component
    {
        private Texture2D texture;
        private int[] tilePos;
        private Rectangle rectangle;
        private Vector2 position;
        private Vector2 origin = new Vector2(32, 32);
        private SpriteEffects effects;

        public Img(Texture2D texture, int[] tilePos, Vector2 position)
        {
            this.texture = texture;
            this.tilePos = tilePos;
            this.position = position;
            rectangle = new Rectangle(tilePos[0] * 64, tilePos[1] * 64, 64, 64);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, Color.White, 0.0f, origin, 1.0f, effects, 1.0f);
        }

        public override void Update(GameTime gametime)
        {

        }
    }
}
