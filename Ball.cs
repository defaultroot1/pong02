using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong02
{
    internal class Ball
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity = new Vector2(1, 0);
        private float _speed = 3.0f;

        public Ball(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/pongBall");
            _position = new Vector2(
                (ScreenHelper.ScreenWidth / 2) + _texture.Width / 2, 
                (ScreenHelper.ScreenHeight / 2) + _texture.Height / 2);

            _velocity.Normalize();
        }

        public void Update()
        {
            _position += _velocity * _speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public void increaseBallSpeed(float amount = 1.0f)
        {
            _speed += amount;
        }
    }


}
