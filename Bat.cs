using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong02
{
    internal class Bat
    {
        private Texture2D _texture;
        private Vector2 _position;
        private const float _speed = 5f;

        public Bat(ContentManager contentManager, float initialXPosition)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/pongBat");

            // X is defined by the initialisation, Y takes into account Texture height to center on screen
            _position = new Vector2(initialXPosition, (ScreenHelper.ScreenHeight / 2) - _texture.Height / 2);
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W))
            {
                _position.Y -= _speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                _position.Y += _speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public int GetPaddleHeight()
        {
            return _texture.Height / 2;
        }
    }
}
