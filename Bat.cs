using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pong02
{
    internal class Bat
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }

        public Bat(ContentManager contentManager)
        {
            Texture = ContentManager.Load<>
        }
    }
}
