using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule
{
    class Background
    {
        public const string Background_024 = "Combat_Background_024";
        public const string Background_048 = "Combat_Background_048";

        private string name;

        protected Texture2D texture;

        public Vector2 position = new Vector2(0, 0);

        public Background()
        {

        }

        public Background(string name)
        {
            this.name = name;
        }

        public Background(Texture2D texture)
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

        public void Update()
        {
            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
