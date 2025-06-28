using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = TRexGame.Engine.Entities;

namespace TRexGame.Engine.Entities
{
    public abstract class GameEntity
    {
        #region CONSTRUCTOR
        public GameEntity(
            string name = "", 
            int draworder = 0, 
            string tag = "", 
            Layer layer = Layer.Default
            )
        {
            Id = new Guid();
            Name = name;
            DrawOrder = draworder;
            Tag = tag;
            Layer = layer;
            Position = new(0, 0);

            EntityManager.Instance.Instantiate(this);
        }
        #endregion

        #region FIELDS
        protected List<Entities.IGameComponent> GameComponents { get; set; }
        #endregion

        #region PROPERTIES
        public Guid Id { get; init; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DrawOrder { get; set; }
        public string Tag { get; set; }
        public Layer Layer { get; set; }
        public Vector2 Position {  get; set; }
        #endregion

        #region GAMEENTITY METHODS
        public T GetComponent<T>() where T : Entities.IGameComponent
        {
            return (T)GameComponents.Find(x => x is T);
        }
        public List<T> GetComponents<T>() where T : Entities.IGameComponent
        {
            return GameComponents.OfType<T>().ToList();
        }
        #endregion

        #region PUBLIC METHODS
        public virtual void InitializeComponents(List<Entities.IGameComponent> components)
        {
            GameComponents = components;
        }

        public abstract void Awake();
        public abstract void Start();
        public abstract void Update(GameTime gameTime);
        public abstract void OnRenderEntity(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void OnDestroy();
        #endregion
    }
}
