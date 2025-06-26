using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TRexGame.Engine.Entities
{
    public class EntityManager
    {
        #region SINGLETON PATTERN
        public static EntityManager _instance;
        public static EntityManager Instance 
        { 
            get
            {
                if (_instance == null)
                    _instance = new EntityManager();

                return _instance;
            }
        }
        #endregion

        #region FIELDS
        private List<GameEntity> _gameEntities = new List<GameEntity>();
        private List<GameEntity> _cleanupEntities = new List<GameEntity>();
        #endregion

        #region PROPERTIES
        public List<GameEntity> Entities { get { return _gameEntities; } }
        #endregion

        #region EVENTS
        private Action OnAwake;
        private Action OnStart;
        private Action<GameTime> OnUpdate;
        #endregion

        #region PUBLIC METHODS
        public void Instantiate(GameEntity entity)
        {
            if (entity == null ||
                _instance._gameEntities.Contains(entity) ||
                _instance._cleanupEntities.Contains(entity)
                )
                return;

            _instance._gameEntities.Add(entity);
            _instance.OnAwake += entity.Awake;
            _instance.OnStart += entity.Start;
            _instance.OnUpdate += entity.Update;
        }

        public void Destroy(GameEntity entity)
        {
            if (entity == null ||
                !_instance._gameEntities.Contains(entity) ||
                _instance._cleanupEntities.Contains(entity)
                )
                return;

            entity.OnDestroy();

            _instance._cleanupEntities.Add(entity);
            _instance.OnAwake -= entity.Awake;
            _instance.OnStart -= entity.Start;
            _instance.OnUpdate -= entity.Update;
        }
        public void AwakeStage()
        {
            OnAwake?.Invoke();
        }
        public void StartStage()
        {
            OnStart?.Invoke();
        }
        public void UpdateStage(GameTime gameTime)
        {
            OnUpdate?.Invoke(gameTime);
        }
        public void CleanupStage()
        {
            for (int i = 0; i < _cleanupEntities.Count; i++)
            {
                if (_gameEntities.Contains(_cleanupEntities[i]))
                {
                    _gameEntities.Remove(_cleanupEntities[i]);
                    _cleanupEntities[i] = null;
                }
            }

            _cleanupEntities.Clear();
        }
        #endregion
    }
}