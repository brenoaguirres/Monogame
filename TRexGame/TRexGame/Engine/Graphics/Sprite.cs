using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TRexGame.Engine.Resources;

namespace TRexGame.Engine.Graphics
{
    public class Sprite
    {
        #region CONSTRUCTOR
        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            TintColor = Color.White;
        }
        #endregion

        #region PROPERTIES
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Color TintColor {  get; set; }
        #endregion
    }
}
