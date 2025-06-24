using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Animation;
using TRexGame.Engine.Graphics;

namespace TRexGame.GameEntities.TRex
{
    public class TRexGraphics : IGameGraphics
    {
        #region CONSTANTS
        // base sprite width / height
        private const int SPR_BASE_W = 44;
        private const int SPR_BASE_H = 52;

        // idle sprites
        private const int SPR_IDLE01_X = 40;
        private const int SPR_IDLE01_Y = 1;

        // blink sprites
        private const int SPR_BLINK01_X = 848;
        private const int SPR_BLINK01_Y = 0;
        private const int SPR_BLINK02_X = 892;
        private const int SPR_BLINK02_Y = 0;
        #endregion

        #region CONSTRUCTOR
        public TRexGraphics(Texture2D texture)
        {
            // sprite init
            _idleSprites = new Sprite[]
            {
                new Sprite(texture, SPR_IDLE01_X, SPR_IDLE01_Y, SPR_BASE_W, SPR_BASE_H),
            };
            _blinkSprites = new Sprite[]
            {
                new Sprite(texture, SPR_BLINK01_X, SPR_BLINK01_Y, SPR_BASE_W, SPR_BASE_H),
                new Sprite(texture, SPR_BLINK02_X, SPR_BLINK02_Y, SPR_BASE_W, SPR_BASE_H),
            };

            // anim init
            IdleAnimation = new AnimationClip(_idleSprites);
            IdleAnimation.LoopAnimation = true;
            BlinkAnimation = new AnimationClip(_blinkSprites);
            BlinkAnimation.LoopAnimation = true;

            DefaultAnimation = IdleAnimation;
        }
        #endregion

        #region SPRITES
        public Sprite[] _idleSprites;
        public Sprite[] _blinkSprites;
        #endregion

        #region ANIMATION CLIPS
        public AnimationClip DefaultAnimation { get; set; }
        public AnimationClip IdleAnimation;
        public AnimationClip BlinkAnimation;
        #endregion
    }
}
