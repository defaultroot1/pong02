using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace pong02
{
    internal class Ball
    {
        private Texture2D _texture;
        private AudioManager _audioManager;
        private Vector2 _position;
        private Vector2 _velocity = new Vector2(1, 1);

        public Vector2 Position { get { return _position; } }

        private const float initialBallSpeed = 3.0f; // Initial ball speed and speed on reset
        private const float ballIncreaseSpeed = 0.5f; // How much the ball speeds up with each paddle hit
        private float _speed = initialBallSpeed;

        public Ball(ContentManager contentManager, AudioManager audioManager)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/pongBall");
            _audioManager = audioManager;
            _position = new Vector2(
                (ScreenHelper.ScreenWidth / 2) + _texture.Width / 2, 
                (ScreenHelper.ScreenHeight / 2) + _texture.Height / 2);

            //_velocity.Normalize();
        }

        public void Update(Bat playerBat, Bat cpuBat, Score score)
        {
            _position += _velocity * _speed;

            // Handle collision of ball with bats
            if(GetBounds().Intersects(playerBat.GetBounds()) || GetBounds().Intersects(cpuBat.GetBounds()))
            {
                _velocity.X *= -1;
                _speed += ballIncreaseSpeed;
                _audioManager.PlayClickSound();
            }

            if(_position.Y <= 0 || _position.Y >= ScreenHelper.ScreenHeight - _texture.Height)
            {
                _velocity.Y *= -1;
                _audioManager.PlayClickSound();
            }

            if(_position.X < 0)
            {
                score.player2Score += 1;
                _audioManager.PlayGoalSound();
                Reset();
            }

            if(_position.X > ScreenHelper.ScreenWidth - _texture.Width)
            {
                score.player1Score += 1;
                _audioManager.PlayGoalSound();
                Reset();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public void increaseBallSpeed(float amount = 1.0f)
        {
            _speed += amount;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public void Reset()
        {
            _position = new Vector2(
                (ScreenHelper.ScreenWidth / 2) + _texture.Width / 2,
                (ScreenHelper.ScreenHeight / 2) + _texture.Height / 2);

            _speed = initialBallSpeed;

            Random random = new Random();
            int result = random.Next(3); // Generate random number, from 0 - 3, to randomise ball direction

            switch (result)
            {
                case 0:
                    _velocity = new Vector2(1, -1);
                    break;
                case 1:
                    _velocity = new Vector2(1, 1);
                    break;
                case 2:
                    _velocity = new Vector2(-1, 1);
                    break;
                case 3:
                    _velocity = new Vector2(-1, -1);
                    break;
            }
        }


    }


}
