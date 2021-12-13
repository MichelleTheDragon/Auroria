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
            var FullScreenButton = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"),true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2 - 30),
                Text = "Toggle Fullscreen",
            }; 
            var exitButton = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"),true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2 + 30),
                Text = "Exit",
            };


            #region Toolbar
            var toolbarMain = new Button(content.Load<Texture2D>("Controls/Toolbar"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };

            var toolbar1 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width /2 - 224, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar2 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 160, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar3 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 96, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar4 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 32, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar5 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 32, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar6 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 96, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar7 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 160, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };
            var toolbar8 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 224, (graphics.GraphicsDevice.Viewport.Height) - 100),
                Text = "",
            };

            #endregion
            FullScreenButton.Click += ToggleFullscreen;
            exitButton.Click += ExitButton_Click;

            newMenu.Add(FullScreenButton);
            newMenu.Add(exitButton);
            toolbar.Add(toolbarMain);
            toolbar.Add(toolbar1);
            toolbar.Add(toolbar2);
            toolbar.Add(toolbar3);
            toolbar.Add(toolbar4);
            toolbar.Add(toolbar5);
            toolbar.Add(toolbar6);
            toolbar.Add(toolbar7);
            toolbar.Add(toolbar8);
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
