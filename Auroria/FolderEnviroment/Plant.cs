using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class Plant : GameObject
    {
        private int plantAge = 0;
        private float agingTimer;

        public Plant(Texture2D sprite, int[] tilePos, Vector2 worldPos) : base(sprite, tilePos, worldPos, false)
        {

        }

        public override void Update(GameTime gameTime)
        {
            agingTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (agingTimer >= 5.0f && plantAge < 3)
            {
                plantAge++;
                tilePos = new int[] {plantAge, tilePos[1]};
                ChangeSpriteTile();
                agingTimer = 0.0f;
            }
        }
    }
}
