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

        //My stuff
        private Deck mainDeck;
        private PlayingField field;
        private Player fool;

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

            mainDeck = new Deck(assets);
            field = new PlayingField(mainDeck);
            fool = new Player();
        }

        private void OnWindowResized(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            bool inMenu = false;
            Card selectedCard = new Card();

            field.displayCards();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[0];  //Select first field card
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('Q', selectedCard, field, fool, mainDeck);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[1];  //Select second card
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('W', selectedCard, field, fool, mainDeck);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[2];  //Select third card
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('E', selectedCard, field, fool, mainDeck);
                }   
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[3];  //Select fourth card
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('R', selectedCard, field, fool, mainDeck);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[4];  //Select 1st bag card
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('D', selectedCard, field, fool, mainDeck);
                }   
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[5];  //Select second bag card
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('D', selectedCard, field, fool, mainDeck);
                }   
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                if (!inMenu)
                {
                    selectedCard = field.field[6];  //Select third bagcard
                }
                else    //In menu
                {
                    CardFuncs.onCardSelect('Q', selectedCard, field, fool, mainDeck);
                }
            }
            // TODO: Add your update logic here
            // Get the current state of mouse input.


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

            // Start Rendering
            // SamplerState.PointClamp keeps sprites from appearing blurry
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw bars on screen edge when resizing window
            DrawEdgeBars();

            // Test rendering sprites that are scaled with window

            //renderer.DrawScaled(assets.CardFool, 0, 0, 2);
            //renderer.DrawScaled(assets.CardEmpress, 800 - assets.CardEmpress.Width * 2f, 0, 2);

            // Animated card test
            //rotation += 0.05f;
            //renderer.DrawAnimatedCard(assets.CardFool, 200, 200, rotation, 2f);
            //renderer.DrawAnimatedCard(assets.CardChariot, 400, Renderer.VirtualHeight - assets.CardHeight, rotation + 0.5f, 2f);

            // Finish rendering
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
