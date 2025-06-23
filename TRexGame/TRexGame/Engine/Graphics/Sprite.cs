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
        public Sprite(Texture2D texture, float pos_x, float pos_y, int x, int y, int width, int height)
        {
            Position = new Vector2(pos_x, pos_y);
            Texture = texture;
            RectTransform = new RectTransform(x, y, width, height);
            TintColor = Color.White;
        }
        #endregion

        #region PROPERTIES
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public RectTransform RectTransform { get; set; }
        public Color TintColor {  get; set; }
        #endregion

        #region PUBLIC METHODS
        public void Draw(SpriteBatch spriteBatch)
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
