using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Ball
    {
        public Texture2D ballTexture;
        public Vector2 ballPosition;
        public float ballSpeedX;
        public float ballSpeedY;
        public int ballWidth;
        public int ballHeight;

        public Ball(Texture2D ballTexture, Vector2 initialPosition)
        {
            this.ballTexture = ballTexture;
            this.ballPosition = initialPosition;
            ballSpeedX = 400;
            ballSpeedY = 400;
            ballWidth = ballTexture.Width;
            ballHeight = ballTexture.Height;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, Bar leftBar, Bar rightBar, Score score)
        {
            ballPosition.X += ballSpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            ballPosition.Y += ballSpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ballPosition.X > graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
            {
                score.IncrementPlayer1Score();
                ResetBall(graphics);
            }
            else if (ballPosition.X < ballTexture.Width / 2)
            {
                score.IncrementPlayer2Score();
                ResetBall(graphics);
            }

            if (ballPosition.Y > graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
            {
                ballPosition.Y = graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                ballSpeedY = -ballSpeedY;
            }
            else if (ballPosition.Y < ballTexture.Height / 2)
            {
                ballPosition.Y = ballTexture.Height / 2;
                ballSpeedY = -ballSpeedY;
            }

            Rectangle ballRectangle = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballWidth, ballHeight);
            Rectangle leftBarRectangle = leftBar.GetBounds();
            Rectangle rightBarRectangle = rightBar.GetBounds();

            if (ballRectangle.Intersects(leftBarRectangle) || ballRectangle.Intersects(rightBarRectangle))
            {
                ballSpeedX = -ballSpeedX;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ballTexture, ballPosition, Color.White);
        }

        private void ResetBall(GraphicsDeviceManager graphics)
        {
            ballPosition = new Vector2((graphics.PreferredBackBufferWidth - ballTexture.Height) / 2, (graphics.PreferredBackBufferHeight - ballTexture.Height) / 2);
            ballSpeedX = 400;
            ballSpeedY = 400;
        }
    }
}

