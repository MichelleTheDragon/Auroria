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
        private bool toolbarKeyDown;


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

        /// <summary>
        ///     Runs all movement of the player character
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="keyState"></param>
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
            if (keyState.IsKeyDown(Keys.D1) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 1;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D2) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 2;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D3) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 3;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D4) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 4;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D5) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 5;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D6) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 6;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D7) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 7;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            }
            else if (keyState.IsKeyDown(Keys.D8) && toolbarKeyDown != true)
            {
                myUI.CurrentToolbarPicked = 8;
                myUI.SelectedToolbar2();
                toolbarKeyDown = true;
            } else if (toolbarKeyDown == true)
            {
                toolbarKeyDown = false;
            }
        }
        /// <summary>
        ///     All other hotkey inputs
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="keyState"></param>
        private void OtherHotkeys(GameTime gameTime, KeyboardState keyState)
        {
            //Plant a seed
            if (keyState.IsKeyDown(Keys.Space) && spaceDown != true)
            {
                int newX = (int)(myWorld.Player.WorldPos.X + 32) / 64;
                int newY = (int)(myWorld.Player.WorldPos.Y + 50) / 64;
                if (myWorld.OccupiedTiles[newX, newY] != true)
                {
                    switch (myUI.CurrentToolbarPicked)
                    {
                        case 1:
                            myWorld.AddObject(new Plant(newPlant, new int[] { 0, 0 }, new Vector2(newX * 64, newY * 64), myWorld, newPlot)); //spawn under player position
                            break;
                        case 2:
                            myWorld.AddObject(new Plant(newPlant, new int[] { 0, 1 }, new Vector2(newX * 64, newY * 64), myWorld, newPlot)); //spawn under player position
                            break;
                        case 3:
                            myWorld.AddObject(new Plant(newPlant, new int[] { 0, 2 }, new Vector2(newX * 64, newY * 64), myWorld, newPlot)); //spawn under player position
                            break;
                        case 4:
                            myWorld.AddObject(new Plant(newPlant, new int[] { 0, 3 }, new Vector2(newX * 64, newY * 64), myWorld, newPlot)); //spawn under player position
                            break;
                        case 5:
                            myWorld.AddObject(new Plant(newPlant, new int[] { 0, 4 }, new Vector2(newX * 64, newY * 64), myWorld, newPlot)); //spawn under player position
                            break;
                        case 6:
                            myWorld.AddObject(new Plant(newPlant, new int[] { 0, 5 }, new Vector2(newX * 64, newY * 64), myWorld, newPlot)); //spawn under player position
                            break;
                    }
                    if (myUI.CurrentToolbarPicked <= 6)
                    {
                        myWorld.OccupiedTiles[newX, newY] = true;
                    }
                    //player.PlantSeed(myUI.currentType[1]);
                }
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
