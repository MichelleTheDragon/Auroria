using Auroria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class TextContainer : Component
    {
        #region Fields
        protected bool active = true;

        public Vector2 pos, dims;
        private Color colour;

        public Button closeBtn;

        private Rectangle rectangle;
        private Texture2D btnTexture;
        private Texture2D bkgTexture;

        public SpriteFont font;
        #endregion


        #region Constructor
        public TextContainer(Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            closeBtn = new Button(btnTexture, true);
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
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X - bkgTexture.Width / 2, (int)pos.Y - bkgTexture.Height / 2, bkgTexture.Width, bkgTexture.Height);
            }
        }
        public Color Colour { get; set; }
        #endregion

        #region Methods

        public virtual void Close()
        {
            Active = false;
        }

        public void LoadContent(ContentManager content)
        {
            btnTexture = content.Load<Texture2D>("Controls/closeButton");

            bkgTexture = content.Load<Texture2D>("Controls/textZone");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(bkgTexture, rectangle, colour);
                spriteBatch.Draw(btnTexture, Rectangle, Colour);
            }
        }

        public override void Update(GameTime gametime)
        {
            if (closeBtn.Clicked)
            {
                Close();
            }
        }
        #endregion
    }
}
