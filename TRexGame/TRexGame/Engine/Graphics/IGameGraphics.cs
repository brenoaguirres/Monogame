using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Animation;

namespace TRexGame.Engine.Graphics
{
    public interface IGameGraphics
    {
        #region PROPERTIES
        public AnimationClip DefaultAnimation { get; set; }
        #endregion
    }
}
