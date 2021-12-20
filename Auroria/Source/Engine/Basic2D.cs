using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Auroria.Source.Engine
{
    public class Basic2D
    {
        public Vector2 pos, dims;

        public Texture2D myTexture;

        public Basic2D(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            myTexture = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (myTexture != null)
            {
                Globals.spriteBatch.Draw(myTexture, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y), null, Color.White, 0.0f, new Vector2(myTexture.Bounds.Width / 2, myTexture.Bounds.Height / 2), new SpriteEffects(), 0);
            }
            
        }
    }
}
