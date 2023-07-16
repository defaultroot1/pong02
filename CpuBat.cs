using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong02
{
    internal class CpuBat : Bat
    {
        private Ball _ball;
        public CpuBat(ContentManager contentManager, float initialXPosition, Ball ball) : base(contentManager, initialXPosition)
        {
            _ball = ball;
        }

        public override void Update()
        {
            // Override the Bat Update method to have CPU control rather than keyboard control

            _position.Y *= _ball.Position.Y;

           _position.Y = MathHelper.Clamp(_position.Y, 0, ScreenHelper.ScreenHeight - _texture.Height);
        }

    }
}
