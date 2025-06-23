using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TRexGame.Engine.Animation;
using TRexGame.Engine.Graphics;
using TRexGame.Engine.Entities;

namespace TRexGame.GameEntities.TRex
{
    public class TRexAnimator : Animator
    {
        #region CONSTRUCTOR
        public TRexAnimator(Texture2D texture, IGameDrawable drawable)
        {
            Graphics = new(texture);
            CurrentAnimation = Graphics.IdleAnimation;
            GameDrawable = drawable;
            GameDrawable.Sprite = CurrentAnimation.CurrentFrameSprite;

            InitializeAnimator();
        }
        #endregion

        #region PROPERTIES
        public TRexGraphics Graphics { get; }
        public AnimationClip DefaultAnimation => Graphics.IdleAnimation;
        public AnimationClip CurrentAnimation {  get; private set; }
        public IGameDrawable GameDrawable { get; private set; }


        public bool isPlaying = false;
        public float CurrentTimeStamp { get; private set; }
        public float TotalTimeStamp { get; private set; }
        #endregion

        #region PRIVATE METHODS
        private void InitializeAnimator()
        {
            Play(DefaultAnimation);
        }
        #endregion

        #region PUBLIC METHODS
        public override void Update(GameTime gameTime)
        {
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

                if (CurrentTimeStamp >= CurrentAnimation.CurrentFrameTimestamp && !CurrentAnimation.IsLastFrame)
                    GameDrawable.Sprite = CurrentAnimation.NextSprite();

                CurrentTimeStamp += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Play(AnimationClip animationClip)
        {
            CurrentAnimation = animationClip;
            CurrentTimeStamp = 0;
            TotalTimeStamp = CurrentAnimation.TotalAnimationTime;
            isPlaying = true;
        }

        public void Stop()
        {
            isPlaying = false;
        }
        #endregion
    }
}
