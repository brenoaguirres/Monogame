using TRexGame.Engine.Entities;
using Microsoft.Xna.Framework;
using Entities = TRexGame.Engine.Entities;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TRexGame.Engine.Graphics
{
    public class SpriteRenderer : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public SpriteRenderer(GameEntity gameEntity)
        {
            _myGameEntity = gameEntity;
        }
        #endregion

        #region FIELDS
        private GameEntity _myGameEntity;
        private List<Sprite> _sprite;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public List<Sprite> Sprite { get { return _sprite; } set { _sprite = value; } } 
        #endregion

        #region PUBLIC METHODS
        public void Draw(SpriteBatch spriteBatch, Vector2 Position)
        {
            foreach (var spr in Sprite)
                spriteBatch.Draw(
                    spr.Texture,
                    Position,
                    new Rectangle((int)spr.RectTransform.Position.X, (int)spr.RectTransform.Position.Y,
                    spr.RectTransform.Width, spr.RectTransform.Height),
                    spr.TintColor
                    );
        }
        #endregion
    }
}
