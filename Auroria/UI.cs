﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auroria
{
    class UI
    {
        #region Fields
        private GameWorld myWorld;

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
        public void LoadContent(ContentManager content)
        {

            var exitButton = new Button(content.Load<Texture2D>("Controls/Button"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(100, 100),
                Text = "Exit",
            };

            exitButton.Click += ExitButton_Click;

            myWorld.AddComponent(exitButton);
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
