using Auroria.Output;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class NPC : GameObject
    {
        #region Fields

        public string name;
        
        #endregion

        #region Constructor
        public NPC(Texture2D sprite, int[] tilePos, Vector2 worldPos, bool isSolid) : base(sprite, tilePos, worldPos, isSolid)
        {
            
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
        }
        #endregion


    }

    

}
