using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackathonFoolsJourney
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Assets assets;

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
            Window.AllowUserResizing = true;

            // CREATE JOURNEY
            journey = new JourneyState();

            // START GAME
            journey.StartGame();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            assets = new(this);
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