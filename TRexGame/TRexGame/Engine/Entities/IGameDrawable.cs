using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Graphics;

namespace TRexGame.Engine.Entities
{
    public interface IGameDrawable
    {
        #region PROPERTIES
        public Sprite Sprite { get; set; }
        #endregion

        #region PUBLIC METHODS
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        #endregion
    }
}
