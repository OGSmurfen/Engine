using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Animator
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle SpriteRange { get; set; }

        public Sprite(Texture2D sourceTexture, Rectangle spriteRange)
        {
            this.Texture = sourceTexture;
            this.SpriteRange = spriteRange;
        }


        public static Sprite FromTexture2D(Texture2D sourceTexture, Rectangle spriteRange)
        {
            return new Sprite(sourceTexture, spriteRange);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(this.Texture, position, this.SpriteRange, Color.White);
        }

    }
}
