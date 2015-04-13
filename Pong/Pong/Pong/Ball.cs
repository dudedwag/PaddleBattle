using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace Pong
{
    public class Ball
    {
        Vector2 position;
        Vector2 speed;
        Vector2 resolution;
        Vector2 direction;
        Color color;
        Texture2D sprite;
        Random rand;
        Game1 mainGame;
        int score1, score2;
        
        public Ball(Texture2D _sprite, Vector2 _resolution, Game1 _game)
        {
            sprite = _sprite;
            resolution = _resolution;
            score1 = 0;
            score2 = 0;
            rand = new Random();
            Spawn();
            mainGame = _game;
        }
        public void Update()
        {
            CheckBounds();
            position += (direction * speed);
            color = Color.White;
        }        
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, position, color);
        }
        public void CheckCollision(Paddle _paddle, Game _game)
        {
            //If left side of ball is between left and right side of paddle
            if (position.X < (_paddle.Position.X + _paddle.Width) && position.X > _paddle.Position.X)
            {
                //If top of ball or bottom of ball is between top and bottom of paddle.
                if ((position.Y > _paddle.Position.Y) && (position.Y < (_paddle.Position.Y + _paddle.Height)) || (position.Y + sprite.Height > _paddle.Position.Y) && (position.Y + sprite.Height < (_paddle.Position.Y + _paddle.Height)))
                {
                    if(direction.X == -1)
                    direction.X *= -1;
                }
                    
            }
           
        }
        public void Spawn()
        {
            //Center the position of the ball, no matter what resolution.
            position = new Vector2(resolution.X / 2 - sprite.Width, resolution.Y / 2 - sprite.Height);          
            speed = new Vector2(rand.Next(1, 5), rand.Next(1, 5));
            //Randomly choose -1 or 1.
            direction = new Vector2((rand.Next(0, 2) * 2) - 1, rand.Next(0, 2) * 2 - 1);                        
        }
        public void CheckBounds()
        {
            //If ball reaches the bottom of the screen
            if ((position.Y + (direction.Y * speed.Y)) > (resolution.Y - sprite.Height))
            {
                speed.X += (float)rand.NextDouble();
                direction.Y *= -1;
                color = Color.Red;
            }
            //If ball reaches the top of the screen
            else if ((position.Y + (direction.Y * speed.Y)) < 0)
            {
                speed.Y += (float)rand.NextDouble();
                direction.Y *= -1;
                color = Color.Red;
            }
            //If ball reaches right side of the screen
            if (position.X + sprite.Width > resolution.X)
            {
                score1 += 1;
                Spawn();
            }
            //If ball reaches left side of the screen
            else if (position.X < 0)
            {
                score2 += 1;
                Spawn();
            }
        }

        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; } 
        }
        public Vector2 Position 
        {
            get { return position; }
            private set { position = value; } 
        }
        public int Score1
        {
            get { return score1; }
            set { score1 = value; }
        }
        public int Score2
        {
            get { return score2; }
            set { score2 = value; }
        }
    }
}
