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

        /// <summary>
        ///     Constructor for plant
        /// </summary>
        /// <param name="sprite">Tilesheet of plants</param>
        /// <param name="tilePos">A tile position of the planted seed</param>
        /// <param name="worldPos">The position it is planted</param>
        /// <param name="myWorld">"this"</param>
        /// <param name="myPlot">The plot sprite</param>
        public Plant(Texture2D sprite, int[] tilePos, Vector2 worldPos, GameWorld myWorld, Texture2D myPlot) : base(sprite, tilePos, worldPos, false)
        {
            myWorld.AddObject(new Plot(myPlot, new int[] {7, 0}, worldPos)); //create a plot object under the plant
            if (tilePos[1] >= 2) //skips past tiles on the Y axis that isn't the bottom one
            {
                tilePos[1] = (tilePos[1] - 1) * 2 + 1;
                tileHeight = 2;
                ChangeSpriteTile();
            }
        }

        public override void Update(GameTime gameTime)
        {
            agingTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (agingTimer >= 15.0f && plantAge < 3) //after 15sec the plant grows, as long as it isn't at the last stage.
            {
                plantAge++;
                tilePos = new int[] {plantAge, tilePos[1]};
                ChangeSpriteTile();
                agingTimer = 0.0f;
            }
        }
    }
}
