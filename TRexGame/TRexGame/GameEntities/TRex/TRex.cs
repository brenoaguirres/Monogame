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

    public class TRex : GameEntity, IGameDrawable, IGamePhysicsBody
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
            Position = new(0, 0);
            Velocity = new(0, 0);

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
        // GFX
        public Sprite Sprite { get; set; }

        // State
        public TRexStateMachine StateMachine { get; private set; }

        // Audio
        public TRexAudioSource AudioSource { get; private set; }

        // Input
        public TRexInput Input { get; private set; }

        // Game
        public float Speed { get; private set; }
        public float JumpForce { get; private set; }
        public bool IsAlive { get; private set; }
        public Vector2 StartingPosition { get; private set; }

        // Components
        public Rigidbody Rigidbody { get; set; }
        public RectTransform RectTransform { get; set; }
        public SpriteRenderer SpriteRenderer { get; set; }
        public TRexAnimator Animator { get; private set; }
        #endregion

        #region GAME ENTITY CALLBACKS
        public override void Awake()
        {
            Animator = new(this, _gameResources.TexSpritesheet, this);
            Rigidbody = new(this);
            RectTransform = new(
                this, 
                new(
                    TREX_START_POS_X,
                    _screenHeight - TREX_START_POS_Y - Sprite.RectTransform.Height
                ), 
                _screenWidth, _screenHeight);
            SpriteRenderer = new(this);

            InitializeComponents(
                new List<Entities.IGameComponent>
                {
                    Rigidbody,
                    RectTransform,
                    SpriteRenderer,
                    Animator,
                }
            );

            Position = new(
                    TREX_START_POS_X,
                    _screenHeight - TREX_START_POS_Y - Sprite.RectTransform.Height
                );

            AudioSource = new(new TRexAudio(_gameResources));
            Input = new();

            Speed = 10;
            JumpForce = -600;
            IsAlive = true;
            StartingPosition = Position;

            StateMachine = new TRexStateMachine(this);

        }
        public override void Start() { }
        public override void Update(GameTime gameTime)
        {
            Input.UpdateInputs(gameTime);
            StateMachine.UpdateStateMachine(gameTime);
            Animator.UpdateAnimator(gameTime);
            AudioSource.UpdateAudioSource(gameTime);
        }
        public override void OnRenderEntity(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Draw(spriteBatch, gameTime);
        }
        public override void OnDestroy() { }
        #endregion

        #region IGameDrawable INTERFACE
        // Implement Sprite[] rendering, if sprite.Length == 1 call normal sprite.draw, else call sprite.draw(Sprite[])
        // Implement Animator logic for stacking sprites
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        #region IPhysicsBody INTERFACE
        public Vector2 Velocity { get; set; }
        #endregion
        #endregion
    }
}
