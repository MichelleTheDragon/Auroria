using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Auroria
{
    class Water : GameObject
    {
        public Water(Texture2D sprite, int[] tilePos, Vector2 worldPos) : base(sprite, tilePos, worldPos, true)
        {
        }
    }
}
