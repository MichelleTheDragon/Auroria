using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class Input
    {

        #region Fields
        private PlayerObject player;
        private UI myUI;
        private GameWorld myWorld;
        private bool spaceDown;
        private Texture2D newPlant;
        private Texture2D newPlot;


        #endregion
        #region Properties
        #endregion
        #region Constructors
        public Input(PlayerObject player, UI myUI, GameWorld myWorld)
        {
            this.player = player;
            this.myUI = myUI;
            this.myWorld = myWorld;
            newPlant = myWorld.Content.Load<Texture2D>("GameObjects/tilesetCrops1");
            newPlot = myWorld.Content.Load<Texture2D>("GameObjects/tilesetNotDone");
        }
        #endregion
        #region Methods

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState(); //get state of keyboard
            Movement(gameTime, keyState);
            Hotbar(gameTime, keyState);
            OtherHotkeys(gameTime, keyState);
        }

        private void Movement(GameTime gameTime, KeyboardState keyState)
        {

            //move character around, W = up, S = down, A = left, D = right
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

        private void Hotbar(GameTime gameTime, KeyboardState keyState)
        {

        }

        private void OtherHotkeys(GameTime gameTime, KeyboardState keyState)
        {
            //Plant a seed
            if (keyState.IsKeyDown(Keys.Space) && spaceDown != true)
            {
                int newX = (int)(myWorld.Player.WorldPos.X + 32) / 64;
                int newY = (int)(myWorld.Player.WorldPos.Y + 50) / 64;
                myWorld.AddObject(new Plant(newPlant, new int[]{0,4}, new Vector2(newX * 64,newY * 64), myWorld, newPlot));
                //if (myUI.CurrentType == "Seed")
                //{
                //    //player.PlantSeed(myUI.currentType[1]);
                //}
                spaceDown = true;
            }
            else if (keyState.IsKeyUp(Keys.Space) && spaceDown == true)
            {
                spaceDown = false;
            }
        }
        #endregion



    }
}
