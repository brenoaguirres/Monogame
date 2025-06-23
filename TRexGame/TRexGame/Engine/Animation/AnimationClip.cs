using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TRexGame.Engine.Graphics;

namespace TRexGame.Engine.Animation
{
    public class AnimationClip
    {
        #region CONSTRUCTOR
        public AnimationClip(Sprite[] sprites)
        {
            _sprites = sprites;
            GenerateFrames();
        }
        #endregion

        #region FIELDS
        private Sprite[] _sprites;
        private List<Frame> _frames;
        private int _currentFrameIndex = 0;
        private bool _loopAnimation = false;
        private float _animationSpeed = 1;
        #endregion

        #region PROPERTIES
        public Sprite CurrentFrameSprite
        {
            get => _frames[_currentFrameIndex].Sprite;
        }
        public float CurrentFrameTimestamp
        {
            get => _frames[_currentFrameIndex].TimeStamp;
        }
        public bool LoopAnimation { get => _loopAnimation; set => _loopAnimation = value; }
        public float AnimationSpeed => _animationSpeed;
        public float TotalAnimationTime { get; private set; }
        public bool IsLastFrame { get { return _currentFrameIndex == _sprites.Length - 1; } }
        #endregion

        #region PRIVATE METHODS
        private void GenerateFrames()
        {
            float timestampPerFrame = (1.0f / _animationSpeed) / _sprites.Length;
            float timestamp = 0;

            _frames = new();
            foreach (var sprite in _sprites)
            {
                _frames.Add(new Frame(sprite, timestamp));
                timestamp += timestampPerFrame;
            }

            TotalAnimationTime = timestamp + timestampPerFrame;
        }
        #endregion

        #region PUBLIC METHODS
        public Sprite NextSprite()
        {
            
            if (_currentFrameIndex < _sprites.Length)
                _currentFrameIndex++;
            
            if (_currentFrameIndex >= _sprites.Length && _loopAnimation)
                _currentFrameIndex = 0;

            return _sprites[_currentFrameIndex];
        }
        #endregion
    }
}
