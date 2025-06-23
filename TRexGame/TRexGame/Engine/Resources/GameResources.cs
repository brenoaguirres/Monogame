using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TRexGame.Engine.Resources
{
    public class GameResources
    {
        #region FIELDS
        private SoundEffect _sfxHit;
        private SoundEffect _sfxBtnPress;
        private SoundEffect _sfxScore;

        private Texture2D _spriteSheetTexture;
        #endregion

        #region PROPERTIES
        public SoundEffect SfxHit => _sfxHit;
        public SoundEffect SfxBtnPress => _sfxBtnPress;
        public SoundEffect SfxScore => _sfxScore;

        public Texture2D TexSpritesheet => _spriteSheetTexture;
        #endregion

        #region PUBLIC METHODS
        public void LoadResourcePack(ContentManager Content)
        {
            _sfxHit = Content.Load<SoundEffect>(GameConstants.SFX_HIT);
            _sfxScore = Content.Load<SoundEffect>(GameConstants.SFX_SCORE);
            _sfxBtnPress = Content.Load<SoundEffect>(GameConstants.SFX_BTN_00);

            _spriteSheetTexture = Content.Load<Texture2D>(GameConstants.TEX_TREX_SPRITESHEET);
        }
        #endregion
    }
}
