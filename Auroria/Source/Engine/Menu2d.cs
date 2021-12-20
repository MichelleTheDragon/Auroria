using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria.Source.Engine
{
    public class Menu2d
    {
        protected bool active;

        public Vector2 pos, dims, topLeft;

        public Animated2d bkg;

        public Button2d closeBtn;

        public SpriteFont font;

        public PassObject CloseAction;

        public Menu2d(Vector2 POS, Vector2 DIMS, PassObject CLOSEACTION)
        {
            pos = POS;
            dims = DIMS;
            CloseAction = CLOSEACTION;

            bkg = new Animated2d("", new Vector2(), new Vector2(dims.X, dims.Y), new Vector2(1, 1), Color.White)
                ;
        }
    }
}
