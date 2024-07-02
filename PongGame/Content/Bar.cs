using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Bar
    {
        public Texture2D barTexture;
        public Vector2 barPosition;
        public float barSpeed;
        public int barWidth;
        public int barHeight;

        public Bar(Texture2D barTexture, Vector2 initialPosition, float initialSpeed)
        {
            this.barTexture = barTexture;
            this.barPosition = initialPosition;
            this.barSpeed = initialSpeed;
            barWidth = barTexture.Width;
            barHeight = barTexture.Height;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, bool isPlayer1, bool isPlayer2)
        {
            var kstate = Keyboard.GetState();

            if (isPlayer1)
            {
                if (kstate.IsKeyDown(Keys.W))
                {
                    barPosition.Y -= barSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.S))
                {
                    barPosition.Y += barSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (isPlayer2)
            {
                if (kstate.IsKeyDown(Keys.Up))
                {
                    barPosition.Y -= barSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    barPosition.Y += barSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (barPosition.Y > graphics.PreferredBackBufferHeight - barTexture.Height)
            {
                barPosition.Y = graphics.PreferredBackBufferHeight - barTexture.Height;
            }
            else if (barPosition.Y < 0)
            {
                barPosition.Y = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barTexture, barPosition, Color.White);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)barPosition.X, (int)barPosition.Y, barWidth, barHeight);
        }
    }
}
