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
        #region
        public const string Agent_Recharge = "Agent_Recharge";
        public const string Agent_Inventory = "Agent_Inventory";
        #endregion

        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isMoveing;
        private Texture2D texture;
        private string name;

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

        public string Get_Name()
        {
            return name;
        }

        public int Get_Height()
        {
            return texture.Height;
        }

        public int Get_Width()
        {
            return texture.Width;
        }

        public void Set_btn_Name(string name)
        {
            this.name = name;
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
