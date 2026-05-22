using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Reflection;

namespace HackathonFoolsJourney
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D testTexture;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            testTexture = Content.Load<Texture2D>("Cards/Fool");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //_spriteBatch.Draw(testTexture, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(testTexture, new Vector2(100, 100), null, Color.White, 0f, Vector2.Zero, new Vector2(3), SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
