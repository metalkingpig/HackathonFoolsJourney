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

        private Assets assets;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Window.AllowUserResizing = true;
            //Window.ClientSizeChanged += OnResize;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            assets = new(this);
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
            //_spriteBatch.Draw(assets.CardEmperor, new Vector2(100, 100), null, Color.White, 0f, Vector2.Zero, new Vector2(2.5f), SpriteEffects.None, 0f);
            //_spriteBatch.Draw(assets.CardEmpress, new Vector2(300, 100), null, Color.White, 0f, Vector2.Zero, new Vector2(2.5f), SpriteEffects.None, 0f);
            var pos = new Vector2(0, 100);
            foreach (var texture in assets.Cards)
            {
                _spriteBatch.Draw(texture, pos, null, Color.White, 0f, Vector2.Zero, new Vector2(1f), SpriteEffects.None, 0f);
                pos.X += 100;
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
