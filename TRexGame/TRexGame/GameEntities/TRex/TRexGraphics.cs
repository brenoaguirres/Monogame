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

        // begin jump sprites
        private const int SPR_BEGINJUMP01_X = 936;
        private const int SPR_BEGINJUMP01_Y = 0;

        // jump sprites
        private const int SPR_JUMP01_X = 892;
        private const int SPR_JUMP01_Y = 0;

        // fall sprites
        private const int SPR_FALL01_X = 980;
        private const int SPR_FALL01_Y = 0;

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
            _beginJumpSprites = new Sprite[]
            {
                new Sprite(texture, SPR_BEGINJUMP01_X, SPR_BEGINJUMP01_Y, SPR_BASE_W, SPR_BASE_H),
            };
            _jumpSprites = new Sprite[]
            {
                new Sprite(texture, SPR_JUMP01_X, SPR_JUMP01_Y, SPR_BASE_W, SPR_BASE_H),
            };
            _fallSprites = new Sprite[]
            {
                new Sprite(texture, SPR_FALL01_X, SPR_FALL01_Y, SPR_BASE_W, SPR_BASE_H),
            };

            // anim init
            IdleAnimation = new AnimationClip(_idleSprites);
            IdleAnimation.LoopAnimation = true;
            IdleAnimation.Name = "Idle";

            BlinkAnimation = new AnimationClip(_blinkSprites);
            BlinkAnimation.LoopAnimation = true;
            BlinkAnimation.Name = "Blink";

            BeginJumpAnimation = new AnimationClip(_jumpSprites);
            BeginJumpAnimation.LoopAnimation = false;
            BeginJumpAnimation.Name = "BeginJump";

            JumpAnimation = new AnimationClip(_jumpSprites);
            JumpAnimation.LoopAnimation = true;
            JumpAnimation.Name = "Jump";

            FallAnimation = new AnimationClip(_fallSprites);
            FallAnimation.LoopAnimation = false;
            FallAnimation.Name = "Fall";

            DefaultAnimation = IdleAnimation;
        }
        #endregion

        #region SPRITES
        public Sprite[] _idleSprites;
        public Sprite[] _blinkSprites;
        public Sprite[] _beginJumpSprites;
        public Sprite[] _jumpSprites;
        public Sprite[] _fallSprites;
        #endregion

        #region ANIMATION CLIPS
        public AnimationClip DefaultAnimation { get; set; }
        public AnimationClip IdleAnimation;
        public AnimationClip BlinkAnimation;
        public AnimationClip BeginJumpAnimation;
        public AnimationClip JumpAnimation;
        public AnimationClip FallAnimation;
        #endregion
    }
}
