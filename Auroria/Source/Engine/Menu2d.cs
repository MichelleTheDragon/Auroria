using Auroria.Source;
using Auroria.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class Menu2d
    {
        #region Fields
        protected bool active;

        public Vector2 pos, dims, topLeft;

        public Animated2d bkg;

        public Button2d closeBtn;

        public Texture2D myModel;

        public SpriteFont font;
        #endregion


        #region Constructor
        public Menu2d(Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            bkg = new Animated2d("Controls\\textZone", new Vector2(0, 0), new Vector2(dims.X, dims.Y), new Vector2(1, 1), Color.White);

            closeBtn = new Button2d("Controls\\closeButton", new Vector2(bkg.dims.X/2, -bkg.dims.Y/2), new Vector2(30, 30), "", "", Close, null);

            font = Globals.content.Load<SpriteFont>("Fonts\\Font");
        }
        #endregion

        #region Properties
        public virtual bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        #endregion

        #region Methods
        public virtual void Update()
        {
            if (Active)
            {
                topLeft = pos - dims / 2;

                closeBtn.Update(pos);
            }
        }

        public virtual void Close(object INFO)
        {
            Active = false;
        }

        public virtual void Draw()
        {
            if (Active)
            {
                bkg.Draw(pos);

                closeBtn.Draw(pos);
            }
        }
        #endregion
    }
}
