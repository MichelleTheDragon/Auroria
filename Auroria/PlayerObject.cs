using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class PlayerObject : GameObject
    {
        private float speed = 300.0f;
        public float Speed { get { return speed; } }
        private Vector2 movement = Vector2.Zero;
        public Vector2 Movement { get { return movement; } set { movement = value; } }

        private GameWorld myWorld;

        public PlayerObject(Texture2D sprite, Vector2 worldPos, GameWorld myWorld) : base(sprite, null, worldPos, false)
        {
            this.myWorld = myWorld;
        }

        public void Move(int moveDir, GameTime gameTime)
        {
            switch (moveDir)
            {
                case 1:
                    worldPos.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 2:
                    worldPos.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 3:
                    worldPos.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
                case 4:
                    worldPos.X += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                    break;
            }
        }
    }
}
