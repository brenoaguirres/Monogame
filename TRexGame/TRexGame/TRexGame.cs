using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TRexGame.Resources;

namespace TRexGame
{
    public class TRexGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        #region ASSETS
        private SoundEffect _sfxHit;
        private SoundEffect _sfxBtnPress;
        private SoundEffect _sfxScore;

        private Texture2D _spriteSheetTexture;
        #endregion

        public TRexGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _sfxHit = Content.Load<SoundEffect>(GameConstants.SFX_HIT);
            _sfxScore = Content.Load<SoundEffect>(GameConstants.SFX_SCORE);
            _sfxBtnPress = Content.Load<SoundEffect>(GameConstants.SFX_BTN_00);

            _spriteSheetTexture = Content.Load<Texture2D>(GameConstants.TEX_TREX_SPRITESHEET);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_spriteSheetTexture, new Vector2(10, 10), new Rectangle(848, 0, 44, 52), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
