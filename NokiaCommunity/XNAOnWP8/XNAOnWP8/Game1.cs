using System;
using System.Linq;
using System.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace XNAOnWP8
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private Texture2D _textureBackground;
        private SpriteFont _defaultFont;
        private string _text = "";

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
            _graphics.IsFullScreen = true;

            if (Environment.OSVersion.Version.Major == 8)
            {
                int? scaleFactor = null;
                var content = Application.Current.Host.Content;
                var scaleFactorProperty = content.GetType().GetProperty("ScaleFactor");
                if (scaleFactorProperty != null)
                {
                    scaleFactor = scaleFactorProperty.GetValue(content, null) as int?;
                }
                if (scaleFactor == null)
                    scaleFactor = 100;

                if (scaleFactor == 150)
                {
                    _graphics.PreferredBackBufferHeight = 450;
                    _graphics.PreferredBackBufferWidth = 800;
                }
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _textureBackground = Content.Load<Texture2D>("background");
            _defaultFont = Content.Load<SpriteFont>("DefaultFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            var touchState = TouchPanel.GetState();
            if (touchState.Any())
            {
                _text = string.Format("Position: {0}", touchState[0].Position);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_textureBackground, Vector2.Zero, Color.White);
            _spriteBatch.DrawString(_defaultFont, _text, new Vector2(10, 10), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
