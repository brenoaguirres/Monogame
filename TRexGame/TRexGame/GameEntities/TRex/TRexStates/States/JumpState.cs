namespace TRexGame.GameEntities.TRex.TRexStates.States
{
    public class JumpState : TRexState
    {
        public JumpState(ETRexState key, TRex context) : base(key, context) { }

        #region STATE PATTERN
        public override void Enter()
        {
            base.Enter();
            _context.Animator.State = StateKey;

            _context.AudioSource.JumpSFX();
        }

        public override ETRexState CheckTransitions()
        {
            if (!_context.AudioSource.IsPlaying)
                return ETRexState.IDLE;

            return StateKey;
        }
        #endregion
    }
}
