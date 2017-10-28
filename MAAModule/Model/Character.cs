using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        /*public static Character Dr_Strange = new Character("Dr. Strange", "Dr._Strange-Classic", 6438, 5722, 1717, 1144, 1717, 1288, Character.CLASS_Tactician);
        public static Character Deadpool = new Character("Deadpool", "Deadpool-Classic", 7868, 6438, 1717, 1431, 1431, 1288, Character.CLASS_Scrapper);
        public static Character Captain_America = new Character("Captain America", "Captain_America-Classic", 7153, 7153, 1431, 1431, 1574, 1288, Character.CLASS_Generalist);
        public static Character Cable = new Character("Cable", "Cable-Classic", 7153, 5722, 1574, 1574, 1431, 1144, Character.CLASS_Blaster);
        public static Character Ghost_Rider = new Character("Ghost Rider", "Ghost_Rider-Classic", 6438, 7153, 1574, 1431, 1574, 1288, Character.CLASS_Scrapper);
        public static Character Cyclops = new Character("Cyclops", "Cyclops-Modern", 7153, 7153, 1431, 1431, 1574, 1288, Character.CLASS_Tactician);
        public static Character Ant_Man = new Character("Ant-Man", "Ant-Man-Modern", 6438, 7868, 1431, 1288, 1431, 1574, Character.CLASS_Infiltrator);
        public static Character Hulk = new Character("Hulk", "Hulk-Savage", 8584, 6438, 1574, 1574, 1144, 1144, Character.CLASS_Bruiser);*/
        #endregion

#region Fields
        protected string name;
        protected string alternate_uniform;

        protected int health;
        protected int stamina;
        protected int attack;
        protected int defense;
        protected int accuracy;
        protected int evasion;
        protected int _class;
        
        public Input input;
        public List<Attack> attacks = new List<Attack>();
#endregion

#region Animation var
        //Frame var
        protected int column_count;
        protected int row_count;
        protected int columnFrame;
        protected int rowFrame;
        protected float timePerFrame;
        protected float TotalElapsed;
        protected bool Paused;
        //avatar var
        protected bool focus = false;
        protected bool isdead = false;
        protected Texture2D texture;

        public float Rotation = 0;
        public float Scale = 1;
        public float Depth = 0;
        public Vector2 current_position = Vector2.Zero;
        public Vector2 origin = Vector2.Zero;
        #endregion

        /*public Character(string name, string sub_name, int health, int stamina, int attack, int defense, int accuracy, int evasion, int type)
        {
            this.name = name;
            this.alternate_uniform = sub_name;
            this.health = health;
            this.stamina = stamina;
            this.attack = attack;
            this.defense = defense;
            this.accuracy = accuracy;
            this.evasion = evasion;
            this.type = type;
        }*/

#region constructor
        public Character()
        {

        }

        public Character(string name)
        {
            this.name = name;
        }

        public Character(Vector2 origin)
        {
            this.current_position = origin;
        }

        public Character(Vector2 origin, float rotation, float scale, float depth)
        {
            this.current_position = origin;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Depth = depth;
        }
        #endregion

        public void Load(ContentManager content, string name, string uniform, int columnframeCount, int rowframeCount, int framesPerSec)
        {
            this.column_count = columnframeCount;
            this.row_count = rowframeCount;
            this.texture = content.Load<Texture2D>("Character/" + name + "/" + uniform);
            timePerFrame = (float)1 / framesPerSec;
            columnFrame = 0;
            rowFrame = 0;
            TotalElapsed = 0;
            Paused = false;
        }

#region Get Function
        public string Get_Name()
        {
            return name;
        }

        public string Get_Uniform()
        {
            return alternate_uniform;
        }

        public int Get_Health()
        {
            return health;
        }

        public int Get_Stamina()
        {
            return stamina;
        }

        public int Get_Attack()
        {
            return attack;
        }

        public int Get_Defense()
        {
            return defense;
        }

        public int Get_Accuracy()
        {
            return accuracy;
        }

        public int Get_Evasion()
        {
            return evasion;
        }

        public int Get_Class()
        {
            return _class;
        }

        public int Get_Height()
        {
            return texture.Height / row_count;
        }

        public int Get_Width()
        {
            return texture.Width / column_count;
        }

        public List<Attack> Get_Attacks()
        {
            return attacks;
        }
#endregion

        public void YourTurn(bool logic)
        {
            focus = logic;
        }

        public bool YourTurn()
        {
            return focus;
        }

#region FrameControl Function
        public bool IsPaused
        {
            get { return Paused; }
        }

        public void Reset()
        {
            columnFrame = 0;
            TotalElapsed = 0f;
        }

        public void Stop()
        {
            Pause();
            Reset();
        }

        public void Play()
        {
            Paused = false;
        }

        public void Pause()
        {
            Paused = true;
        }
        #endregion

        /*public void Update()
        {
            Move();
        }*/

        /*public void Move()
        {
            /*if (Keyboard.GetState().IsKeyDown(input.Up))
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
        }*/

        /*public void Draw(SpriteBatch spriteBatch)
        {
            if(focus) spriteBatch.Draw(texture, position, Color.White);
            else spriteBatch.Draw(texture, position, Color.Gray);
        }*/

#region Graphic Function
        public void UpdateFrame(float elapsed)
        {
            if (Paused)
                return;
            TotalElapsed += elapsed;
            if (TotalElapsed > timePerFrame)
            {
                columnFrame++;
                if (columnFrame == column_count) rowFrame++;
                // Keep the Frame between 0 and the total frames, minus one.
                columnFrame = columnFrame % column_count;
                rowFrame = rowFrame % row_count;
                TotalElapsed -= timePerFrame;
            }
        }

        public void DrawFrame(SpriteBatch batch, Vector2 position)
        {
            DrawFrame(batch, columnFrame, rowFrame, position);
        }

        public void DrawFrame(SpriteBatch spriteBatch, int columnframe, int rowframe, Vector2 position, SpriteEffects effect = SpriteEffects.None)
        {
            int framewidth = texture.Width / column_count;
            int framehigth = texture.Height / row_count;
            Rectangle source_rect = new Rectangle(framewidth * columnframe, framehigth * rowframe, framewidth, framehigth);
            if(focus) spriteBatch.Draw(texture, current_position, source_rect, Color.White, Rotation, origin, Scale, effect, Depth);
            else spriteBatch.Draw(texture, current_position, source_rect, Color.Gray, Rotation, origin, Scale, effect, Depth);
        }

        public void DrawFrameFlip(SpriteBatch batch, Vector2 position)
        {
            DrawFrameFlip(batch, columnFrame, rowFrame, position);
        }

        public void DrawFrameFlip(SpriteBatch spriteBatch, int columnframe, int rowframe, Vector2 position)
        {
            /*if (focus) spriteBatch.Draw(texture, position, null, null, null, 0, null, Color.White, SpriteEffects.FlipHorizontally, 0);
            else spriteBatch.Draw(texture, position, null, null, null, 0, null, Color.Gray, SpriteEffects.FlipHorizontally, 0);*/
            DrawFrame(spriteBatch, columnframe, rowframe, position, SpriteEffects.FlipHorizontally);
        }
#endregion
    }
}
