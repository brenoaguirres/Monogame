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
        public void Update(GameTime gameTime)
        {
            UpdateStates(gameTime);

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
            CurrentAnimation = animationClip;
            PlaybackTime = 0;
            CurrentAnimation.ResetClip();
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
            PlaybackTime = 0;
            CurrentAnimation.ResetClip();
            OnAnimationExit?.Invoke(CurrentAnimation);
            CurrentAnimation = null;
        }
        #endregion
    }
}
