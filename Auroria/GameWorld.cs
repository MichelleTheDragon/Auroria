﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Auroria
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Color backgroundColour = Color.CornflowerBlue;

        private List<Component> gameComponents = new List<Component>();
        private List<Component> menuComponents = new List<Component>();
        public List<Component> MenuComponents { set { menuComponents = value; } }
        public List<Component> GameComponents { set { gameComponents = value; } }

        private List<GameObject> myGameObjects = new List<GameObject>();
        public List<GameObject> MyGameObjects { get { return myGameObjects; } }
        private PlayerObject player;
        public PlayerObject Player { get { return player; } set { player = value; } }

        private WorldAssembler myWorld;
        private UI myUI;
        private Input myInput;

        private TextContainer textBox;

        private bool menuActive;
        private bool escDown;
        private bool isFullscreen; 
        
        //private int TargetWidth = 640;
        //private int TargetHeight = 320;
        //private Matrix cameraScale;
        //private float cameraScaleX;
        //private float cameraScaleY;
        //public float[] CameraScale { get { return new float[] { TargetWidth, TargetHeight }; } } 


        private Vector2 worldOffset = Vector2.Zero;
        public Vector2 WorldOffset { get { return worldOffset; } set { worldOffset = value; } }
        public bool MenuActive { get { return menuActive; } }

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width - 300; //sets the width of the window
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 200; //sets the height of the window
            //_graphics.IsFullScreen = true; //set the window to fullscreen
            _graphics.ApplyChanges(); //applies the changes
                                      // Somewhere in initialisation
            //cameraScaleX = _graphics.PreferredBackBufferWidth / TargetWidth;
            //cameraScaleY = _graphics.PreferredBackBufferHeight / TargetHeight;
            //cameraScale = Matrix.CreateScale(new Vector3(cameraScaleX, cameraScaleY, 1));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            myWorld = new WorldAssembler();
            myUI = new UI(this);

            textBox = new TextContainer(new Vector2(GraphicsDevice.DisplayMode.Width/2, GraphicsDevice.DisplayMode.Height -200), new Vector2(400, 200));

            textBox.LoadContent(Content, _graphics);
            myUI.LoadContent(Content, _graphics);
            myWorld.LoadContent(Content, this, _graphics);
            myInput = new Input(player, myUI, this);
            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            if(Keyboard.GetState().IsKeyDown(Keys.Escape) && escDown != true)
            {
                MenuToggle();
                escDown = true;
            } else if (Keyboard.GetState().IsKeyUp(Keys.Escape) && escDown == true)
            {
                escDown = false;
            }

            foreach (GameObject myObject in myGameObjects)
            {
                myObject.Update(gameTime);
            }
            player.Update(gameTime);
            foreach (Component component in gameComponents)
            {
                component.Update(gameTime);
            }
            if (menuActive == true)
            {
                foreach (Component menuComponent in menuComponents)
                {
                    menuComponent.Update(gameTime);
                }
            }
            myUI.Update(gameTime);
            myInput.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.C) && textBox.Active != true)
            {
                textBox.Active = true;
            }

            textBox.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();// SpriteSortMode.Immediate, null, null, null, null, null, cameraScale);

            foreach(GameObject myObject in myGameObjects)
            {
                myObject.Draw(_spriteBatch, worldOffset);
            }
            player.Draw(_spriteBatch, worldOffset);
            myUI.Draw(_spriteBatch);

            foreach (Component component in gameComponents)
            {
                component.Draw(gameTime, _spriteBatch);
            }
            if (menuActive == true)
            {
                foreach (Component menuComponent in menuComponents)
                {
                    menuComponent.Draw(gameTime, _spriteBatch);
                }
            }

            textBox.Draw(gameTime, _spriteBatch);


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void AddObject(GameObject newObject)
        {
            myGameObjects.Add(newObject);
        }

        public void AddComponent(Component newComponent)
        {
            gameComponents.Add(newComponent);
        }

        public void ToggleFullscreen()
        {
            isFullscreen = !isFullscreen;
            _graphics.IsFullScreen = isFullscreen; //set the window to fullscreen
            _graphics.ApplyChanges(); //applies the changes
        }
        public void MenuToggle()
        {   
            menuActive = !menuActive;
        }
    }
}
