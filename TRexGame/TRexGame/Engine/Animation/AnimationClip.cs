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
        public string Name { get; set; }
        public float CurrentFrameTimestamp
        {
            get => _frames[_currentFrameIndex].TimeStamp;
        }
        public bool LoopAnimation { get => _loopAnimation; set => _loopAnimation = value; }
        public float AnimationSpeed => _animationSpeed;
        public float ClipDuration { get; private set; }
        public float TotalFrameTime { get; private set; }
        public int CurrentFrameIndex { get => _currentFrameIndex; set => _currentFrameIndex = value; }
        #endregion

        #region PRIVATE METHODS
        private void GenerateFrames()
        {
            TotalFrameTime = (1.0f / _animationSpeed) / _sprites.Length;
            float timestamp = 0;

            _frames = new();
            foreach (var sprite in _sprites)
            {
                _frames.Add(new Frame(sprite, timestamp));
                timestamp += TotalFrameTime;
            }

            ClipDuration = timestamp;
        }
        #endregion

        #region PUBLIC METHODS
        public Sprite NextSprite()
        {
            if (_currentFrameIndex < _sprites.Length)
                _currentFrameIndex++;
            
            if (_currentFrameIndex >= _sprites.Length && _loopAnimation)
                _currentFrameIndex = 0;

            DispatchFrameEvents();
            return _sprites[_currentFrameIndex];
        }
        public void DispatchFrameEvents()
        {
            if (_frames[_currentFrameIndex].DispatchEvent)
                _frames[_currentFrameIndex].OnFrame?.Invoke(_frames[_currentFrameIndex]);
        }
        public void ResetClip()
        {
            CurrentFrameIndex = 0;
        }
        #endregion
    }
}
