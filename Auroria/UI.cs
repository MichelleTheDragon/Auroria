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
            List<Component> toolbar = new List<Component>();
            var FullScreenButton = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2 - 30),
                Text = "Toggle Fullscreen",
            }; 
            var exitButton = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2 + 30),
                Text = "Exit",
            };

            var toolbar1 = new Button(content.Load<Texture2D>("Controls/toolbarVersionTwo"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };

            FullScreenButton.Click += ToggleFullscreen;
            exitButton.Click += ExitButton_Click;

            newMenu.Add(FullScreenButton);
            newMenu.Add(exitButton);
            toolbar.Add(toolbar1);

            myWorld.MenuComponents = newMenu;
            myWorld.GameComponents = toolbar;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // TODO: Add your drawing code here

        }

        private void ToggleFullscreen(object sender, System.EventArgs e)
        {
            myWorld.ToggleFullscreen();
        }
        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            myWorld.Exit();
        }
        #endregion



    }
}
