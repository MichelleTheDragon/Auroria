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

        private List<GameObject> myGameObjects = new List<GameObject>();
        private PlayerObject player;

        private WorldAssembler myWorld;
        private UI myUI;
        private Input myInput;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
                        
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            myWorld = new WorldAssembler();
            myInput = new Input();
            myUI = new UI(this);

            myUI.LoadContent(Content);
            myWorld.LoadContent(Content, this);
            // TODO: use this.Content to load your game content here

            player = new PlayerObject(Content.Load<Texture2D>("Player"), new Vector2(_graphics.GraphicsDevice.Viewport.Width/2, _graphics.GraphicsDevice.Viewport.Height / 2));
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //myUI.MenuToggle();
                Exit(); //to be replaced with line above
            }

            foreach (Component component in gameComponents)
            {
                component.Update(gameTime);
            }
            myUI.Update(gameTime);
            myInput.Update(gameTime, player);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            foreach(GameObject myObject in myGameObjects)
            {
                myObject.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch);
            myUI.Draw(_spriteBatch);

            foreach (Component component in gameComponents)
            {
                component.Draw(gameTime, _spriteBatch);
            }

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
    }
}
