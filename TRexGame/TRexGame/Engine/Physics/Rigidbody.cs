using TRexGame.Engine.Entities;
using Microsoft.Xna.Framework;
using Entities = TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;

namespace TRexGame.Engine.Physics
{
    public class Rigidbody : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public Rigidbody(GameEntity gameEntity)
        {
            _myGameEntity = gameEntity;
        }
        #endregion

        #region FIELDS
        private GameEntity _myGameEntity;
        private float _mass = 1f;
        private float _gravityScale = 9.8f;
        private float _cumulativeAcceleration = 0f;
        private Vector2 _linearVelocity = new Vector2(0, 0);
        private bool _isKinematic = false;
        private bool _useGravity = true;
        private RectTransform _transform;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public float Mass { get { return _mass; } set { _mass = value; } }
        public float GravityScale { get { return _gravityScale; } set { _gravityScale = value; } }
        public float CumulativeAcceleration { get { return _cumulativeAcceleration; } set { _cumulativeAcceleration = value; } }
        public Vector2 LinearVelocity { get { return _linearVelocity; } set { _linearVelocity = value; } }
        public bool IsKinematic { get { return _isKinematic; } set { _isKinematic = value; } }
        public bool UseGravity { get { return _useGravity; } set { _useGravity = value; } }
        #endregion

        #region PUBLIC METHODS
        public void ApplyGravity()
        {

        }
        public void ApplyVelocity()
        {

        }
        public void InitializePhysics()
        {
            _transform = _myGameEntity.GetComponent<RectTransform>();
        }
        public void UpdatePhysics()
        {

        }
        #endregion
    }
}
