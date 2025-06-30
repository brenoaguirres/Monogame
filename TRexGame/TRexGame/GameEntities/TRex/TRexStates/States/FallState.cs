using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class FallState : TRexState
    {
        #region CONSTRUCTOR
        public FallState(ETRexState key, TRex context) : base(key, context) { }
        #endregion

        #region FIELDS
        bool _checkGround = false;
        #endregion

        #region PRIVATE METHODS
        private void ResetState()
        {
            _context.Rigidbody.CumulativeAcceleration = 0f;
            _checkGround = false;
        }
        #endregion

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();
            ResetState();

            _context.Animator.State = StateKey;
        }

        public override ETRexState CheckTransitions()
        {
            if (_checkGround)
            {
                return ETRexState.IDLE;
            }

            return StateKey;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float startPos = _context.StartingPosition.Y;

            _context.Rigidbody.CumulativeAcceleration += _context.Rigidbody.Mass * _context.Rigidbody.GravityScale * deltaTime;

            _context.Rigidbody.LinearVelocity = new Vector2(
                _context.Rigidbody.LinearVelocity.X,
                _context.Rigidbody.LinearVelocity.Y + _context.Rigidbody.CumulativeAcceleration
            );

            float movement = _context.Rigidbody.LinearVelocity.Y * deltaTime;

            _context.RectTransform.Position = new Vector2(
                _context.RectTransform.Position.X,
                MathF.Min(startPos, _context.RectTransform.Position.Y + movement)
            );

            if (_context.RectTransform.Position.Y >= startPos)
            {
                _checkGround = true;
            }
        }
        #endregion
    }
}
