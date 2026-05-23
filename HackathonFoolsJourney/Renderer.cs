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

        // Not the most efficient to calcualte this everytime but it shouldn't matter for a simple 2d game with only a few sprites on screen.
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

        public void DrawRectScaled(float x, float y, float width, float height, Color color)
        {
            spritebatch.Draw(assets.WhitePixel, new Vector2(x, y) * Scale + Offset, null, color, 0f, Vector2.Zero, new Vector2(width, height) * Scale, SpriteEffects.None, 0f);
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

        public void DrawScaled(Texture2D texture, float x, float y, Vector2 scale, Vector2 origin, float rotation, Color color, SpriteEffects spriteEffects = SpriteEffects.None)
        {
            spritebatch.Draw(texture, new Vector2(x, y) * Scale + Offset, null, color, rotation, origin, scale * Scale, spriteEffects, 0f);
        }

        public void DrawCentered(Texture2D texture, float x, float y, Vector2 scale, Color color)
        {
            DrawScaled(texture, x, y, scale, new Vector2(texture.Width / 2, texture.Height / 2), color);
        }

        public void DrawCentered(Texture2D texture, float x, float y, float scale)
        {
            DrawCentered(texture, x, y, new Vector2(scale), Color.White);
        }

        public void DrawCentered(Texture2D texture, float x, float y, Vector2 scale, float rotation, Color color, SpriteEffects spriteEffects = SpriteEffects.None)
        {
            DrawScaled(texture, x, y, scale, new Vector2(texture.Width / 2, texture.Height / 2), rotation, color, spriteEffects);
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

        public void DrawTextCentered(SpriteFont font, string text, float x, float y, float scale)
        {
            var size = font.MeasureString(text);
            spritebatch.DrawString(font, text, new Vector2(x, y) * Scale + Offset, Color.White, 0, size * 0.5f, scale * Scale, SpriteEffects.None, 0);
        }

        public void DrawTextCentered(SpriteFont font, string text, float x, float y, float scale, Color color)
        {
            var size = font.MeasureString(text);
            spritebatch.DrawString(font, text, new Vector2(x, y) * Scale + Offset, color, 0, size * 0.5f, scale * Scale, SpriteEffects.None, 0);
        }

        public void DrawEdgeBars()
        {
            Color barColor = new(0.1f, 0, 0.2f);
            if (OffsetX > 0)
            {
                float barWidth = OffsetX;
                DrawRect(0, 0, barWidth, Height, barColor);
                DrawRect(Width - barWidth, 0, barWidth, Height, barColor);
            }
            if (OffsetY > 0)
            {
                float barHeight = OffsetY;
                DrawRect(0, 0, Width, barHeight, barColor);
                DrawRect(0, Height - barHeight, Width, barHeight, barColor);
            }
        }

        public Rectangle GetCenteredRect(Rectangle rect)
        {
            return new Rectangle((int)(rect.X * Scale + OffsetX), (int)(rect.Y * Scale + OffsetY), (int)(rect.Width * Scale + OffsetX), (int)(rect.Height * Scale + OffsetY));
        }

        public bool MouseInHitbox(float mouseX, float mouseY, float x, float y, float width, float height)
        {

            var center = new Vector2(x, y) * Scale + Offset;
            width = width * Scale * 0.5f;
            height = height * Scale * 0.5f;
            return (mouseX > center.X - width && mouseX < center.X + width) && (mouseY > center.Y - height && mouseY < center.Y + height);
        }
    }
}
