using Microsoft.Xna.Framework;

namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class JumpState : TRexState
    {
        #region CONSTRUCTOR
        public JumpState(ETRexState key, TRex context) : base(key, context) { }
        #endregion

        #region PRIVATE METHODS
        private void ResetState()
        {
            _context.Rigidbody.CumulativeAcceleration = 0f;
        }
        #endregion

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();
            ResetState();

            _context.Animator.State = StateKey;

            _context.AudioSource.JumpSFX();

            _context.Rigidbody.LinearVelocity = new Vector2(_context.Rigidbody.LinearVelocity.X, _context.JumpForce);
        }

        public override ETRexState CheckTransitions()
        {
            if (_context.Rigidbody.LinearVelocity.Y >= 0 || _context.Input.CancelJumpInput)
                return ETRexState.FALL;

            return StateKey;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _context.Rigidbody.CumulativeAcceleration += _context.Rigidbody.Mass * _context.Rigidbody.GravityScale * deltaTime;

            _context.Rigidbody.LinearVelocity = new Vector2(
                _context.Rigidbody.LinearVelocity.X,
                _context.Rigidbody.LinearVelocity.Y + _context.Rigidbody.CumulativeAcceleration
            );

            float movement = _context.Rigidbody.LinearVelocity.Y * deltaTime;

            _context.RectTransform.Position = new Vector2(
                _context.RectTransform.Position.X,
                _context.RectTransform.Position.Y + movement
            );
        }
        #endregion
    }
}
