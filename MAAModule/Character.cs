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

        #region Heroes Data
        public static Character Dr_Strange = new Character("Dr. Strange", "Dr._Strange-Classic", 6438, 5722, 1717, 1144, 1717, 1288, Character.CLASS_Tactician);
        public static Character Deadpool = new Character("Deadpool", "Deadpool-Classic", 7868, 6438, 1717, 1431, 1431, 1288, Character.CLASS_Scrapper);
        public static Character Captain_America = new Character("Captain America", "Captain_America-Classic", 7153, 7153, 1431, 1431, 1574, 1288, Character.CLASS_Generalist);
        public static Character Cable = new Character("Cable", "Cable-Classic", 7153, 5722, 1574, 1574, 1431, 1144, Character.CLASS_Blaster);
        public static Character Ghost_Rider = new Character("Ghost Rider", "Ghost_Rider-Classic", 6438, 7153, 1574, 1431, 1574, 1288, Character.CLASS_Scrapper);
        public static Character Cyclops = new Character("Cyclops", "Cyclops-Modern", 7153, 7153, 1431, 1431, 1574, 1288, Character.CLASS_Tactician);
        public static Character Ant_Man = new Character("Ant-Man", "Ant-Man-Modern", 6438, 7868, 1431, 1288, 1431, 1574, Character.CLASS_Infiltrator);
        public static Character Hulk = new Character("Hulk", "Hulk-Savage", 8584, 6438, 1574, 1574, 1144, 1144, Character.CLASS_Bruiser);
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
        private bool focus = false;

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

        public Character()
        {

        }

        public Character(string name, string sub_name, int health, int stamina, int attack, int defense, int accuracy, int evasion, int type)
        {
            this.name = name;
            this.sub_name = sub_name;
            this.health = health;
            this.stamina = stamina;
            this.attack = attack;
            this.defense = defense;
            this.accuracy = accuracy;
            this.evasion = evasion;
            this.type = type;
        }

        public Character(Texture2D texture)
        {
            this.texture = texture;
        }
        
        public Character Alternate_Uniform(string suit_name)
        {
            sub_name = suit_name;
            return this;
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
            focus = logic;
        }

        public bool YourTurn()
        {
            return focus;
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
            if(focus) spriteBatch.Draw(texture, position, Color.White);
            else spriteBatch.Draw(texture, position, Color.Gray);
        }

        public void DrawFlip(SpriteBatch spriteBatch)
        {
            if (focus) spriteBatch.Draw(texture, position, null, null, null, 0, null, Color.White, SpriteEffects.FlipHorizontally, 0);
            else spriteBatch.Draw(texture, position, null, null, null, 0, null, Color.Gray, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
