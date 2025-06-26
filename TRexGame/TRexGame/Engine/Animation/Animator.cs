using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Entities;
using TRexGame.Engine.Graphics;
using TRexGame.GameEntities.TRex;

namespace TRexGame.Engine.Animation
{
    public abstract class Animator
    {
        #region CONSTRUCTOR
        public Animator(IGameGraphics graphics, IGameDrawable drawable)
        {
            Graphics = graphics;
            CurrentAnimation = Graphics.DefaultAnimation;
            GameDrawable = drawable;

            InitializeAnimator();
        }
        #endregion

        #region PROPERTIES
        public IGameGraphics Graphics { get; protected set; }
        public AnimationClip DefaultAnimation => Graphics.DefaultAnimation;
        public AnimationClip CurrentAnimation { get; protected set; }
        public IGameDrawable GameDrawable { get; protected set; }


        public bool isPlaying = false;
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

            if (isPlaying)
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
            isPlaying = true;
            OnAnimationEnter?.Invoke(CurrentAnimation);
            GameDrawable.Sprite = CurrentAnimation.CurrentFrameSprite;
        }

        public void Pause()
        {
            isPlaying = false;
        }

        public void Default()
        {
            Stop();
            Play(DefaultAnimation);
        }

        public void Stop()
        {
            if (CurrentAnimation == null) return;

            isPlaying = false;
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
