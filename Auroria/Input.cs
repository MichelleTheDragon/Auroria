using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class Input
    {

        public void Update(GameTime gameTime, PlayerObject player)
        {

            Movement(gameTime, player);
        }

        private void Movement(GameTime gameTime, PlayerObject player)
        {
            KeyboardState keyState = Keyboard.GetState(); //get state of keyboard

            //move selection on grid, W = up, S = down, A = left, D = right
            if (!(keyState.IsKeyDown(Keys.W) && keyState.IsKeyDown(Keys.S)))
            {
                if (keyState.IsKeyDown(Keys.W))
                {

                }
                if (keyState.IsKeyDown(Keys.S))
                {

                }
            }
            else if (keyState.IsKeyDown(Keys.A))
            {

            }
            else if (keyState.IsKeyDown(Keys.D))
            {

            }
        }
    }
}
