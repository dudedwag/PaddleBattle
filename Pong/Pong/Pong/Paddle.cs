using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Paddle
    {
        Vector2 position;
        Vector2 resolution;
        Texture2D sprite;
        public Paddle(Texture2D _sprite, Vector2 _resolution)
        {
            sprite = _sprite;
            resolution = _resolution;
            position = new Vector2(5,(int)_resolution.Y/2 - sprite.Height);
        }
        public void Update()
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
        
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, position, Color.White);
        }
        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        }
        public int Width
        {
            get { return sprite.Width; }
        }
        public int Height
        {
            get { return sprite.Height; }
        }
    }
}
