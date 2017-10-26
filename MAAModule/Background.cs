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
        #region Map
        public const string Background_001 = "Combat_Background_001";
        public const string Background_010 = "Combat_Background_010";
        public const string Background_011 = "Combat_Background_011";
        public const string Background_024 = "Combat_Background_024";
        public const string Background_025 = "Combat_Background_025";
        public const string Background_035 = "Combat_Background_035";
        public const string Background_067 = "Combat_Background_067";
        public const string Background_070 = "Combat_Background_070";
        public const string Background_075 = "Combat_Background_075";
        #endregion

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
