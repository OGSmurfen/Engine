using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animator
{
    public class Animation
    {
        public List<Sprite> Frames { get; set; }
        public float FrameDuration { get; set; }
        private int currentFrameIndex;
        private float elapsedFrameTime;

        public Animation(List<Sprite> frames, float animationDuration)
        {
            Frames = frames;
            FrameDuration = animationDuration;
        }

        public void DrawAndLoop(Vector2 location, SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawCurrentFrame(location, spriteBatch);
            LoopAnimation(gameTime);
        }
        public void LoopAnimation(GameTime gameTime)
        {
            elapsedFrameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedFrameTime >= FrameDuration)
            {
                currentFrameIndex++;
                elapsedFrameTime = 0;
            }

            if (currentFrameIndex >= Frames.Count) currentFrameIndex = 0;
        }

        public void DrawCurrentFrame(Vector2 location, SpriteBatch spriteBatch)
        {
            Frames[currentFrameIndex].Draw(spriteBatch, location);
        }
    }
}
