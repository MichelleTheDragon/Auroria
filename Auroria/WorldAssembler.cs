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
        private Texture2D map;
        private int[] rock = new int[] { 5, 0 };
        private int[] tree = new int[] { 4, 0 };
        private int[] grass = new int[] { 1, 1 };
        private int[] plant = new int[] { 1, 1 };
        private int[] flora = new int[] { 7, 0 };

        private Texture2D tileSet;

        public void LoadContent(ContentManager content, GameWorld gameWorld)
        {
            tileSet = content.Load<Texture2D>("GameObjects/tilesetNotDone");

            map = content.Load<Texture2D>("TestMap");

            int mapWidth = map.Width;
            int mapHeight = map.Height;

            Color[] colors = new Color[mapWidth * mapHeight]; //creates a color array for all pixels in the map
            map.GetData(colors); //sets those colors in the array

            Color black = new Color(0, 0, 0); //creates a black color
            Color green = new Color(0, 164, 19); //creates a black color
            Color yellowGreen = new Color(186, 175, 1); //creates a black color
            Color blue = new Color(72, 0, 255); //creates a black color

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    gameWorld.AddObject(new Rock(tileSet, grass, new Vector2(x * 64, y * 64)));
                    if (colors[y * mapWidth + x] == black) //if the checked pixel is black
                    {
                        gameWorld.AddObject(new Rock(tileSet, rock, new Vector2(x * 64, y * 64)));
                    }
                    else if (colors[y * mapWidth + x] == green) //if the checked pixel is black
                    {
                        gameWorld.AddObject(new Rock(tileSet, tree, new Vector2(x * 64, y * 64)));
                    }
                    else if (colors[y * mapWidth + x] == yellowGreen) //if the checked pixel is black
                    {
                        gameWorld.AddObject(new Rock(tileSet, plant, new Vector2(x * 64, y * 64)));
                    }
                    else if (colors[y * mapWidth + x] == blue) //if the checked pixel is black
                    {
                        gameWorld.AddObject(new Rock(tileSet, flora, new Vector2(x * 64, y * 64)));
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
