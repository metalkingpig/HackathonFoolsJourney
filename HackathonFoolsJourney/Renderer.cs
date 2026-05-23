using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace HackathonFoolsJourney
{
    public class Renderer
    {
        private readonly Game game;
        private readonly SpriteBatch spritebatch;
        private readonly Assets assets;

        public Renderer(Game game, SpriteBatch spritebatch, Assets assets)
        {
            this.game = game;
            this.spritebatch = spritebatch;
            this.assets = assets;
        }

        public const int VirtualWidth = 800;
        public const int VirtualHeight = 800;

        public int Width => game.Window.ClientBounds.Width;

        public int Height => game.Window.ClientBounds.Height;

        public float Scale
        {
            get
            {
                var scaleX = (float)Width / VirtualWidth;
                var scaleY = (float)Height / VirtualHeight;
                return Math.Min(scaleX, scaleY);
            }
        }

        public float OffsetX => (Width - (VirtualWidth * Scale)) / 2f;

        public float OffsetY => (Height - (VirtualHeight * Scale)) / 2f;

        public Vector2 Offset => new Vector2(OffsetX, OffsetY);

        public void DrawRect(float x, float y, float width, float height, Color color)
        {
            spritebatch.Draw(assets.WhitePixel, new Vector2(x, y), null, color, 0f, Vector2.Zero, new Vector2(width, height), SpriteEffects.None, 0f);
        }

        public void DrawScaled(Texture2D texture, float x, float y, float scale)
        {
            spritebatch.Draw(texture, new Vector2(x, y) * Scale + Offset, null, Color.White, 0f, Vector2.Zero, new Vector2(scale * Scale), SpriteEffects.None, 0f);
        }

        public void DrawScaled(Texture2D texture, float x, float y, Vector2 scale, Vector2 origin = default)
        {
            spritebatch.Draw(texture, new Vector2(x, y) * Scale + Offset, null, Color.White, 0f, origin, scale * Scale, SpriteEffects.None, 0f);
        }

        public void DrawScaled(Texture2D texture, float x, float y, Vector2 scale, Vector2 origin, Color color, SpriteEffects spriteEffects = SpriteEffects.None)
        {
            spritebatch.Draw(texture, new Vector2(x, y) * Scale + Offset, null, color, 0f, origin, scale * Scale, spriteEffects, 0f);
        }

        public void DrawCentered(Texture2D texture, float x, float y, Vector2 scale, Color color)
        {
            DrawScaled(texture, x, y, scale, new Vector2(texture.Width / 2, texture.Height / 2), color);
        }

        public void DrawAnimatedCard(Texture2D frontsideTexture, float x, float y, float rotation, Vector2 scale)
        {
            float realrot = MathF.Sin(rotation);
            Vector2 origin = new(assets.CardWidth * 0.5f, assets.CardHeight * 0.5f);
            if (realrot > 0)
                DrawScaled(frontsideTexture, x, y, new Vector2(scale.X * realrot, scale.Y), origin);
            else
                DrawScaled(assets.CardBackside, x, y, new Vector2(scale.X * -realrot, scale.Y), origin);
        }

        public void DrawAnimatedCard(Texture2D frontsideTexture, float x, float y, float rotation, float scale)
        {
            DrawAnimatedCard(frontsideTexture, x, y, rotation, new Vector2(scale));
        }

        public void DrawTextScaled(SpriteFont font, string text, float x, float y, float scale)
        {
            spritebatch.DrawString(font, text, new Vector2(x, y) * Scale + Offset, Color.White, 0, default, scale * Scale, SpriteEffects.None, 0);
        }
    }
}
