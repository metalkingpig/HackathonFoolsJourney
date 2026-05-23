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

            int textboxWidth = 500;
            int textboxHeight = 200;
            var textboxArea = new Rectangle((Renderer.VirtualWidth - textboxWidth) / 2, Renderer.VirtualHeight - textboxHeight, textboxWidth, textboxHeight);
            textbox = new(assets.Font, "Hello World! I am a textbox that contains text wrapping which is pretty cool...", textboxArea);
            //textbox = new(assets.Font, "Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello");
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

            // TEST: PRESS SPACE TO DEAL NEXT ADVENTURE
            if (keyboard.IsKeyDown(Keys.Space))
            {
                journey.DealNextAdventure();
            }

            // TEST: PRESS H TO TAKE DAMAGE
            if (keyboard.IsKeyDown(Keys.H))
            {
                journey.Fool.LoseVitality(1);
            }

            // TEST: PRESS J TO HEAL
            if (keyboard.IsKeyDown(Keys.J))
            {
                journey.Fool.GainVitality(1);
            }

            // ====================== PDF GAMEPLAY CONTROLS ======================
            // 1-4 = Store card in Satchel
            if (keyboard.IsKeyDown(Keys.D1)) journey.StoreCardInSatchel(0);
            if (keyboard.IsKeyDown(Keys.D2)) journey.StoreCardInSatchel(1);
            if (keyboard.IsKeyDown(Keys.D3)) journey.StoreCardInSatchel(2);
            if (keyboard.IsKeyDown(Keys.D4)) journey.StoreCardInSatchel(3);

            // E = Equip Wisdom (Coins)
            if (keyboard.IsKeyDown(Keys.E)) journey.EquipWisdom(0);
            // Q = Equip Strength (Batons)
            if (keyboard.IsKeyDown(Keys.Q)) journey.EquipStrength(0);
            // W = Equip Volition (Swords)
            if (keyboard.IsKeyDown(Keys.W)) journey.EquipVolition(0);

            // R = Resolve first Challenge
            if (keyboard.IsKeyDown(Keys.R)) journey.ResolveChallenge(0);

            // A = Take Chance with Ace
            if (keyboard.IsKeyDown(Keys.A)) journey.TakeChance(0);

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
            GraphicsDevice.Clear(ClearColor);

            // Start Rendering
            // SamplerState.PointClamp keeps sprites from appearing blurry
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw BG
            renderer.DrawCentered(assets.BGCastle, Renderer.VirtualWidth / 2, Renderer.VirtualHeight / 2, new Vector2(8), Color.Violet);

            // Draw bars on screen edge when resizing window
            DrawEdgeBars();

            renderer.DrawScaled(assets.CardDevil, 400, 400, 2);


            // Test rendering sprites that are scaled with window
            renderer.DrawScaled(assets.CardFool, 0, 0, 2);
            renderer.DrawScaled(assets.CardEmpress, 800 - assets.CardEmpress.Width * 2f, 0, 2);

            // Animated card test
            rotation += 0.05f;
            renderer.DrawAnimatedCard(assets.CardFool, 200, 200, rotation, 2f);
            renderer.DrawAnimatedCard(assets.CardChariot, 400, Renderer.VirtualHeight - assets.CardHeight, rotation + 0.5f, 2f);

            //Text example
            renderer.DrawTextScaled(assets.Font, "Scale: " + renderer.Scale, 0, 700, 2);
            //renderer.DrawTextScaled(assets.Font, "Score: 100", 0, 0, 4);

            // UI
            if (textbox != null)
            {
                textbox.Draw(renderer);
            }

            // Finish rendering
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}