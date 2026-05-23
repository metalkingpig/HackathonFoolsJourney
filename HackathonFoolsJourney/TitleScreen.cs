using Microsoft.Xna.Framework;
using System;

namespace HackathonFoolsJourney
{
    public class TitleScreen
    {
        private readonly Assets assets;
        private readonly CardEffect[] cards;
        public int age;

        public TitleScreen(Assets assets)
        {
            this.assets = assets;
            cards = new CardEffect[20];

            // Gen cards
            int cardsPerRow = 5;
            int j = 0;
            float xIncr = (float)Renderer.VirtualWidth / (cardsPerRow + 1);
            float x = 0f;
            float y = 300f;
            for (int i = 0; i < cards.Length; i++)
            {
                j++;
                x += xIncr;
                cards[i] = new CardEffect(new Vector2(x, y), i, i * 4);
                if (j == cardsPerRow)
                {
                    j = 0;
                    x = 0f;
                    y += 80;
                }
            }
        }

        public void Draw(Renderer renderer)
        {
            age++;

            renderer.DrawCentered(assets.BGCastle, Renderer.VirtualWidth / 2, Renderer.VirtualHeight / 2, new Vector2(8), Color.Violet);

            string title = "Fool's Journey";
            renderer.DrawTextCentered(assets.Font, title, Renderer.VirtualWidth / 2f, 100, 6);

            // Don't like this code but it works
            for (int i = 0; i < cards.Length; i++)
            {
                CardEffect card = cards[i];
                card.timer += 0.05f;
                int leaveAge = 60 + (card.card * 5);
                if (age > leaveAge)
                {
                    float num = (age - leaveAge) * 0.1f;
                    card.rotation += 0.08f;
                    card.pos = card.pos + new Vector2(MathF.Sin(card.rotation), -MathF.Cos(card.rotation)) * 5 * num;
                }
                cards[i] = card;
            }

            Color color = Color.White;
            if (age > 60)
            {
                int alpha = 255 - (age - 60) * 2;
                if (alpha < 0)
                    color.A = 0;
                else
                    color.A = (byte)alpha;
            }

            for (int i = 0; i < cards.Length; i++)
            {
                CardEffect card = cards[i];
                renderer.DrawCentered(assets.Cards[card.card], card.pos.X, card.pos.Y + MathF.Sin(card.timer) * 10f, new Vector2(2), card.rotation, color);
            }
        }

        private struct CardEffect(Vector2 pos, int card, int timer)
        {
            public Vector2 pos = pos;
            public int card = card;
            public float timer = timer;
            public float rotation = 0;
        }
    }
}
