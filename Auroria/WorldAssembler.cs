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
        private Texture2D rock;
        private Texture2D tree;
        private Texture2D plant;
        private Texture2D flora;

        public void LoadContent(ContentManager content, GameWorld gameWorld)
        {
            rock = content.Load<Texture2D>("Player");
            tree = content.Load<Texture2D>("Player");
            plant = content.Load<Texture2D>("Player");
            flora = content.Load<Texture2D>("Player");

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
                    if (colors[y * mapWidth + x] == black) //if the checked pixel is black
                    {
                        gameWorld.AddObject(new Rock(rock, new Vector2(x * 50, y * 50)));
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
