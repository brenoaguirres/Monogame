using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;
using TRexGame.GameEntities.TRex;
using Entities = TRexGame.Engine.Entities;

namespace TRexGame.Engine.Animation
{
    public abstract class Animator : Entities.IGameComponent
    {
        #region CONSTRUCTOR
        public Animator(GameEntity gameEntity, IGameGraphics graphics, IGameDrawable drawable)
        {
            _myGameEntity = gameEntity;
            Graphics = graphics;
            CurrentAnimation = Graphics.DefaultAnimation;
            GameDrawable = drawable;

            InitializeAnimator();
        }
        #endregion

        #region FIELDS
        private GameEntity _myGameEntity;
        #endregion

        #region PROPERTIES
        public GameEntity MyGameEntity { get { return _myGameEntity; } set { _myGameEntity = value; } }
        public IGameGraphics Graphics { get; protected set; }
        public AnimationClip DefaultAnimation => Graphics.DefaultAnimation;
        public AnimationClip CurrentAnimation { get; protected set; }
        public IGameDrawable GameDrawable { get; protected set; }

        public bool IsPlaying = false;
        public float PlaybackTime { get; protected set; }
        #endregion

        #region EVENTS
        public Action<AnimationClip> OnAnimationEnter;
        public Action<AnimationClip> OnAnimationExit;
        #endregion

        #region PRIVATE METHODS
        protected void InitializeAnimator()
        {
            Play(DefaultAnimation);
        }
        #endregion

        #region PUBLIC METHODS
        public virtual void UpdateStates(GameTime gameTime)
        {

        }
        public void UpdateAnimator(GameTime gameTime)
        {
            UpdateStates(gameTime);
            ValidateDefaultAnimation();

            if (IsPlaying)
            {
                if (PlaybackTime >= CurrentAnimation.ClipDuration)
                {
                    if (!CurrentAnimation.LoopAnimation)
                        Stop();
                    else
                    {
                        GameDrawable.Sprite = CurrentAnimation.NextSprite();
                        Play(CurrentAnimation);
                    }
                }

                if (PlaybackTime >= CurrentAnimation.CurrentFrameTimestamp + CurrentAnimation.TotalFrameTime)
                    GameDrawable.Sprite = CurrentAnimation.NextSprite();

                PlaybackTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Play(AnimationClip animationClip)
        {
            if (animationClip == null)
                throw new ArgumentNullException(nameof(animationClip));

            if (CurrentAnimation != null && CurrentAnimation != animationClip)
                Stop();

            CurrentAnimation = animationClip;
            PlaybackTime = 0;
            CurrentAnimation.ResetClip();
            IsPlaying = true;
            OnAnimationEnter?.Invoke(CurrentAnimation);
            GameDrawable.Sprite = CurrentAnimation.CurrentFrameSprite;
        }

        public void Pause()
        {
            IsPlaying = false;
        }

        public void Default()
        {
            Stop();
            Play(DefaultAnimation);
        }

        public void Stop()
        {
            if (CurrentAnimation == null) return;

            IsPlaying = false;
            PlaybackTime = 0;
            CurrentAnimation.ResetClip();
            OnAnimationExit?.Invoke(CurrentAnimation);
        }

        public void ValidateDefaultAnimation()
        {
            if (CurrentAnimation == null)
            {
                Play(DefaultAnimation);
                return;
            }
        }
        #endregion
    }
}
