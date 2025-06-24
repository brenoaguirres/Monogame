namespace TRexGame.GameEntities.TRex.TRexStates
{
    public abstract class TRexState
    {
        public TRexState(ETRexState key)
        {
            StateKey = key;
        }

        public ETRexState StateKey { get; set; }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual ETRexState CheckTransitions() 
        {
            return StateKey;
        }
        public virtual void Exit() { }
    }
}
