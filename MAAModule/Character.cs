using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule
{
    class Character
    {
        #region Class
        public const int CLASS_Generalist = 0;
        public const int CLASS_Blaster = 1;
        public const int CLASS_Bruiser = 2;
        public const int CLASS_Scrapper = 3;
        public const int CLASS_Infiltrator = 4;
        public const int CLASS_Tactician = 5;
        #endregion

        #region Heroes
        public const string Deadpool = "Deadpool";
        public const string Captain_America = "Captain_America";
        public const string DrStrange = "Dr._Strange";
        public const string Iron_Man = "Iron_Man";
        public const string SpiderMan = "Spider-Man";
        #endregion

        #region Villains
        public const string Hela = "Hela";
        public const string Sin = "Sin";
        public const string Thanos = "Thanos";
        #endregion

        #region Fields
        private string name;
        private string sub_name;
        private int health;
        private int stamina;
        private int attack;
        private int defense;
        private int accuracy;
        private int evasion;
        private int type;
        private bool myturn = false;

        protected float rotation;
        protected Texture2D texture;
        
        public bool isdead = false;
        public float rotationVelocity = 3f;
        public float linearVelocity = 4f;
        public Character parent;
        public Vector2 position = new Vector2(0, 0);
        public Vector2 direction = new Vector2(0, 0);

        public Input input;

        public List<Skill> skills = new List<Skill>();
        #endregion

        public Character(string name, string sub_name)
        {
            this.name = name;
            this.sub_name = sub_name;
        }

        public Character(Texture2D texture)
        {
            this.texture = texture;
        }

        public void setState(int health, int stamina, int attack, int defense, int accuracy, int evasion, int type)
        {
            this.health = health;
            this.stamina = stamina;
            this.attack = attack;
            this.defense = defense;
            this.accuracy = accuracy;
            this.evasion = evasion;
            this.type = type;
        }

        public string Get_Name()
        {
            return name;
        }

        public string Get_subName()
        {
            return sub_name;
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
            //Move();
        }

        public void YourTurn(bool logic)
        {
            myturn = logic;
        }

        public bool YourTurn()
        {
            return myturn;
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                position.Y--;
            }
            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                position.Y++;
            }
            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                position.X--;
            }
            if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                position.X++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(myturn) spriteBatch.Draw(texture, position, Color.White);
            else spriteBatch.Draw(texture, position, Color.Gray);
        }
    }
}
