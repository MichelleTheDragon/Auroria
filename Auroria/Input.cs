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
            if (!((keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up)) && (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))))
            {
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
                {
                    player.Move(1, gameTime);
                }
                else if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
                {
                    player.Move(2, gameTime);
                }
            }
            if (!((keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left)) && (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))))
            {
                if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
                {
                    player.Move(3, gameTime);
                }
                else if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
                {
                    player.Move(4, gameTime);
                }
            }
        }
    }
}
