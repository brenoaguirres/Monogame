using System;
using TRexGame.Engine.Graphics;

namespace TRexGame.Engine.Animation
{
    public class Frame
    {
        #region CONSTRUCTOR
        public Frame(Sprite sprite, float timeStamp)
        {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }
        #endregion

        #region FIELDS
        private bool _dispatchEvent = false;
        #endregion

        #region PROPERTIES
        public Sprite Sprite { get; }
        public float TimeStamp { get; }
        public bool DispatchEvent { get => _dispatchEvent; set => _dispatchEvent = value; }
        #endregion

        #region EVENTS
        public Action<Frame> OnFrame;
        #endregion
    }
}
