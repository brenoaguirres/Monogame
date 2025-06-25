using TRexGame.Engine.Audio;


namespace TRexGame.GameEntities.TRex
{
    public class TRexAudioSource : AudioSource
    {
        #region CONSTRUCTOR
        public TRexAudioSource(TRexAudio audio) : base(audio) { }
        #endregion

        #region PUBLIC METHODS
        public void JumpSFX()
        {
            TRexAudio audio = (TRexAudio)Audio;
            PlayOneShot(audio.JumpSFX);
        }
        #endregion
    }
}
