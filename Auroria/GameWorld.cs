using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Auroria
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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

            foreach (GameObject myObject in myGameObjects) //Update all GameObjects (Not Player or UI)
            {
                myObject.Update(gameTime);
            }
            player.Update(gameTime); //Update Player
            foreach (Component component in gameComponents) //Update all UI Elements(Not Menu Overlay)
            {
                component.Update(gameTime);
            }
            if (menuActive == true)
            {
                foreach (Component menuComponent in menuComponents) //Update Menu Overlay elements
                {
                    menuComponent.Update(gameTime);
                }
            }
            myUI.Update(gameTime); //Update UI class
            myInput.Update(gameTime); //Update Input class

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();// SpriteSortMode.Immediate, null, null, null, null, null, cameraScale);


            foreach(GameObject myObject in myGameObjects) //Draw all GameObjects (Not Player or UI)
            {
                myObject.Draw(_spriteBatch, worldOffset);
            }
            player.Draw(_spriteBatch, worldOffset); //Draw Player
            myUI.Draw(_spriteBatch); //Draw UI

            foreach (Component component in gameComponents) //Draw all UI Elements(Not Menu Overlay)
            {
                component.Draw(gameTime, _spriteBatch);
            }
            if (menuActive == true)
            {
                foreach (Component menuComponent in menuComponents)//Draw Menu Overlay
                {
                    menuComponent.Draw(gameTime, _spriteBatch);
                }
            }


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        /// <summary>
        ///     Add a new GameObject to the list of GameObjects
        /// </summary>
        /// <param name="newObject">The GameObject being created</param>
        public void AddObject(GameObject newObject)
        {
            myGameObjects.Add(newObject);
        }

        /// <summary>
        ///     Add a new UI Component to the list of UI Components
        /// </summary>
        /// <param name="newComponent">UI Component</param>
        public void AddComponent(Component newComponent)
        {
            gameComponents.Add(newComponent);
        }

        /// <summary>
        ///     Toggle the game window between being fullscreen and windowed
        /// </summary>
        public void ToggleFullscreen()
        {
            isFullscreen = !isFullscreen; //Toggle
            _graphics.IsFullScreen = isFullscreen; //set the window
            _graphics.ApplyChanges(); //apply the change
        }

        /// <summary>
        ///     Toggle the Menu Overlay
        /// </summary>
        public void MenuToggle()
        {   
            menuActive = !menuActive;
        }
    }
}
