using Box2D.NET;

namespace TRexGame.Plugins
{
    public class Box2DTest
    {
        #region FIELDS
        // Stores the world handle
        private B2WorldId _worldId;

        // Stores the ground body
        private B2BodyId _groundId;

        // Stores the ground polygon
        private B2Polygon _groundBox;
        #endregion

        #region PRIVATE METHODS
        private void CreateWorld()
        {
            B2WorldDef worldDef = B2Types.b2DefaultWorldDef();
            worldDef.gravity = new B2Vec2(0.0f, -10.0f);
            _worldId = B2Worlds.b2CreateWorld(ref worldDef);
        }

        private void CreateGroundBox()
        {
            // Define a body with position, damping, etc.
            // Use the world id to create the body.
            // Define shapes with friction, density, etc.
            // Create shapes on the body.

            B2BodyDef groundBodyDef = B2Types.b2DefaultBodyDef();
            groundBodyDef.position = new B2Vec2(0.0f, -10.0f);
            _groundId = B2Bodies.b2CreateBody(_worldId, ref groundBodyDef);

            _groundBox = B2Geometries.b2MakeBox(50.0f, 10.0f);
        }
        #endregion

        #region PUBLIC METHODS
        public void RunSimulation()
        {
            CreateWorld();
            CreateGroundBox();
        }
        #endregion
    }
}
