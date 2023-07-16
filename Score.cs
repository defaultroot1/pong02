using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace pong02
{
    internal class Score
    {
        private SpriteFont _font;
        public int player1Score = 0;
        public int player2Score = 0;

        public Score(ContentManager contentManager)
        {
            _font = contentManager.Load<SpriteFont>("Fonts/scoreFont");

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, player1Score.ToString(), new Vector2(ScreenHelper.ScreenWidth * 0.4f, 20), Color.White);
            spriteBatch.DrawString(_font, player2Score.ToString(), new Vector2(ScreenHelper.ScreenWidth * 0.6f, 20), Color.White);
        }
    }
}
