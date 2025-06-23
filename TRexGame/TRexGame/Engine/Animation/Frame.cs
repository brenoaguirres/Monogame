using TRexGame.Engine.Graphics;

namespace TRexGame.Engine.Animation
{
    public class Frame
    {
        public Frame(Sprite sprite, float timeStamp)
        {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }

        #region PROPERTIES
        public Sprite Sprite { get; }
        public float TimeStamp { get; }
        #endregion
    }
}
