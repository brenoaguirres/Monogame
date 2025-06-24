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
        private bool _defaultIdle = true;
        private float _idleReset = 2f;
        private float _idleTimer = 0f;
        #endregion

        #region PRIVATE METHODS
        public void UpdateIdleState(GameTime gameTime, TRexGraphics graphics)
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
        #endregion

        #region PUBLIC METHODS
        public override void UpdateStates(GameTime gameTime)
        {
            TRexGraphics graphics = Graphics as TRexGraphics;

            UpdateIdleState(gameTime, graphics);
        }
        #endregion
    }
}
