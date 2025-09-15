using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TextureExperiments
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _slimeTexture;
        List<Rectangle> _textureAnimations;
        int currentAnimation = 0;
        float elapsedAnimationTime = 0;
        float animationDurationTime = .15f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _slimeTexture = Texture2D.FromFile(GraphicsDevice, "Content/tex.png");
            _textureAnimations = new List<Rectangle>
            { 
                new Rectangle(10, 0, 50, 60),
                new Rectangle(60, 0, 60, 60),
                new Rectangle(120, 0, 60, 60),
                new Rectangle(180, 0, 60, 60)
            };


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CadetBlue);

            // TODO: Add your drawing code here


            _spriteBatch.Begin();

            
            _spriteBatch.Draw(_slimeTexture, new Vector2(100, 100), _textureAnimations[currentAnimation], Color.White);

            elapsedAnimationTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(elapsedAnimationTime >= animationDurationTime)
            {
                currentAnimation++;
                elapsedAnimationTime = 0;
            }
            
            if(currentAnimation >= _textureAnimations.Count) currentAnimation = 0;

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
