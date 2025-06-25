using Microsoft.Xna.Framework.Audio;
using TRexGame.Engine.Audio;
using TRexGame.Engine.Resources;

namespace TRexGame.GameEntities.TRex
{
    public class TRexAudio : GameAudio
    {
        #region CONSTRUCTOR
        public TRexAudio(GameResources gameResources) : base
            (
                [
                    gameResources.SfxBtnPress,
                ]
            )
        { }
        #endregion

        #region PROPERTIES
        public SoundEffect JumpSFX => SfxCollection[0];
        #endregion
    }
}
