using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Animation;
using TRexGame.Engine.Graphics;

namespace TRexGame.GameEntities.TRex
{
    public class TRexGraphics : IGameGraphics
    {
        #region CONSTANTS
        // base sprite width / height
        public const int SPR_BASE_W = 44;
        public const int SPR_BASE_H = 52;

        // idle sprites
        public const int SPR_IDLE01_X = 40;
        public const int SPR_IDLE01_Y = 1;

        // blink sprites
        public const int SPR_BLINK01_X = 848;
        public const int SPR_BLINK01_Y = 0;
        public const int SPR_BLINK02_X = 892;
        public const int SPR_BLINK02_Y = 0;

        // begin jump sprites
        public const int SPR_BEGINJUMP01_X = 936;
        public const int SPR_BEGINJUMP01_Y = 0;

        // jump sprites
        public const int SPR_JUMP01_X = 848;
        public const int SPR_JUMP01_Y = 0;

        // fall sprites
        public const int SPR_FALL01_X = 980;
        public const int SPR_FALL01_Y = 0;

        // run sprites
        public const int SPR_RUN01_X = 936;
        public const int SPR_RUN01_Y = 0;
        public const int SPR_RUN02_X = 980;
        public const int SPR_RUN02_Y = 0;

        // duck sprites
        public const int SPR_DUCK_W = 59;
        public const int SPR_DUCK_H = 52; //30
        public const int SPR_DUCK01_X = 1112;
        public const int SPR_DUCK01_Y = 0; //19
        public const int SPR_DUCK02_X = 1171;
        public const int SPR_DUCK02_Y = 0; //19
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
            _runSprites = new Sprite[]
            {
                new Sprite(texture, SPR_RUN01_X, SPR_RUN01_Y, SPR_BASE_W, SPR_BASE_H),
                new Sprite(texture, SPR_RUN02_X, SPR_RUN02_Y, SPR_BASE_W, SPR_BASE_H),
            };
            _duckSprites = new Sprite[]
            {
                new Sprite(texture, SPR_DUCK01_X, SPR_DUCK01_Y, SPR_DUCK_W, SPR_DUCK_H),
                new Sprite(texture, SPR_DUCK02_X, SPR_DUCK02_Y, SPR_DUCK_W, SPR_DUCK_H),
            };

            // anim init
            IdleAnimation = new AnimationClip("Idle", true, 1, _idleSprites);
            BlinkAnimation = new AnimationClip("Blink", true, 1, _blinkSprites);
            BeginJumpAnimation = new AnimationClip("BeginJump", false, 1, _beginJumpSprites);
            JumpAnimation = new AnimationClip("Jump", true, 1, _jumpSprites);
            FallAnimation = new AnimationClip("Fall", false, 1, _fallSprites);
            RunAnimation = new AnimationClip("Run", true, 10f, _runSprites);
            DuckAnimation = new AnimationClip("Duck", true, 10f, _duckSprites);

            DefaultAnimation = IdleAnimation;
        }
        #endregion

        #region SPRITES
        public Sprite[] _idleSprites;
        public Sprite[] _blinkSprites;
        public Sprite[] _beginJumpSprites;
        public Sprite[] _jumpSprites;
        public Sprite[] _fallSprites;
        public Sprite[] _runSprites;
        public Sprite[] _duckSprites;
        #endregion

        #region ANIMATION CLIPS
        public AnimationClip DefaultAnimation { get; set; }
        public AnimationClip IdleAnimation;
        public AnimationClip BlinkAnimation;
        public AnimationClip BeginJumpAnimation;
        public AnimationClip JumpAnimation;
        public AnimationClip FallAnimation;
        public AnimationClip RunAnimation;
        public AnimationClip DuckAnimation;
        #endregion
    }
}
