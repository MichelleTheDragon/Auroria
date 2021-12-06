using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class Plant : GameObject
    {
        public Plant(Texture2D sprite, int[] tilePos, Vector2 worldPos) : base(sprite, tilePos, worldPos, false)
        {
        }
    }
}
