using TRexGame.Engine.Entities;
using Microsoft.Xna.Framework;
using Entities = TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;

namespace TRexGame.Engine.Physics
{
    public class Rigidbody : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public Rigidbody(GameEntity gameEntity, float mass=1f)
        {
            _myGameEntity = gameEntity;
            _mass = mass;
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

        #region PRIVATE METHODS
        private void ApplyGravity(GameTime gameTime)
        {
            if (!_useGravity || _isKinematic) return;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _cumulativeAcceleration += _mass * _gravityScale * deltaTime;

            _linearVelocity = new Vector2(
                _linearVelocity.X,
                _linearVelocity.Y + _cumulativeAcceleration
            );
        }
        private void ApplyVelocity(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 movement = new Vector2(_linearVelocity.X * deltaTime, _linearVelocity.Y * deltaTime);

            _transform.Position = new Vector2(
                _transform.Position.X + movement.X,
                _transform.Position.Y + movement.Y
            );
        }
        #endregion

        #region PUBLIC METHODS
        public void InitializePhysics()
        {
            _transform = _myGameEntity.GetComponent<RectTransform>();
        }
        public void UpdatePhysics(GameTime gameTime)
        {
            ApplyGravity(gameTime);
            ApplyVelocity(gameTime);
        }
        #endregion

        #region IGameComponent INTERFACE
        public void InitializeComponent()
        {

        }
        #endregion
    }
}
