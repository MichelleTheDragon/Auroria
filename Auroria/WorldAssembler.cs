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
        private int[] plant = new int[] { 3, 0 };
        private int[] water = new int[] { 3, 2 };
        private int[] grassEdgeTopLeft = new int[] { 2, 2 };
        private int[] grassEdgeTopRight = new int[] { 0, 2 };
        private int[] grassEdgeBottomLeft = new int[] { 10, 5 };
        private int[] grassEdgeBottomRight = new int[] { 8, 5 };
        private int[] grassBendTopLeft = new int[] { 2, 0 };
        private int[] grassBendTopRight = new int[] { 0, 0 };
        private int[] grassBendBottomLeft = new int[] { 10, 7 };
        private int[] grassBendBottomRight = new int[] { 8, 7 };
        private int[] grassFlatTop = new int[] { 1, 2 };
        private int[] grassFlatBottom = new int[] { 9, 5 };
        private int[] grassFlatLeft = new int[] { 2, 1 };
        private int[] grassFlatLeft2 = new int[] { 10, 6 };
        private int[] grassFlatLeft3 = new int[] { 10, 4 };
        private int[] grassFlatRight = new int[] { 0, 1 };
        private int[] grassFlatRight2 = new int[] { 8, 6 };
        private int[] grassFlatRight3 = new int[] { 8, 4 };

        private Texture2D tileSet;

        #endregion
        #region Properties
        #endregion
        #region Constructors
        #endregion
        #region Methods

        public void LoadContent(ContentManager content, GameWorld gameWorld, GraphicsDeviceManager graphics)
        {
            tileSet = content.Load<Texture2D>("GameObjects/tilesetNotDone");

            map = content.Load<Texture2D>("TestMap");

            int mapWidth = map.Width;
            int mapHeight = map.Height;
            gameWorld.OccupiedTiles = new bool[mapWidth, mapHeight];

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
                    if (colors[y * mapWidth + x] == blue) //If the pixel is blue, place Water tile
                    {
                        int solidGround = 0;
                        if (colors[(y - 1) * mapWidth + x] != blue)
                        {
                            solidGround++;
                        }
                        if (colors[(y + 1) * mapWidth + x] != blue)
                        {
                            solidGround++;
                        }
                        if (colors[y * mapWidth + x - 1] != blue)
                        {
                            solidGround++;
                        }
                        if (colors[y * mapWidth + x + 1] != blue)
                        {
                            solidGround++;
                        }
                        if (solidGround >= 3)
                        {
                            gameWorld.AddObject(new Grass(tileSet, grass, new Vector2(x * 64, y * 64)));
                        } else
                        {
                            gameWorld.AddObject(new Water(tileSet, water, new Vector2(x * 64, y * 64)));
                        }
                        if (y != 0 && x != 0)
                        {
                            if (colors[(y + 1) * mapWidth + x] == blue && colors[y * mapWidth + x + 1] == blue)
                            {
                                if (colors[(y - 1) * mapWidth + x - 1] != blue && colors[(y - 1) * mapWidth + x] == blue && colors[(y) * mapWidth + x - 1] == blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassEdgeTopLeft, new Vector2(x * 64, y * 64)));
                                }
                                else if (colors[(y - 1) * mapWidth + x] != blue && colors[y * mapWidth + x - 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassBendTopLeft, new Vector2(x * 64, y * 64)));
                                }
                            }
                            if (colors[(y + 1) * mapWidth + x] == blue && colors[y * mapWidth + x - 1] == blue)
                            {
                                if (colors[(y - 1) * mapWidth + x + 1] != blue && colors[(y - 1) * mapWidth + x] == blue && colors[(y) * mapWidth + x + 1] == blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassEdgeTopRight, new Vector2(x * 64, y * 64)));
                                }
                                else if (colors[(y - 1) * mapWidth + x] != blue && colors[y * mapWidth + x + 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassBendTopRight, new Vector2(x * 64, y * 64)));
                                }
                            }
                            if (colors[(y - 1) * mapWidth + x] == blue && colors[y * mapWidth + x + 1] == blue)
                            {
                                if (colors[(y + 1) * mapWidth + x - 1] != blue && colors[(y + 1) * mapWidth + x] == blue && colors[(y) * mapWidth + x - 1] == blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassEdgeBottomLeft, new Vector2(x * 64, y * 64)));
                                }
                                else if (colors[(y + 1) * mapWidth + x] != blue && colors[y * mapWidth + x - 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassBendBottomLeft, new Vector2(x * 64, y * 64)));
                                }
                            }
                            if (colors[(y - 1) * mapWidth + x] == blue && colors[y * mapWidth + x - 1] == blue)
                            {
                                if (colors[(y + 1) * mapWidth + x + 1] != blue && colors[(y + 1) * mapWidth + x] == blue && colors[(y) * mapWidth + x + 1] == blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassEdgeBottomRight, new Vector2(x * 64, y * 64)));
                                }
                                else if (colors[(y + 1) * mapWidth + x] != blue && colors[y * mapWidth + x + 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassBendBottomRight, new Vector2(x * 64, y * 64)));
                                }
                            }
                            if (colors[(y - 1) * mapWidth + x] != blue && colors[(y + 1) * mapWidth + x] == blue && colors[y * mapWidth + x - 1] == blue && colors[y * mapWidth + x + 1] == blue)
                            {
                                gameWorld.AddObject(new Grass(tileSet, grassFlatTop, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[(y - 1) * mapWidth + x] == blue && colors[(y + 1) * mapWidth + x] != blue && colors[y * mapWidth + x - 1] == blue && colors[y * mapWidth + x + 1] == blue)
                            {
                                gameWorld.AddObject(new Grass(tileSet, grassFlatBottom, new Vector2(x * 64, y * 64)));
                            }
                            else if (colors[(y - 1) * mapWidth + x] == blue && colors[(y + 1) * mapWidth + x] == blue && colors[y * mapWidth + x - 1] != blue && colors[y * mapWidth + x + 1] == blue)
                            {
                                if(colors[(y + 2) * mapWidth + x] != blue || colors[(y + 2) * mapWidth + x + 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassFlatLeft2, new Vector2(x * 64, y * 64)));
                                } else if (colors[(y + 3) * mapWidth + x] != blue || colors[(y + 3) * mapWidth + x + 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassFlatLeft3, new Vector2(x * 64, y * 64)));
                                }
                                else
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassFlatLeft, new Vector2(x * 64, y * 64)));
                                }
                            }
                            else if (colors[(y - 1) * mapWidth + x] == blue && colors[(y + 1) * mapWidth + x] == blue && colors[y * mapWidth + x - 1] == blue && colors[y * mapWidth + x + 1] != blue)
                            {
                                if (colors[(y + 2) * mapWidth + x] != blue || colors[(y + 2) * mapWidth + x - 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassFlatRight2, new Vector2(x * 64, y * 64)));
                                } else if (colors[(y + 3) * mapWidth + x] != blue || colors[(y + 3) * mapWidth + x - 1] != blue)
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassFlatRight3, new Vector2(x * 64, y * 64)));
                                }
                                else
                                {
                                    gameWorld.AddObject(new Grass(tileSet, grassFlatRight, new Vector2(x * 64, y * 64)));
                                }
                            }
                        }
                        gameWorld.OccupiedTiles[x, y] = true;
                    }
                    else //if it is not a water tile, then it is a grass tile
                    {
                        gameWorld.AddObject(new Grass(tileSet, grass, new Vector2(x * 64, y * 64)));
                    }

                    if (colors[y * mapWidth + x] == black) //if the pixel is black, place a rock object
                    {
                        gameWorld.AddObject(new Rock(tileSet, rock, new Vector2(x * 64, y * 64)));
                        gameWorld.OccupiedTiles[x, y] = true;
                    }
                    else if (colors[y * mapWidth + x] == green) //if the pixel is green, place a tree object
                    {
                        gameWorld.AddObject(new Tree(tileSet, tree, new Vector2(x * 64, y * 64)));
                        gameWorld.OccupiedTiles[x, y] = true;
                    }
                    else if (colors[y * mapWidth + x] == yellowGreen) //if the pixel is yellowGreen, place a flower (currently different grass tile)
                    {
                        gameWorld.AddObject(new Flora(tileSet, plant, new Vector2(x * 64, y * 64)));
                    }
                }
            }
            Texture2D sprites = content.Load<Texture2D>("GameObjects/GOLEM_spritesheet");
            //Texture2D[] sprites = new Texture2D[4]; //player character sprite array
            //sprites[0] = content.Load<Texture2D>("GameObjects/GOLEM_front_64"); 
            //sprites[1] = content.Load<Texture2D>("GameObjects/GOLEM_back_64");
            //sprites[2] = content.Load<Texture2D>("GameObjects/GOLEM_left_64");
            //sprites[3] = content.Load<Texture2D>("GameObjects/GOLEM_right_64");
            //Create the player character
            //gameWorld.Player = new PlayerObject(sprites, new int[] { 0, 0 }, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2), gameWorld);
            gameWorld.Player = new PlayerObject(sprites, new int[] { 0, 0 }, new Vector2(21 * 64, 23 * 64), gameWorld, graphics);

            //gameWorld.AddObject(new Grass(tileSet, grass, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 64 * 2, graphics.GraphicsDevice.Viewport.Height / 2)));
            //gameWorld.AddObject(new Rock(tileSet, rock, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 64 * 2, graphics.GraphicsDevice.Viewport.Height / 2)));
            //gameWorld.AddObject(new Water(tileSet, water, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2 + 64 * 2)));


        }

        public void Update(GameTime gameTime)
        {

        }

        #endregion




    }
}
