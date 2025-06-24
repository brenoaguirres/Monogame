using System;
using System.Collections.Generic;
using System.Diagnostics;
using TRexGame.GameEntities.TRex.TRexStates.States;

namespace TRexGame.GameEntities.TRex.TRexStates
{
    public class TRexStateMachine
    {
        #region CONSTRUCTOR
        public TRexStateMachine()
        {
            GenerateStates();
            SwitchStates(ETRexState.IDLE);
        }
        #endregion

        #region FIELDS
        private Dictionary<ETRexState, TRexState> _states = new();
        #endregion

        #region PROPERTIES
        public TRexState CurrentState { get; private set; }
        #endregion

        #region PRIVATE METHODS
        private void GenerateStates()
        {
            _states.Add(ETRexState.IDLE, new IdleState(ETRexState.IDLE));
            _states.Add(ETRexState.RUN, new RunState(ETRexState.RUN));
            _states.Add(ETRexState.JUMP, new JumpState(ETRexState.JUMP));
            _states.Add(ETRexState.DUCK, new DuckState(ETRexState.DUCK));
            _states.Add(ETRexState.FALL, new FallState(ETRexState.FALL));
        }
        #endregion

        #region PUBLIC METHODS
        public void SwitchStates(ETRexState state)
        {
            if (CurrentState != null)
                CurrentState.Exit();
            CurrentState = _states[state];
            CurrentState.Enter();

        }
        public void UpdateStateMachine()
        {
            ETRexState state = CurrentState.CheckTransitions();
            if (state != CurrentState.StateKey)
            {
                SwitchStates(state);
                return;
            }
            
            CurrentState.Update();
        }
        #endregion
    }
}
