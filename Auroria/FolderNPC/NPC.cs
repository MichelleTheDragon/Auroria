using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
   
    class NPC : GameObject
    { 
        private string name;
        public NPC(Texture2D sprite, int[] tilePos, Vector2 worldPos, bool isSolid) : base(sprite, tilePos, worldPos, isSolid)
        {
        }
    }

    

}
