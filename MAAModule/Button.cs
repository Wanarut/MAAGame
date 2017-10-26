using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MAAModule
{
    class Button : Component
    {
        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isMoveing;
        private Texture2D texture;

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColor { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        public Button(Texture2D texture)
        {
            this.texture = texture;
        }

        public int Get_Height()
        {
            return texture.Height;
        }

        public int Get_Width()
        {
            return texture.Width;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (isMoveing)
                color = Color.Gray;

            spriteBatch.Draw(texture, Rectangle, color);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isMoveing = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isMoveing = true;

                if(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
