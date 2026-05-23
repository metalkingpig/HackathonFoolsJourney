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

        // MAIN GAME STATE
        private JourneyState journey;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;

        }

        protected override void Initialize()
        {

            // CREATE JOURNEY
            journey = new JourneyState();

            // START GAME
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
        }

        private void OnWindowResized(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            // EXIT GAME
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TEST:
            // PRESS SPACE TO DEAL NEXT ADVENTURE
            if (keyboard.IsKeyDown(Keys.Space))
            {
                journey.DealNextAdventure();
            }

            // TEST:
            // PRESS H TO TAKE DAMAGE
            if (keyboard.IsKeyDown(Keys.H))
            {
                journey.Fool.LoseVitality(1);
            }

            // TEST:
            // PRESS J TO HEAL
            if (keyboard.IsKeyDown(Keys.J))
            {
                journey.Fool.GainVitality(1);
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

        float rotation = 0;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // DRAW CARDS
            var pos = new Vector2(50, 100);

            foreach (var texture in assets.Cards)
            {
                _spriteBatch.Draw(
                    texture,
                    pos,
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    new Vector2(1f),
                    SpriteEffects.None,
                    0f
                );

                pos.X += 100;
            }

            // DEBUG VISUAL:
            // DRAW SIMPLE RECTANGLES FOR ADVENTURE FIELD

            var fieldPos = new Vector2(50, 400);

            foreach (var card in journey.AdventureField)
            {
                Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.White });

                _spriteBatch.Draw(
                    pixel,
                    new Rectangle(
                        (int)fieldPos.X,
                        (int)fieldPos.Y,
                        80,
                        120),
                    Color.DarkRed
                );

                fieldPos.X += 100;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}