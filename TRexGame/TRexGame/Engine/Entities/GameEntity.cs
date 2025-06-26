using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TRexGame.Engine.Entities
{
    public abstract class GameEntity
    {
        #region FIELDS
        protected List<GameComponent> GameComponents { get; set; }
        #endregion

        #region PROPERTIES
        public Guid Id { get; init; }
        public string Name { get; set; }
        public int DrawOrder { get; set; }
        public string Tag { get; set; }
        public Layer Layer { get; set; }
        public Vector2 Position {  get; set; }
        #endregion

        #region GAMEENTITY METHODS
        public T GetComponent<T>() where T : GameComponent
        {
            return (T)GameComponents.Find(x => x is T);
        }
        public List<T> GetComponents<T>() where T : GameComponent
        {
            return GameComponents.OfType<T>().ToList();
        }
        #endregion

        #region PUBLIC METHODS
        public abstract void Awake();
        public abstract void Update(GameTime gameTime);
        #endregion
    }
}
