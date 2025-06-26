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
        float _mass = 80f;
        float _gravity = 9.8f;
        float _acceleration = 0f;

        bool _checkGround = false;
        #endregion

        #region PRIVATE METHODS
        private void ResetState()
        {
            _acceleration = 0f;
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

            _acceleration += _mass * _gravity * deltaTime;

            _context.Velocity = new Vector2(
                _context.Velocity.X,
                _context.Velocity.Y + _acceleration
            );

            float movement = _context.Velocity.Y * deltaTime;

            _context.Position = new Vector2(
                _context.Position.X,
                MathF.Min(startPos, _context.Position.Y + movement)
            );

            if (_context.Position.Y >= startPos)
            {
                _checkGround = true;
            }
        }
        #endregion
    }
}
