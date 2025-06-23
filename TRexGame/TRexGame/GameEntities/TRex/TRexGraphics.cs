using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Animation;
using TRexGame.Engine.Graphics;

namespace TRexGame.GameEntities.TRex
{
    public class TRexGraphics
    {
        #region CONSTANTS
        // idle sprites
        private const int SPR_IDLE01_X = 848;
        private const int SPR_IDLE01_Y = 0;
        private const int SPR_IDLE01_W = 44;
        private const int SPR_IDLE01_H = 52;
        private const int SPR_IDLE02_X = 40;
        private const int SPR_IDLE02_Y = 0;
        private const int SPR_IDLE02_W = 44;
        private const int SPR_IDLE02_H = 52;
        #endregion

        #region CONSTRUCTOR
        public TRexGraphics(Texture2D texture)
        {
            // sprite init
            _idleSprites = new Sprite[]
            {
                new Sprite(texture, SPR_IDLE01_X, SPR_IDLE01_Y, SPR_IDLE01_W, SPR_IDLE01_H),
                new Sprite(texture, SPR_IDLE02_X, SPR_IDLE02_Y, SPR_IDLE02_W, SPR_IDLE02_H),
            };

            // anim init
            IdleAnimation = new AnimationClip(_idleSprites);
            IdleAnimation.LoopAnimation = true;
        }
        #endregion

        #region SPRITES
        public Sprite[] _idleSprites;
        #endregion

        #region ANIMATION CLIPS
        public AnimationClip IdleAnimation;
        #endregion
    }
}
