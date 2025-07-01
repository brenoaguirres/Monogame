using Microsoft.Xna.Framework;

namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class JumpState : TRexState
    {

        #region CONSTRUCTOR
        public JumpState(ETRexState key, TRex context) : base(key, context) { }
        #endregion

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();

            _context.Animator.State = StateKey;

            _context.AudioSource.JumpSFX();

            _context.Rigidbody.LinearVelocity = new Vector2(_context.Rigidbody.LinearVelocity.X, _context.JumpForce);
        }

        public override ETRexState CheckTransitions()
        {
            if (_context.Input.CancelJumpInput)
            {
                _context.Rigidbody.LinearVelocity = new Vector2(_context.Rigidbody.LinearVelocity.X, _context.JumpForce * -1);
                return ETRexState.FALL;
            }
            if (_context.Rigidbody.LinearVelocity.Y >= 0)
            {
                _context.Rigidbody.LinearVelocity = new Vector2(_context.Rigidbody.LinearVelocity.X, 0);
                return ETRexState.FALL;
            }

            return StateKey;
        }
        #endregion
    }
}
