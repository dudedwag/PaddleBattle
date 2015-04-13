using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class LeftPaddle : Paddle
    {
        public override void Update()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if(position.Y>4)
                position.Y-=5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if(position.Y < (resolution.Y - sprite.Height))
                position.Y+=5;
            }
        }
    }
}
