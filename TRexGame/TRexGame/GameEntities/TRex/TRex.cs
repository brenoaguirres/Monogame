using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;
using TRexGame.Engine.Physics;
using TRexGame.Engine.Resources;
using TRexGame.GameEntities.TRex.Input;
using TRexGame.GameEntities.TRex.TRexStates;
using Entities = TRexGame.Engine.Entities;

namespace TRexGame.GameEntities.TRex
{
    #region ENUM
    public enum ETRexState
    {
        IDLE,
        RUN,
        JUMP,
        DUCK,
        FALL,
    }
    #endregion

    public class TRex : GameEntity
    {
        #region CONSTANTS
        private const int TREX_START_POS_X = 1;
        private const int TREX_START_POS_Y = 16;
        #endregion

        #region CONSTRUCTOR
        public TRex(
            GameResources gameResources,
            int SCR_WID, 
            int SCR_HEI,
            string name = "TRex",
            int draworder = 0,
            string tag = "",
            Layer layer = Layer.Player
            ) : base(name, draworder, tag, layer)
        {
            _gameResources = gameResources;
            _screenWidth = SCR_WID;
            _screenHeight = SCR_HEI;
        }
        #endregion

        #region FIELDS
        private GameResources _gameResources;
        private int _screenWidth;
        private int _screenHeight;
        #endregion

        #region PROPERTIES
        // State
        public TRexStateMachine StateMachine { get; private set; }

        // Components
        public Rigidbody Rigidbody { get; set; }
        public RectTransform RectTransform { get; set; }
        public SpriteRenderer SpriteRenderer { get; set; }
        public TRexAnimator Animator { get; private set; }
        public TRexAudioSource AudioSource { get; private set; }
        public TRexInput Input { get; private set; }

        // Game
        public float Speed { get; private set; }
        public float JumpForce { get; private set; }
        public bool IsAlive { get; private set; }
        public Vector2 StartingPosition { get; private set; }
        #endregion

        #region GAME ENTITY CALLBACKS
        public override void Awake()
        {
            Animator = new(this, _gameResources.TexSpritesheet);
            Rigidbody = new(this);
            SpriteRenderer = new(this);
            RectTransform = new(
                this, 
                new(
                    TREX_START_POS_X,
                    _screenHeight - TREX_START_POS_Y - TRexGraphics.SPR_BASE_H
                )
                );
            AudioSource = new(this, new TRexAudio(_gameResources));
            Input = new(this);

            InitializeComponents(
                new List<Entities.IGameComponent>
                {
                    Rigidbody,
                    RectTransform,
                    SpriteRenderer,
                    Animator,
                    AudioSource,
                    Input
                }
            );


            Speed = 10;
            JumpForce = -600;
            IsAlive = true;
            StartingPosition = RectTransform.Position;
            Rigidbody.Mass = 80f;

            StateMachine = new TRexStateMachine(this);

        }
        public override void Start() { }
        public override void Update(GameTime gameTime)
        {
            Rigidbody.UpdatePhysics(gameTime);
            Input.UpdateInputs(gameTime);
            StateMachine.UpdateStateMachine(gameTime);
            Animator.UpdateAnimator(gameTime);
            AudioSource.UpdateAudioSource(gameTime);
        }
        public override void OnRenderEntity(SpriteBatch spriteBatch, GameTime gameTime)
        {
            SpriteRenderer.Draw(spriteBatch, gameTime, RectTransform);
        }
        public override void OnDestroy() { }
        #endregion
    }
}
