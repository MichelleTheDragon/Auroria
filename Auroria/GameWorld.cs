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

        private List<Component> gameComponents;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
                        
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var exitButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(100, 100),
                Text = "Exit",
            };

            exitButton.Click += ExitButton_Click;

            gameComponents = new List<Component>()
            {
                exitButton
            };

            myWorld = new WorldAssembler();
            myInput = new Input();
            myUI = new UI();

            myWorld.LoadContent(Content);
            // TODO: use this.Content to load your game content here

            player = new PlayerObject(Content.Load<Texture2D>("Player"), new Vector2(_graphics.GraphicsDevice.Viewport.Width/2, _graphics.GraphicsDevice.Viewport.Height / 2));
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (var component in gameComponents)
                component.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //myUI.MenuToggle();
                Exit(); //to be replaced with line above
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

            foreach (var component in gameComponents)
                component.Draw(gameTime, _spriteBatch);

                _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
