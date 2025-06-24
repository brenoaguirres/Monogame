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
            RectTransform = new RectTransform(x, y, width, height);
            TintColor = Color.White;
        }
        #endregion

        #region PROPERTIES
        public Texture2D Texture { get; set; }
        public RectTransform RectTransform { get; set; }
        public Color TintColor {  get; set; }
        #endregion

        #region PUBLIC METHODS
        // Pass this to SpriteRenderer script to implement Sprite[] rendering
        public void Draw(SpriteBatch spriteBatch, Vector2 Position)
        {
            spriteBatch.Draw(
                Texture,
                Position, 
                new Rectangle(RectTransform.X, RectTransform.Y, RectTransform.Width, RectTransform.Height),
                TintColor
                );
        }
        #endregion
    }
}
