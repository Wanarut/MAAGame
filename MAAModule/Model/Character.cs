using MAAModule.Model;
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

        protected int max_health;
        protected int health;
        protected int max_stamina;
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
        protected int frame;
        protected int column_count;
        protected int row_count;
        protected int fps;
        protected int time_cast;
        protected float timePerFrame;
        protected float TotalElapsed;
        protected bool Paused;
        //avatar var
        protected bool focus = false;
        protected bool isattacking = false;
        protected bool wasattacked = false;
        protected bool isdead = false;
        protected Texture2D texture;
        protected ContentManager content;

        public float Rotation = 0;
        public float Scale = 1;
        public float Depth = 0;
        public Vector2 current_position = Vector2.Zero;
        public Vector2 position = Vector2.Zero;
        public Vector2 origin = Vector2.Zero;
        #endregion

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
            this.position = origin;
        }

        public Character(Vector2 origin, float rotation, float scale, float depth)
        {
            this.position = origin;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Depth = depth;
        }
        #endregion
        
        public void Load(ContentManager content, string name, string uniform, int columnframeCount, int rowframeCount, int framesPerSec)
        {
            this.content = content;
            this.column_count = columnframeCount;
            this.row_count = rowframeCount;
            this.texture = this.content.Load<Texture2D>("Character/" + name + "/" + uniform);
            timePerFrame = (float)1 / framesPerSec;
            fps = 0;
            time_cast = 0;
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

#region Set Function
        public void Set_Focus(bool logic)
        {
            focus = logic;
        }

        public void Set_WasAttacked(bool logic)
        {
            wasattacked = logic;
        }

        public void Set_IsDead(bool logic)
        {
            isdead = logic;
        }
#endregion

        public void SkillAction(ContentManager content, string skill_name, int time)
        {
            Load(content, Hero.Ant_Man + "/Skills", skill_name, 15, time, 15);
            isattacking = true;
        }

#region FrameControl Function
        public bool IsPaused
        {
            get { return Paused; }
        }

        public void Reset()
        {
            fps = 0;
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

#region Graphic Function
        public void UpdateFrame(float elapsed)
        {
            if (Paused)
                return;
            TotalElapsed += elapsed;
            if (TotalElapsed > timePerFrame)
            {
                fps++;
                if (fps == column_count) time_cast++;
                if (!isattacking) current_position = position;

            #region Animating Edit
                Transition(position, new Vector2(0,0), 32, 5);
            #endregion

                //Set Back Main
                if (isattacking && frame == column_count * row_count)
                {
                    this.Load(content, Hero.Ant_Man, Suit.Ant_Man_Modern, 10, 6, 15);
                    isattacking = false;
                }
                // Keep the Frame between 0 and the total frames, minus one.
                fps = fps % column_count;
                time_cast = time_cast % row_count;
                TotalElapsed -= timePerFrame;
            }
        }

        public void DrawFrame(SpriteBatch batch, Vector2 position)
        {
            DrawFrame(batch, fps, time_cast, position);
        }

        public void DrawFrame(SpriteBatch spriteBatch, int columnframe, int rowframe, Vector2 position, SpriteEffects effect = SpriteEffects.None)
        {
            int framewidth = texture.Width / column_count;
            int framehigth = texture.Height / row_count;
            Rectangle source_rect = new Rectangle(framewidth * columnframe, framehigth * rowframe, framewidth, framehigth);
            if(focus) spriteBatch.Draw(texture, this.current_position, source_rect, Color.White, Rotation, origin, Scale, effect, Depth);
            else spriteBatch.Draw(texture, this.current_position, source_rect, Color.Gray, Rotation, origin, Scale, effect, Depth);
        }

        public void DrawFrameFlip(SpriteBatch batch, Vector2 position)
        {
            DrawFrameFlip(batch, fps, time_cast, position);
        }

        public void DrawFrameFlip(SpriteBatch spriteBatch, int columnframe, int rowframe, Vector2 position)
        {
            DrawFrame(spriteBatch, columnframe, rowframe, position, SpriteEffects.FlipHorizontally);
        }

        public Vector2 Speed(Vector2 initial,Vector2 final,float frame)
        {
            return new Vector2((final.X - initial.X) / frame, (final.Y - initial.Y) / frame);
        }

        public void Transition(Vector2 initial, Vector2 final, int startframe, int frame_count)
        {
            frame = (column_count * time_cast) + fps + 1;

            if (isattacking && frame > startframe && frame < startframe + frame_count)
            {
                current_position.X += Speed(initial, final, frame_count).X;
                current_position.Y += Speed(initial, final, frame_count).Y;
            }
        }
#endregion
    }
}
