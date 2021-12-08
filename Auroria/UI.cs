using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    public class UI
    {
        #region Fields
        private GameWorld myWorld;
        private string currentType;
        private int currentSeed;
        public string CurrentType { get { return currentType; } }
        public int CurrentSeed { get { return currentSeed; } }


        #endregion

        #region Properties

        #endregion

        #region Constructors
        public UI(GameWorld myWorld)
        {
            this.myWorld = myWorld;
        }

        #endregion

        #region Methods
        public void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            List<Component> newMenu = new List<Component>();
            var exitButton = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2),
                Text = "Exit",
            };

            exitButton.Click += ExitButton_Click;

            newMenu.Add(exitButton);

            myWorld.MenuComponents = newMenu;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // TODO: Add your drawing code here

        }
        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            myWorld.Exit();
        }
        #endregion



    }
}
