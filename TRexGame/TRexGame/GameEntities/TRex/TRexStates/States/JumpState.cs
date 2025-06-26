using Microsoft.Xna.Framework;

namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class JumpState : TRexState
    {
        #region CONSTRUCTOR
        public JumpState(ETRexState key, TRex context) : base(key, context) { }
        #endregion

        #region FIELDS
        float _mass = 80f;
        float _gravity = 9.8f;
        float _acceleration = 0f;
        #endregion

        #region PRIVATE METHODS
        private void ResetState()
        {
            _acceleration = 0f;
        }
        #endregion

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();
            ResetState();

            _context.Animator.State = StateKey;

            _context.AudioSource.JumpSFX();

            _context.Velocity = new Vector2(_context.Velocity.X, _context.JumpForce);
        }

        public override ETRexState CheckTransitions()
        {
            if (_context.Velocity.Y >= 0 || _context.Input.CancelJumpInput)
                return ETRexState.FALL;

            return StateKey;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _acceleration += _mass * _gravity * deltaTime;

            _context.Velocity = new Vector2(
                _context.Velocity.X,
                _context.Velocity.Y + _acceleration
            );

            float movement = _context.Velocity.Y * deltaTime;

            _context.Position = new Vector2(
                _context.Position.X,
                _context.Position.Y + movement
            );
        }
        #endregion
    }
}
