using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace HackathonFoolsJourney
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Assets assets;
        private Renderer renderer;
        private readonly Color ClearColor = new Color(0.05f, 0, 0.1f);
        private Textbox textbox = null;

        // MAIN GAME STATE
        private JourneyState journey;

        float rotation = 0;
        private float[] fieldRotations = new float[4];

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            journey = new JourneyState();
            journey.StartGame();

            Window.Title = "Fool's Journey";
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnWindowResized;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            assets = new(this);
            renderer = new(this, _spriteBatch, assets);

            int textboxWidth = 500;
            int textboxHeight = 200;
            var textboxArea = new Rectangle((Renderer.VirtualWidth - textboxWidth) / 2, Renderer.VirtualHeight - textboxHeight, textboxWidth, textboxHeight);
            textbox = new(assets.Font, "Hello World! I am a textbox that contains text wrapping which is pretty cool...", textboxArea);
        }

        private void OnWindowResized(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Spin the 4 central cards — only 1 full rotation then stop perfectly flat
            for (int i = 0; i < journey.AdventureField.Count; i++)
            {
                if (fieldRotations[i] < MathHelper.TwoPi * 2 + MathHelper.PiOver2)          // 6.28 = exactly 1 full rotation
                    fieldRotations[i] += 0.09f;
                else
                    fieldRotations[i] = MathHelper.PiOver2 * 13;             // ← FORCE perfect flat face-up when done
            }
            base.Update(gameTime);
        }

        private void DrawEdgeBars()
        {
            Color barColor = new(0.1f, 0, 0.2f);
            if (renderer.OffsetX > 0)
            {
                float barWidth = renderer.OffsetX;
                renderer.DrawRect(0, 0, barWidth, renderer.Height, barColor);
                renderer.DrawRect(renderer.Width - barWidth, 0, barWidth, renderer.Height, barColor);
            }
            if (renderer.OffsetY > 0)
            {
                float barHeight = renderer.OffsetY;
                renderer.DrawRect(0, 0, renderer.Width, barHeight, barColor);
                renderer.DrawRect(0, renderer.Height - barHeight, renderer.Width, barHeight, barColor);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            renderer.DrawCentered(assets.BGCastle, Renderer.VirtualWidth / 2, Renderer.VirtualHeight / 2, new Vector2(8), Color.Violet);
            DrawEdgeBars();

            // === 4 CENTRAL CARDS ===
            const int cardW = 110;
            const int cardH = 160;
            const int startX = 200;
            const int startY = 400;                    // ← CHANGE THIS to move cards up/down

            for (int i = 0; i < journey.AdventureField.Count; i++)
            {
                var card = journey.AdventureField[i];
                int x = startX + i * (cardW + 35);

                renderer.DrawAnimatedCard(assets.CardFool, x, startY, fieldRotations[i], 1.85f);
                renderer.DrawTextScaled(assets.Font, card.Name, x - 64, startY + cardH - 44, 1.2f);
            }

            renderer.DrawTextScaled(assets.Font, $"Vitality: {journey.Fool.Vitality}/25", 40, 40, 2.5f);
            renderer.DrawTextScaled(assets.Font, $"Satchel: {journey.Fool.Satchel.Count}/3", 40, 90, 2.0f);

            // Spinning deck in top right
            rotation += 0.05f;
            renderer.DrawAnimatedCard(assets.CardBack, 716, 134, rotation, 2.2f);

            if (textbox != null)
            {
                textbox.Draw(renderer);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}