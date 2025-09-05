using Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using System;

namespace PlatformerGame
{
    public class Game1 : Core
    {

        private AnimatedSprite _slime;
        private AnimatedSprite _bat;

        private Vector2 _slimePosition;
        private const float MOVEMENT_SPEED = 5f;

        public Game1() : base("Platformer Game", 1280, 720, false)
        {

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

            TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");
            _slime = atlas.CreateAnimatedSprite("slime-animation");
            _slime.Scale = new Vector2(4, 4);

            _bat = atlas.CreateAnimatedSprite("bat-animation");
            _bat.Scale = new Vector2(4, 4);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _slime.Update(gameTime);
            _bat.Update(gameTime);

            CheckKeyboardInput();

            base.Update(gameTime);
        }
        private void CheckKeyboardInput()
        {
            float speed = MOVEMENT_SPEED;
            if (Input.Keyboard.IsKeyDown(Keys.Space))
                speed *= 2f;

            if(Input.Keyboard.IsKeyDown(Keys.W) || Input.Keyboard.IsKeyDown(Keys.Up))
                _slimePosition.Y -= speed;

            if (Input.Keyboard.IsKeyDown(Keys.A) || Input.Keyboard.IsKeyDown(Keys.Left))
                _slimePosition.X -= speed;

            if (Input.Keyboard.IsKeyDown(Keys.S) || Input.Keyboard.IsKeyDown(Keys.Down))
                _slimePosition.Y += speed;

            if (Input.Keyboard.IsKeyDown(Keys.D) || Input.Keyboard.IsKeyDown(Keys.Right))
                _slimePosition.X += speed;

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _slime.Draw(SpriteBatch, _slimePosition);
            _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
