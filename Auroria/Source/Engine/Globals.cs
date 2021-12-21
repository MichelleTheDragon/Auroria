using System;
using System.Collections.Generic;
using System.Text;
using Auroria.Source.Engine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Auroria.Source.Engine
{
    public delegate void PassObject(object i);
    public delegate object PassObjectAndReturn(object i);

    public class Globals
    {
        public static int screenHeight, screenWidth, gameState = 0;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static Effect normalEffect;


        public static McKeyboard keyboard;
        public static McMouseControl mouse;
    }
}
