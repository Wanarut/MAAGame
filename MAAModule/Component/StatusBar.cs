using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MAAModule.Model
{
    class StatusBar : Component
    {
        public const string HEALTH = "HEALTH   ";
        public const string STAMINA = "STAMINA";

        private const int MAX_WIDTH = 80;
        private const int MAX_HEIGHT = 8;

        private bool active;
        private string hero_name;
        private int width;
        private int value;
        private int max_value;
        private string type;

        SpriteFont Calibri;
        SpriteFont Conso;
        ContentManager content;
        Texture2D texture;

        public Vector2 Position { get; set; }

        public StatusBar()
        {

        }

        public StatusBar(int max_value, string type)
        {
            this.width = MAX_WIDTH;
            this.max_value = max_value;
            this.type = type;
            this.value = max_value;
        }

        public StatusBar(string name, int max_value, string type)
        {
            this.hero_name = name;
            this.width = MAX_WIDTH;
            this.max_value = max_value;
            this.type = type;
            this.value = max_value;
        }

        public void Set_Value(int value)
        {
            this.value = value;
        }

        public void Set_Active(bool logic)
        {
            active = logic;
        }

        public void Load(ContentManager content)
        {
            this.content = content;
            if (type == StatusBar.HEALTH) texture = content.Load<Texture2D>("Character/Agent/HP_pixel");
            else texture = content.Load<Texture2D>("Character/Agent/SP_pixel");
            Calibri = Conso = content.Load<SpriteFont>("Fonts/Calibri");
            Conso = content.Load<SpriteFont>("Fonts/Conso");
        }

        public override void Update(GameTime gameTime)
        {
            width = (value * MAX_WIDTH) / max_value;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(Convert.ToInt32(Position.X) + 43, Convert.ToInt32(Position.Y), width, MAX_HEIGHT), Color.White);
            spriteBatch.DrawString(Calibri, type + "                                          " + (value).ToString(), Position, Color.White);
            spriteBatch.DrawString(Conso, hero_name + "", new Vector2(Position.X + 160, Position.Y + 2), Color.White);
        }
    }
}
