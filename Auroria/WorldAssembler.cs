using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class WorldAssembler
    {

        #region Fields

        private Texture2D map;
        private int[] rock = new int[] { 5, 0 };
        private int[] tree = new int[] { 4, 0 };
        private int[] grass = new int[] { 1, 1 };
        private int[] plant = new int[] { 1, 1 };
        private int[] water = new int[] { 3, 2 };
        private int[] grassEdgeLeftTop = new int[] { 2, 2 };
        private int[] grassEdgeRightTop = new int[] { 0, 2 };
        private int[] grassBendLeftTop = new int[] { 2, 0 };
        private int[] grassBendRightTop = new int[] { 0, 0 };
        private int[] grassFlatTop = new int[] { 1, 2 };
        private int[] grassFlatLeft = new int[] { 2, 1 };
        private int[] grassFlatRight = new int[] { 0, 1 };

        private Texture2D tileSet;

        #endregion
        #region Properties
        #endregion
        #region Constructors
        #endregion
        #region Methods

        public void LoadContent(ContentManager content, GameWorld gameWorld)
        {
            tileSet = content.Load<Texture2D>("GameObjects/tilesetNotDone");

            map = content.Load<Texture2D>("TestMap");

            int mapWidth = map.Width;
            int mapHeight = map.Height;

            Color[] colors = new Color[mapWidth * mapHeight]; //creates a color array for all pixels in the map
            map.GetData(colors); //sets those colors in the array

            Color black = new Color(0, 0, 0); //creates a black color
            Color green = new Color(0, 164, 19);
            Color yellowGreen = new Color(186, 175, 1);
            Color blue = new Color(72, 0, 255);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (colors[y * mapWidth + x] == blue)
                    {
                        gameWorld.AddObject(new Rock(tileSet, water, new Vector2(x * 64, y * 64)));
                        if (y != 0 && x != 0)
                        {
                            if (colors[(y - 1) * mapWidth + x - 1] != blue && colors[(y - 1) * mapWidth + x] == blue && colors[(y) * mapWidth + x - 1] == blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassEdgeLeftTop, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[(y - 1) * mapWidth + x + 1] != blue && colors[(y - 1) * mapWidth + x] == blue && colors[(y) * mapWidth + x + 1] == blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassEdgeRightTop, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[(y - 1) * mapWidth + x] != blue && colors[y * mapWidth + x - 1] != blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassBendLeftTop, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[(y - 1) * mapWidth + x] != blue && colors[y * mapWidth + x + 1] != blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassBendRightTop, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[(y - 1) * mapWidth + x] != blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassFlatTop, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[y * mapWidth + x - 1] != blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassFlatLeft, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[y * mapWidth + x + 1] != blue)
                            {
                                gameWorld.AddObject(new Rock(tileSet, grassFlatRight, new Vector2(x * 64, y * 64)));
                            }


                        }
                    }
                    else
                    {
                        gameWorld.AddObject(new Rock(tileSet, grass, new Vector2(x * 64, y * 64)));
                    }

                    if (colors[y * mapWidth + x] == black)
                    {
                        gameWorld.AddObject(new Rock(tileSet, rock, new Vector2(x * 64, y * 64)));
                    }
                    else if (colors[y * mapWidth + x] == green)
                    {
                        gameWorld.AddObject(new Rock(tileSet, tree, new Vector2(x * 64, y * 64)));
                    }
                    else if (colors[y * mapWidth + x] == yellowGreen)
                    {
                        gameWorld.AddObject(new Rock(tileSet, plant, new Vector2(x * 64, y * 64)));
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        #endregion




    }
}
