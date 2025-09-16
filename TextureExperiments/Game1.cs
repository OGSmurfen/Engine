using Animator;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGuiNet;
using MyEngineImpl;
using System.Collections.Generic;

namespace TextureExperiments
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        
        Scene _scene = new Scene();

        private ImGuiRenderer imGuiRenderer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            imGuiRenderer = new ImGuiRenderer(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D slimeTexture = Texture2D.FromFile(GraphicsDevice, "Content/tex.png");

            List<Sprite> slimeSprites = new List<Sprite>
            {
                new Sprite(slimeTexture, new Rectangle(10, 0, 50, 60)),
                new Sprite(slimeTexture, new Rectangle(60, 0, 60, 60)),
                new Sprite(slimeTexture, new Rectangle(120, 0, 60, 60)),
                new Sprite(slimeTexture, new Rectangle(180, 0, 60, 60)),
            };

            Animation slimeAnimation = new Animation(slimeSprites, .15f);

            GameObject slime = new GameObject
            {
                Position = new Vector2(100, 100),
                Animation = slimeAnimation,
            };

            _scene.AddGameObject(slime);

            imGuiRenderer.RebuildFontAtlas();

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


            foreach (var gameObject in _scene.GameObjects)
                gameObject.Update(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);

            imGuiRenderer.BeginLayout(gameTime);

            ImGui.Begin("Menu");
            
            foreach(var gameObject in _scene.GameObjects)
            {
                var pos = gameObject.Position.ToNumerics();

                if (ImGui.DragFloat2("Position", ref pos))
                {
                    gameObject.Position = new Vector2(pos[0], pos[1]);
                }
                    
            }

            ImGui.End();

            imGuiRenderer.EndLayout();
        }
    }
}
