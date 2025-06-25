using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Animation;
using TRexGame.Engine.Graphics;
using TRexGame.Engine.Entities;
using System;
using System.Drawing;

namespace TRexGame.GameEntities.TRex
{
    public class TRexAnimator : Animator
    {
        #region CONSTRUCTOR
        public TRexAnimator(Texture2D texture, IGameDrawable drawable) : base (new TRexGraphics(texture), drawable)
        {
        }
        #endregion

        #region FIELDS
        private ETRexState _state;

        // idle
        private bool _defaultIdle = true;
        private float _idleReset = 2f;
        private float _idleTimer = 0f;

        // jump
        private bool _jumpStart = false;

        #endregion

        #region PROPERTIES
        public ETRexState State { get => _state; set => _state = value; }
        #endregion

        #region PRIVATE METHODS
        public void AnimateIdleState(GameTime gameTime, TRexGraphics graphics)
        {
            if (_idleTimer <= 0)
            {
                if (!_defaultIdle)
                {
                    Play(graphics.IdleAnimation);
                    _defaultIdle = true;
                }
                else
                {
                    Play(graphics.BlinkAnimation);
                    _defaultIdle = false;
                }

                _idleTimer = _idleReset;
            }
            else
            {
                _idleTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        public void AnimateRunState(GameTime gameTime, TRexGraphics graphics)
        {
            throw new NotImplementedException();
        }
        public void AnimateJumpState(GameTime gameTime, TRexGraphics graphics)
        {
            if (!_jumpStart)
            {
                BeginJumpAnimation(gameTime, graphics);
                return;
            }
            ContinueJumpAnimation(gameTime, graphics);
        }
        public void AnimateDuckState(GameTime gameTime, TRexGraphics graphics)
        {
            throw new NotImplementedException();
        }
        public void AnimateFallState(GameTime gameTime, TRexGraphics graphics)
        {
            Play(graphics.FallAnimation);
            _jumpStart = false;
        }
        #endregion

        #region ANIMATION HELPERS
        public void BeginJumpAnimation(GameTime gameTime, TRexGraphics graphics)
        {
            _jumpStart = true;
            Play(graphics.BeginJumpAnimation);
        }

        public void ContinueJumpAnimation(GameTime gameTime, TRexGraphics graphics)
        {
            if (isPlaying && CurrentAnimation != graphics.JumpAnimation) return;
            Play(graphics.JumpAnimation);
        }
        #endregion

        #region PUBLIC METHODS
        public override void UpdateStates(GameTime gameTime)
        {
            TRexGraphics graphics = Graphics as TRexGraphics;

            switch (State)
            {
                default:
                case ETRexState.IDLE:
                    AnimateIdleState(gameTime, graphics);
                    break;
                case ETRexState.RUN:
                    AnimateRunState(gameTime, graphics);
                    break;
                case ETRexState.JUMP:
                    AnimateJumpState(gameTime, graphics);
                    break;
                case ETRexState.DUCK:
                    AnimateDuckState(gameTime, graphics);
                    break;
                case ETRexState.FALL:
                    AnimateFallState(gameTime, graphics);
                    break;
            }
        }
        #endregion
    }
}
