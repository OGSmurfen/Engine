using Animator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyEngineImpl
{
    public class GameObject
    {
        public Vector2 Position { get; set; }
        public Sprite? Sprite { get; set; } = null!;
        public Animation? Animation { get; set; } = null!;

        public void Update(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Draw(spriteBatch, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Animation != null)
            {
                Animation.DrawAndLoop(Position, spriteBatch, gameTime);
            }
            else if (Sprite != null)
            {
                Sprite.Draw(spriteBatch, Position);
            }
        }
    }
}
