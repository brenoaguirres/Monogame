using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;
using TRexGame.Engine.Resources;

namespace TRexGame.GameEntities.TRex
{
    #region ENUM
    public enum TRexState
    {
        IDLE,
        RUN,
        JUMP,
        DUCK,
        FALL,
    }
    #endregion

    public class TRex : IGameEntity, IGameDrawable
    {
        #region CONSTANTS
        private const int TREX_START_POS_X = 1;
        private const int TREX_START_POS_Y = 16;
        #endregion

        #region CONSTRUCTOR
        public TRex(GameResources gameResources, int SCR_WID, int SCR_HEI)
        {
            Id = new Guid();
            Name = "TRex";
            DrawOrder = 0;
            Tag = "";
            Layer = Layer.Player;
            Position = new(0, 0);

            _gameResources = gameResources;
            _screenWidth = SCR_WID;
            _screenHeight = SCR_HEI;

            Awake();
        }
        #endregion

        #region FIELDS
        private GameResources _gameResources;
        private int _screenWidth;
        private int _screenHeight;
        #endregion

        #region PROPERTIES
        public Sprite Sprite { get; set; }
        public TRexAnimator Animator { get; private set; }
        public TRexState State { get; private set; }

        public float Speed { get; private set; }
        public bool IsAlive { get; private set; }
        #endregion

        #region IGameEntity INTERFACE
        public Guid Id { get; init; }
        public string Name { get; set; }
        public int DrawOrder { get; set; }
        public string Tag { get; set; }
        public Layer Layer { get; set; }
        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            Animator.Update(gameTime);
        }

        public void Awake()
        {
            Animator = new(_gameResources.TexSpritesheet, this);
            State = TRexState.IDLE;
            Position = new(
                    TREX_START_POS_X,
                    _screenHeight - TREX_START_POS_Y - Animator.CurrentAnimation.CurrentFrameSprite.RectTransform.Height
                );

            Speed = 10;
            IsAlive = true;
        }
        #endregion
    }
}
