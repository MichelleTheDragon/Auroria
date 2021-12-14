﻿using Microsoft.Xna.Framework;
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

        public Plant(Texture2D sprite, int[] tilePos, Vector2 worldPos, GameWorld myWorld, Texture2D myPlot) : base(sprite, tilePos, worldPos, false)
        {
            myWorld.AddObject(new Plot(myPlot, new int[] {7, 0}, worldPos));
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
