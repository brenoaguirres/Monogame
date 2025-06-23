namespace TRexGame.Engine.Graphics
{
    public class RectTransform
    {
        #region CONSTRUCTOR
        public RectTransform(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        #endregion

        #region PROPERTIES
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
    }
}
