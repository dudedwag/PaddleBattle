using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace Pong
{
    class RightPaddle : Paddle
    {
        public RightPaddle(Texture2D _sprite, Vector2 _resolution)
            : base(_sprite, _resolution)
        {
            position = new Vector2(((resolution.X - sprite.Width) - 5), (int)_resolution.Y / 2 - sprite.Height);
        }
        public override void Update(Ball _ball)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (position.Y > 4)
                    position.Y -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (position.Y < (resolution.Y - sprite.Height))
                    position.Y += 5;
            }
        }
        public void LocateBall()
        {

        }
    }
}
