using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class PlayerObject : GameObject
    {
        private float speed = 10.0f;
        public float Speed { get { return speed; } }
        private Vector2 movement = Vector2.Zero;
        public Vector2 Movement { get { return movement; } set { movement = value; } }

        public PlayerObject(Texture2D sprite, Vector2 worldPos) : base(sprite, worldPos)
        {

        }
    }
}
