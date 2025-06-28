using Microsoft.Xna.Framework;
using TRexGame.Engine.Entities;

namespace TRexGame.Engine.Graphics
{
    public class RectTransform : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public RectTransform(GameEntity gameEntity, Vector2 position, int width, int height)
        {
            _myGameEntity = gameEntity;
            Position = position;
            Width = width;
            Height = height;
        }
        #endregion

        #region FIELDS
        private GameEntity _myGameEntity;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
    }
}
