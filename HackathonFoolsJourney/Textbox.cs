using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace HackathonFoolsJourney
{
    public class Textbox
    {
        private readonly SpriteFont font;
        private readonly string text;
        private readonly float textScale;
        private readonly int ticksToIncrement;

        private readonly float x;
        private readonly float y;
        private readonly int width;
        private readonly int height;

        private int nextIncrement;
        private int characterIndex;

        public Textbox(SpriteFont font, string text, Rectangle area, int speed = 2)
        {
            this.font = font;
            this.text = text;
            textScale = 2f;

            x = area.X;
            y = area.Y;
            width = area.Width;
            height = area.Height;

            ticksToIncrement = speed;

            characterIndex = 0;
            nextIncrement = ticksToIncrement;
        }

        public void Draw(Renderer renderer)
        {
            Color boxColor = new Color(186, 145, 227);
            Color outline = boxColor * 0.5f;
            outline.A = 255;
            //Color outline = Color.White;
            renderer.DrawRectScaled(x - 3, y - 3, width + 6, height + 6, outline);
            renderer.DrawRectScaled(x, y, width, height, boxColor);

            if (nextIncrement-- == 0)
            {
                nextIncrement = ticksToIncrement;
                characterIndex++;
                if (characterIndex >= text.Length)
                    characterIndex = text.Length;
            }
            float scale = renderer.Scale;
            string wrappedText = WrapText(text[0..characterIndex], width, textScale);
            renderer.DrawTextScaled(font, wrappedText, x + 3, y - 3, textScale);
        }

        private string WrapText(string text, float maxLineWidth, float scale)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = font.MeasureString(" ").X * scale;

            foreach (string word in words)
            {
                Vector2 size = font.MeasureString(word) * scale;

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }
    }
}
