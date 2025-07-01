using Microsoft.Xna.Framework;

namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class DuckState : TRexState
    {
        #region CONSTRUCTOR
        public DuckState(ETRexState key, TRex context) : base(key, context) { }
        #endregion

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();
            _context.Animator.State = StateKey;
        }

        public override ETRexState CheckTransitions()
        {
            if (!_context.Input.CancelJumpInput)
                return ETRexState.RUN;

            return StateKey;
        }
        #endregion
    }
}
