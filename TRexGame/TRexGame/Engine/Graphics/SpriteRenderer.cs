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
        private Sprite _sprite;
        private RectTransform _transform;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public Sprite Sprite 
        { 
            get 
            { 
                return _sprite; 
            } 
            set 
            { 
                _sprite = value;
                if (_transform != null)
                    _transform.Size = _sprite.Size;
            } 
        }
        #endregion

        #region PUBLIC METHODS
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, RectTransform transform)
        {
            spriteBatch.Draw(
                    _sprite.Texture,
                    transform.Position,
                    new Rectangle((int)_sprite.Position.X, (int)_sprite.Position.Y,
                    (int)_sprite.Size.X, (int)_sprite.Size.Y),
                    _sprite.TintColor
                    );
            /*
            foreach (var spr in Sprite)
                spriteBatch.Draw(
                    spr.Texture,
                    Position,
                    new Rectangle((int)spr.RectTransform.Position.X, (int)spr.RectTransform.Position.Y,
                    spr.RectTransform.Width, spr.RectTransform.Height),
                    spr.TintColor
                    );*/
        }
        #endregion

        #region IGameComponent INTERFACE
        public void InitializeComponent()
        {
            _transform = _myGameEntity.GetComponent<RectTransform>();
        }
        #endregion
    }
}
