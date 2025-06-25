using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TRexGame.GameEntities.TRex.Input
{
    public class TRexInput
    {
        #region FIELDS
        private KeyboardState _previousKBState;
        #endregion

        #region PROPERTIES
        public bool JumpInput { get; private set; }
        #endregion

        #region PUBLIC METHODS
        public void UpdateInputs(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(!_previousKBState.IsKeyDown(Keys.Up) && keyboardState.IsKeyDown(Keys.Up))
            {
                JumpInput = true;
            }
            else
            {
                JumpInput = false;
            }

            _previousKBState = keyboardState;
        }
        #endregion
    }
}
