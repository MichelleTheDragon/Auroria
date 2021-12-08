using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Auroria
{
    public class Seed : GameObject
    {
        #region Fields

        private int timePassed;
        private int seedStage = 0;
        private bool isHarvestable;

        protected Texture2D sprite;

        protected float scale = 1.0f;
        protected float layer = 1.0f;
        protected Vector2 worldPos;
        protected Rectangle rect;
        protected Vector2 origin;
        protected SpriteEffects effects;

        protected bool isSolid;
        

        protected int[] tilePos;

        #endregion


        #region Properties

        public bool IsSolid { get { return isSolid; } }

        #endregion
        #region Constructors

        public Seed(Texture2D sprite, int[] tilePos, Vector2 worldPos) : base(sprite, tilePos, worldPos, true)
        {

        }

        #endregion
        #region Methods

        public void Update(GameTime gameTime)
        {
            timePassed += (int)gameTime.ElapsedGameTime.TotalSeconds;

            switch (timePassed)
            {
                case 20:
                    seedStage = 1;
                    break;
                case 40:
                    seedStage = 2;
                    break;
                case 60:
                    seedStage = 3;
                    break;
                case 80:
                    seedStage = 4;
                    isHarvestable = true;
                    break;
            }
        

        
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, worldPos, rect, Color.White, 0.0f, origin, scale, effects, layer);
        }

        //public override void OnCollision(GameObject other)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
