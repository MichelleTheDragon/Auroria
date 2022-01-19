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
        private int currentToolbarPicked = 1;
        public int CurrentToolbarPicked { get { return currentToolbarPicked; } set { currentToolbarPicked = value; } }
        private Button[] toolbarButtons = new Button[8];
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

            var toolbar1 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 224, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 1,
                Text = "",
            };
            var toolbar2 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 160, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 2,
                Text = "",
            };
            var toolbar3 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 96, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 3,
                Text = "",
            };
            var toolbar4 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 32, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 4,
                Text = "",
            };
            var toolbar5 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 32, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 5,
                Text = "",
            };
            var toolbar6 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 96, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 6,
                Text = "",
            };
            var toolbar7 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 160, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 7,
                Text = "",
            };
            var toolbar8 = new Button(content.Load<Texture2D>("Controls/ToolbarSlot"), content.Load<SpriteFont>("Fonts/Font"), true)
            {
                Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 + 224, (graphics.GraphicsDevice.Viewport.Height) - 100),
                ToolbarNumber = 8,
                Text = "",
            };
            var toolbarBorder = new Button(content.Load<Texture2D>("GameObjects/tollbarBorderSummer2"), content.Load<SpriteFont>("Fonts/Font"), false)
            {
                Position = new Vector2(toolbarMain.Position.X, toolbarMain.Position.Y),
                Text = "",
            };

            #endregion

            Img toolbarImg1 = new Img(content.Load<Texture2D>("GameObjects/tilesetCrops1"), new int[] { 5, 0 }, toolbar1.Position);
            Img toolbarImg2 = new Img(content.Load<Texture2D>("GameObjects/tilesetCrops1"), new int[] { 5, 1 }, toolbar2.Position);
            Img toolbarImg3 = new Img(content.Load<Texture2D>("GameObjects/tilesetCrops1"), new int[] { 5, 3 }, toolbar3.Position);
            Img toolbarImg4 = new Img(content.Load<Texture2D>("GameObjects/tilesetCrops1"), new int[] { 5, 5 }, toolbar4.Position);
            Img toolbarImg5 = new Img(content.Load<Texture2D>("GameObjects/tilesetCrops1"), new int[] { 5, 7 }, toolbar5.Position);
            Img toolbarImg6 = new Img(content.Load<Texture2D>("GameObjects/tilesetCrops1"), new int[] { 5, 9 }, toolbar6.Position);

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
            toolbar.Add(toolbarImg1);
            toolbar.Add(toolbarImg2);
            toolbar.Add(toolbarImg3);
            toolbar.Add(toolbarImg4);
            toolbar.Add(toolbarImg5);
            toolbar.Add(toolbarImg6);
            toolbar.Add(toolbarBorder);
            toolbarButtons[0] = toolbar1;
            toolbarButtons[1] = toolbar2;
            toolbarButtons[2] = toolbar3;
            toolbarButtons[3] = toolbar4;
            toolbarButtons[4] = toolbar5;
            toolbarButtons[5] = toolbar6;
            toolbarButtons[6] = toolbar7;
            toolbarButtons[7] = toolbar8;
            foreach(Button toolbarButton in toolbarButtons)
            {
                toolbarButton.MyUI = this;
                toolbarButton.Click += SelectedToolbar;
            }
            myWorld.MenuComponents = newMenu;
            myWorld.GameComponents = toolbar;

            SelectedToolbar2();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // TODO: Add your drawing code here

        }

        public void SelectedToolbar2()
        {
            foreach (Button toolbarButton in toolbarButtons)
            {
                toolbarButton.IsSeleceted = false;
            }
            toolbarButtons[currentToolbarPicked - 1].IsSeleceted = true;
        }
        private void SelectedToolbar(object sender, System.EventArgs e)
        {
            SelectedToolbar2();
        }

        /// <summary>
        ///     Call the fullscreen toggle in the GameWorld
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleFullscreen(object sender, System.EventArgs e)
        {
            myWorld.ToggleFullscreen();
        }
        /// <summary>
        ///     Call the Exit method in the Game class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            myWorld.Exit();
        }
        #endregion



    }
}
