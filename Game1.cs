﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong02
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AudioManager _audioManager;

        private Texture2D _background;

        private Bat _playerBat;
        private CpuBat _cpuBat;
        private Ball _ball;

        private Score _score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();

            _audioManager = new AudioManager(Content);
            ScreenHelper.Initialise(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _ball = new Ball(Content, _audioManager);
            _playerBat = new Bat(Content, _graphics.PreferredBackBufferWidth * 0.05f);
            _cpuBat = new CpuBat(Content, _graphics.PreferredBackBufferWidth * 0.95f, _ball);

            _score = new Score(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _audioManager.PlaySong();

            _background = Content.Load<Texture2D>("Sprites/pongBackground");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _playerBat.Update();
            _cpuBat.Update();
            _ball.Update(_playerBat, _cpuBat, _score);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);

            _playerBat.Draw(_spriteBatch);
            _cpuBat.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);

            _score.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}