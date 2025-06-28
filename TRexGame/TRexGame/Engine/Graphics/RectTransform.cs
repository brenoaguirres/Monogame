using TRexGame.Engine.Entities;

namespace TRexGame.Engine.Graphics
{
    public class RectTransform : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public RectTransform(GameEntity gameEntity, int x, int y, int width, int height)
        {
            _myGameEntity = gameEntity;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        #endregion

        #region FIELDS
        private GameEntity _myGameEntity;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
    }
}
