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
        public Vector2 position;
        public Vector2 resolution;
        public Texture2D sprite;
        public Paddle()
        {

        }
        public Paddle(Texture2D _sprite, Vector2 _resolution)
        {
            sprite = _sprite;
            resolution = _resolution;
            
        }
        public virtual void Update() { }
        public virtual void Update(Ball _ball){}
        
        public virtual void Draw(SpriteBatch sb)
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
