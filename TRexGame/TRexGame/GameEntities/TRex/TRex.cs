using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;
using TRexGame.Engine.Resources;
using TRexGame.GameEntities.TRex.Input;
using TRexGame.GameEntities.TRex.TRexStates;

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

    public class TRex : IGameEntity, IGameDrawable, IGamePhysicsBody
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
        public TRexAnimator Animator { get; private set; }

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
        #endregion

        #region IGameEntity INTERFACE
        public Guid Id { get; init; }
        public string Name { get; set; }
        public int DrawOrder { get; set; }
        public string Tag { get; set; }
        public Layer Layer { get; set; }
        public Vector2 Position { get; set; }
        public void Awake()
        {
            Animator = new(_gameResources.TexSpritesheet, this);
            Position = new(
                    TREX_START_POS_X,
                    _screenHeight - TREX_START_POS_Y - Sprite.RectTransform.Height
                );

            AudioSource = new(new TRexAudio(_gameResources));
            Input = new();

            Speed = 10;
            JumpForce = -60;
            IsAlive = true;
            StartingPosition = Position;

            StateMachine = new TRexStateMachine(this);
        }
        public void Update(GameTime gameTime)
        {
            Input.UpdateInputs(gameTime);
            StateMachine.UpdateStateMachine(gameTime);
            Animator.UpdateAnimator(gameTime);
            AudioSource.UpdateAudioSource(gameTime);
        }
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
