using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SnakeMultiplayer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _basicTexture;
        List<Rectangle> _snakeSegments;
        private const int _snakeWidth = 40;
        private int _snakeSpeed = 10;

        private int _appleWidth = 20;
        private Rectangle _applePosition;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Direction _currentDirection = Direction.Right;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _basicTexture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
            _basicTexture.SetData(new[] { Color.White });

            _applePosition = new Rectangle(300, 300, _appleWidth, _appleWidth);
            _snakeSegments = new();
            _snakeSegments.Add(new Rectangle(100, 100, _snakeWidth, _snakeWidth));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var keyboardState = Keyboard.GetState();

            if (_currentDirection != Direction.Down &&( keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)))
                _currentDirection = Direction.Up;
            else if (_currentDirection != Direction.Up && (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)))
                _currentDirection = Direction.Down;
            else if (_currentDirection != Direction.Right && (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A)))
                _currentDirection = Direction.Left;
            else if (_currentDirection != Direction.Left && (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D)))
                _currentDirection = Direction.Right;

            switch (_currentDirection)
            {
                case Direction.Up:
                    for(int i = 0; i < _snakeSegments.Count; i++)
                    {
                        var segment = _snakeSegments[i];
                        segment.Y -= _snakeSpeed;
                        _snakeSegments[i] = segment;
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < _snakeSegments.Count; i++)
                    {
                        var segment = _snakeSegments[i];
                        segment.Y += _snakeSpeed;
                        _snakeSegments[i] = segment;
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < _snakeSegments.Count; i++)
                    {
                        var segment = _snakeSegments[i];
                        segment.X -= _snakeSpeed;
                        _snakeSegments[i] = segment;
                    }
                    break;
                case Direction.Right:
                    for (int i = 0; i < _snakeSegments.Count; i++)
                    {
                        var segment = _snakeSegments[i];
                        segment.X += _snakeSpeed;
                        _snakeSegments[i] = segment;
                    }
                    break;
            }

            if (_snakeSegments[0].Intersects(_applePosition))
            {
                var newSegment = new Rectangle(_snakeSegments[^1].X, _snakeSegments[^1].Y, _snakeWidth, _snakeWidth);
                _snakeSegments.Add(newSegment);
                var random = new Random();
                _applePosition = new Rectangle(random.Next(_graphics.PreferredBackBufferWidth),
                        random.Next(_graphics.PreferredBackBufferHeight), _appleWidth, _appleWidth);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            for (int i = 0; i < _snakeSegments.Count; i++)
            {
                if (i == 0)
                    _spriteBatch.Draw(_basicTexture, _snakeSegments[i], Color.DarkGreen);
                else
                    _spriteBatch.Draw(_basicTexture, _snakeSegments[i], Color.Green);
            }

            _spriteBatch.Draw(_basicTexture, _applePosition, Color.Red);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
