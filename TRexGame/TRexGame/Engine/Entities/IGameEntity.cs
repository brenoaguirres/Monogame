using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TRexGame.Engine.Entities
{
    public interface IGameEntity
    {
        #region PROPERTIES
        public Guid Id { get; init; }
        public string Name { get; set; }
        public int DrawOrder { get; set; }
        public string Tag { get; set; }
        public Layer Layer { get; set; }
        public Vector2 Position {  get; set; }
        #endregion

        #region PUBLIC METHODS
        void Update(GameTime gameTime);
        #endregion
    }
}
