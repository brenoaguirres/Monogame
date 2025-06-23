using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;
using TRexGame.Engine.Resources;

namespace TRexGame.GameEntities
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

    public class TRex : IGameEntity
    {
        #region CONSTANTS
        private const int TREX_DEF_SPRITE_POS_X = 848;
        private const int TREX_DEF_SPRITE_POS_Y = 0;
        private const int TREX_DEF_SPRITE_WIDTH = 44;
        private const int TREX_DEF_SPRITE_HEIGHT = 52;
        private const int TREX_STARTING_X = 10;
        private const int TREX_STARTING_Y = 10;
        #endregion

        #region CONSTRUCTOR
        public TRex(GameResources gameResources)
        {
            Id = new Guid();
            Name = "TRex";
            DrawOrder = 0;
            Tag = "";
            Layer = Layer.Player;
            Sprite = new(
                gameResources.TexSpritesheet,
                TREX_STARTING_X, TREX_STARTING_Y,
                TREX_DEF_SPRITE_POS_X, TREX_DEF_SPRITE_POS_Y, 
                TREX_DEF_SPRITE_WIDTH, TREX_DEF_SPRITE_HEIGHT
                );
            State = TRexState.IDLE;

            Speed = 10;
            IsAlive = true;
        }
        #endregion

        #region PROPERTIES
        public Sprite Sprite { get; private set; }
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
        public Vector2 Position
        {
            get => Sprite.Position;
            set => Sprite.Position = value;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X + 1, Position.Y + 1);
        }
        #endregion
    }
}
