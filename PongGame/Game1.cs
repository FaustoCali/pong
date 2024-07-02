using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ball ball;
        private Bar leftBar;
        private Bar rightBar;
        private Score score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D leftBarTexture = Content.Load<Texture2D>("PongBar");
            Texture2D rightBarTexture = Content.Load<Texture2D>("PongBar");
            Texture2D ballTexture = Content.Load<Texture2D>("PongBall");
            SpriteFont font = Content.Load<SpriteFont>("ScoreFont");

            leftBar = new Bar(leftBarTexture, new Vector2(20, (GraphicsDevice.Viewport.Height - leftBarTexture.Height) / 2), 500f);
            rightBar = new Bar(rightBarTexture, new Vector2(GraphicsDevice.Viewport.Width - 40, (GraphicsDevice.Viewport.Height - rightBarTexture.Height) / 2), 500f);
            ball = new Ball(ballTexture, new Vector2((GraphicsDevice.Viewport.Width - ballTexture.Height) / 2, (GraphicsDevice.Viewport.Height - ballTexture.Height) / 2));
            score = new Score(font, new Vector2(50, 50), new Vector2(GraphicsDevice.Viewport.Width - 200, 50));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            leftBar.Update(gameTime, _graphics, true, false);
            rightBar.Update(gameTime, _graphics, false, true);
            ball.Update(gameTime, _graphics, leftBar, rightBar, score);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            ball.Draw(_spriteBatch);
            leftBar.Draw(_spriteBatch);
            rightBar.Draw(_spriteBatch);
            score.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
