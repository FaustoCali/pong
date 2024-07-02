using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Score
    {
        private int player1Score;
        private int player2Score;
        private SpriteFont font;
        private Vector2 player1Position;
        private Vector2 player2Position;

        public Score(SpriteFont font, Vector2 player1Position, Vector2 player2Position)
        {
            this.player1Score = 0;
            this.player2Score = 0;
            this.font = font;
            this.player1Position = player1Position;
            this.player2Position = player2Position;
        }

        public void IncrementPlayer1Score()
        {
            player1Score++;
        }

        public void IncrementPlayer2Score()
        {
            player2Score++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, $"Player 1: {player1Score}", player1Position, Color.White);
        }
    }
}