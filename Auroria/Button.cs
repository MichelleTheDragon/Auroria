using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Auroria
{
    class Button : Component
    {
        #region Fields

        private MouseState currentMouseState;

        private SpriteFont font;

        private bool isMouseHovering;

        private MouseState previousMouseState;

        private Texture2D texture;

        #endregion
        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }
        public string Text { get; set; }


        #endregion
        #region Constructors

        public Button(Texture2D texture,SpriteFont font)
        {
            this.texture = texture;
            
            this.font = font;

            PenColour = Color.Black;
        }

        #endregion
        #region Methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (isMouseHovering)
                colour = Color.LightGray;

            spriteBatch.Draw(texture, Rectangle, colour);

            if(!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gametime)
        {
            previousMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
             
            var mouseRectangle = new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);

            isMouseHovering = false;

            if(mouseRectangle.Intersects(Rectangle))
            {
                isMouseHovering = true;

                if(currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs()); 
                }
            }
        }
        #endregion
    }
}
