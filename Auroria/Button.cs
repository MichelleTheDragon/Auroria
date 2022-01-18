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

        private bool isMenuButton;

        private MouseState previousMouseState;

        private Texture2D texture;

        private GameWorld myWorld;

        #endregion
        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        private UI myUI;
        public UI MyUI { set { myUI = value; } }
        private Color colour = Color.White;
        private bool isSelected;
        public bool IsSeleceted { set { isSelected = value; } }
        private int toolbarNumber;
        public int ToolbarNumber { get { return toolbarNumber; } set { toolbarNumber = value; } }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - texture.Width / 2, (int)Position.Y - texture.Height / 2, texture.Width, texture.Height);
            }
        }
        public string Text { get; set; }


        #endregion
        #region Constructors

        public Button(Texture2D texture, SpriteFont font, bool isMenuButton)
        {
            this.texture = texture;
            this.font = font;
            this.isMenuButton = isMenuButton;
            PenColour = Color.Black;
        }

        public Button(GameWorld myWorld)
        {
            this.myWorld = myWorld;
        }

        #endregion
        #region Methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isSelected == true)
            {
                colour = Color.DarkBlue;
            } else if (isMouseHovering && isMenuButton && colour == Color.White)
            {
                colour = Color.LightGray;
            } else if (isMouseHovering != true && colour != Color.White)
            {
                colour = Color.White;
            } else if (isSelected != true && colour == Color.DarkBlue)
            {
                colour = Color.White;
            }

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
                    if(toolbarNumber > 0)
                    {
                        myUI.CurrentToolbarPicked = toolbarNumber;
                    }
                    Click?.Invoke(this, new EventArgs()); 
                }
            }
        }
        #endregion
    }
}
