using Microsoft.Xna.Framework.Audio;

namespace TRexGame.Engine.Audio
{
    public class GameAudio
    {
        #region CONSTRUCTOR
        public GameAudio(SoundEffect[] sfxCollection)
        {
            SfxCollection = sfxCollection;
        }
        #endregion

        #region PROPERTIES
        protected SoundEffect[] SfxCollection;
        #endregion
    }
}
