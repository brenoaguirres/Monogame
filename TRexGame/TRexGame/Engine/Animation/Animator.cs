using System;
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
            GameDrawable.Sprite = CurrentAnimation.CurrentFrameSprite;

            InitializeAnimator();
        }
        #endregion

        #region PROPERTIES
        public IGameGraphics Graphics { get; protected set; }
        public AnimationClip DefaultAnimation => Graphics.DefaultAnimation;
        public AnimationClip CurrentAnimation { get; protected set; }
        public IGameDrawable GameDrawable { get; protected set; }


        public bool isPlaying = false;
        public float CurrentTimeStamp { get; protected set; }
        public float TotalTimeStamp { get; protected set; }
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
        public void Update(GameTime gameTime)
        {
            UpdateStates(gameTime);

            if (isPlaying)
            {
                if (CurrentTimeStamp >= TotalTimeStamp)
                {
                    if (!CurrentAnimation.LoopAnimation)
                        Stop();
                    else
                    {
                        GameDrawable.Sprite = CurrentAnimation.NextSprite();
                        Play(CurrentAnimation);
                    }
                }

                if (CurrentTimeStamp >= CurrentAnimation.CurrentFrameTimestamp + CurrentAnimation.TotalFrameTime)
                    GameDrawable.Sprite = CurrentAnimation.NextSprite();

                CurrentTimeStamp += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Play(AnimationClip animationClip)
        {
            CurrentAnimation = animationClip;
            CurrentTimeStamp = 0;
            CurrentAnimation.CurrentFrameIndex = 0;
            TotalTimeStamp = CurrentAnimation.TotalAnimationTime;
            isPlaying = true;
            OnAnimationEnter?.Invoke(CurrentAnimation);
        }

        public void Pause()
        {
            isPlaying = false;
        }

        public void Stop()
        {
            isPlaying = false;
            CurrentTimeStamp = 0;
            CurrentAnimation.CurrentFrameIndex = 0;
            TotalTimeStamp = CurrentAnimation.TotalAnimationTime;
            OnAnimationExit?.Invoke(CurrentAnimation);
            CurrentAnimation = null;
        }
        #endregion
    }
}
