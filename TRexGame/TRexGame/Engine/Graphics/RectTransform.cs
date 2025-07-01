using Microsoft.Xna.Framework;
using TRexGame.Engine.Entities;

namespace TRexGame.Engine.Graphics
{
    public class RectTransform : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public RectTransform(Vector2 position)
        {
            Position = position;
        }
        #endregion

        #region FIELDS
        private GameEntity _myGameEntity;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        #endregion

        #region IGameComponent INTERFACE
        public void InitializeComponent()
        {

        }
        #endregion
    }
}
