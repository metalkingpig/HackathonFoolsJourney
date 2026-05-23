using HackathonFoolsJourney.GameRules;
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

        private TitleScreen titleScreen;
        private GameState gamestate;

        public MouseState currentMouseState;
        public MouseState previousMouseState;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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

            //int textboxWidth = 500;
            //int textboxHeight = 200;
            //var textboxArea = new Rectangle((Renderer.VirtualWidth - textboxWidth) / 2, Renderer.VirtualHeight - textboxHeight - 3, textboxWidth, textboxHeight);
            //textbox = new(assets.Font, "Hello World! I am a textbox that contains text wrapping which is pretty cool...", textboxArea);
            //textbox = new(assets.Font, "Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello Hello");
            //textbox = new(assets.Font, "Placehold\nPlacehold\nPlacehold\nPlacehold\nPlaceholder", textboxArea);

            //titleScreen = new TitleScreen(assets);
            gamestate = new GameState(this, assets, renderer);
        }

        private void OnWindowResized(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (titleScreen == null)
            {
                gamestate.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);

            // Start Rendering
            // SamplerState.PointClamp keeps pixel art sprites from appearing blurry when scaled up
            _spriteBatch.Begin(blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp);

            if (titleScreen != null)
            {
                titleScreen.Draw(renderer);
                if (titleScreen.age > 240)
                    titleScreen = null;
            }
            else
            {
                gamestate.Draw(renderer);

                // Test rendering sprites that are scaled with window
                //renderer.DrawScaled(assets.CardFool, 0, 0, 2);
                //renderer.DrawScaled(assets.CardEmpress, 800 - assets.CardEmpress.Width * 2f, 0, 2);

                // Animated card test
                //rotation += 0.05f;
                //renderer.DrawAnimatedCard(assets.CardSword1, 200, 200, rotation, 2f);
                //renderer.DrawAnimatedCard(assets.CardChariot, 400, Renderer.VirtualHeight - assets.CardHeight, rotation + 0.5f, 2f);

                //Text example
                //renderer.DrawTextScaled(assets.Font, "Scale: " + renderer.Scale, 0, 700, 2);
                //renderer.DrawTextScaled(assets.Font, "Score: 100", 0, 0, 4);

                // UI
                //if (textbox != null) textbox.Draw(renderer);
            }

            // Finish rendering
            _spriteBatch.End();

            //test
            //_spriteBatch.Begin(blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointWrap);
            //_spriteBatch.Draw(assets.Gradient, new Rectangle(0, 0, 200, 400), new Rectangle(0, 0, 10, 20), Color.White);
            //_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
