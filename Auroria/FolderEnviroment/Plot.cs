using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class Plot : GameObject
    {

        public Plot(Texture2D sprite, int[] tilePos, Vector2 worldPos) : base(sprite, tilePos, worldPos, false)
        {
            layer = 0.5f; //makes sure the plot is drawn under the plant
        }
    }
}
