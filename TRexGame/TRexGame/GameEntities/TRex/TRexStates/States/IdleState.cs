namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class IdleState : TRexState
    {
        #region CONSTRUCTOR
        public IdleState(ETRexState key, TRex context) : base(key, context) { }
        #endregion

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();
            _context.Animator.State = StateKey;
        }

        public override ETRexState CheckTransitions()
        {
            if (_context.Input.JumpInput)
                return ETRexState.JUMP;

            return StateKey;
        }
        #endregion
    }
}
