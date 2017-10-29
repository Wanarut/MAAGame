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
        public StatusBar hp_bar = new StatusBar();
        public StatusBar sp_bar = new StatusBar();
        #endregion

#region Animation var
        //Frame var
        protected int frame;
        public int frame_width;
        public int frame_height;
        protected int column_count;
        protected int row_count;
        protected int fps;
        protected int time_cast;
        protected float timePerFrame;
        protected float TotalElapsed;
        protected bool Paused;
        //avatar var
        protected bool focus = true;
        public bool reach_target = false;
        protected bool isdead = false;
        public Character next;
        public Texture2D texture;
        public ContentManager content;

        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isMoveing;

        public event EventHandler Click;

        public Rectangle Rectangle

        {
            get
            {
                return new Rectangle((int)current_position.X, (int)current_position.Y, frame_width, frame_height);
            }
        }

        public Vector2 Position { get; set; }
        
        public bool isattacking = false;
        public float Rotation = 0;
        public float Scale = 1;
        public float Depth = 0;
        public Vector2 current_position = Vector2.Zero;
        public Vector2 origin = Vector2.Zero;
        public List<Character> targets = new List<Character>();
        public Attack current_attack;
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
            this.Position = origin;
        }

        public Character(Vector2 origin, float rotation, float scale, float depth)
        {
            this.Position = origin;
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
            this.texture = content.Load<Texture2D>("Character/" + name + "/" + uniform);
            this.frame_width = texture.Width / column_count;
            this.frame_height = texture.Height / row_count;
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

        public int Get_Max_Stamina()
        {
            return max_stamina;
        }

        public int Get_Max_Health()
        {
            return max_stamina;
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

        public Character Get_Me()
        {
            return this;
        }

        public List<Attack> Get_Attacks()
        {
            return attacks;
        }
        #endregion

        #region Set Function
        public void Set_Health(int health)
        {
            this.health = health;
        }

        public void Set_Stamina(int stamina)
        {
            this.stamina = stamina;
        }

        public void Set_Attack(int attack)
        {
            this.attack = attack;
        }

        public void Set_Defense(int defense)
        {
            this.defense = defense;
        }

        public void Set_Accuracy(int accuracy)
        {
            this.accuracy = accuracy;
        }

        public void Set_Evasion(int evasion)
        {
            this.evasion = evasion;
        }

        public void Set_Class(int _class)
        {
            this._class = _class;
        }

        public void Set_Focus(bool logic)
        {
            focus = logic;
        }

        public void Set_WasAttacked(bool logic)
        {
            reach_target = logic;
        }

        public void Set_IsDead(bool logic)
        {
            isdead = logic;
        }
#endregion

        public void SkillAction()
        {
            Character current = this;
            while (current != null)
            {
                focus = true;
                current = current.next;
            }
            if (!isattacking) Load(content, Hero.Ant_Man + "/Skills", current_attack.Get_Name(), 15, current_attack.Get_Time(), 15);
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
        //GameTime gameTime;
#region Graphic Function
        public void Update(ContentManager content,GameTime gameTime)
        {
            this.content = content;
            hp_bar.Update(gameTime);
            sp_bar.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            hp_bar.Draw(gameTime, spriteBatch);
            sp_bar.Draw(gameTime, spriteBatch);
        }

        public void UpdateFrame(float elapsed)
        {
#region Mouse Cast
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isMoveing = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isMoveing = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
            #endregion

#region reach target

            Rectangle targetRectangle = new Rectangle();
            try
            {
                targetRectangle = new Rectangle((int)targets[0].Position.X, (int)targets[0].Position.Y, frame_width, frame_height);
            }
            catch
            {

            }

            if (targetRectangle.Intersects(Rectangle)) reach_target = true;
            else reach_target = false;
#endregion

            if (Paused)
                return;

            TotalElapsed += elapsed;

            frame = (column_count * time_cast) + fps + 1;

            if (TotalElapsed > timePerFrame)
            {
                fps++;
                if (fps == column_count) time_cast++;

                if (!isattacking) current_position = Position;
                else {
                    if (current_attack.Get_Target() == TargetType.One_Enemy) Animating_Attack_2();
                    Calculator engine = new Calculator();
                    if (active) targets = engine.StatCalculate(this, targets);
                    active = false;
                }

                foreach (var target in targets)
                {
                    if (reach_target) target.Load(content, Hero.Ant_Man, "Ant-Man-Modern_was_Hit", 1, 1, 15);
                    else target.Load(content, Hero.Ant_Man, Suit.Ant_Man_Modern, 15, 4, 15);
                }

                //Set Back Main
                if (isattacking && frame == column_count * row_count)
                {
                    this.Load(content, Hero.Ant_Man, Suit.Ant_Man_Modern, 15, 4, 15);
                    isattacking = false;
                    foreach (var target in targets)
                        target.Load(content, Hero.Ant_Man, Suit.Ant_Man_Modern, 15, 4, 15);
                    targets = new List<Character>();
                    focus = false;
                }
                // Keep the Frame between 0 and the total frames, minus one.
                fps = fps % column_count;
                time_cast = time_cast % row_count;
                TotalElapsed -= timePerFrame;
            }
        }

        public void DrawFrame(SpriteBatch spriteBatch)
        {
            DrawFrame(spriteBatch, fps, time_cast);
        }

        public void DrawFrame(SpriteBatch spriteBatch, int columnframe, int rowframe, SpriteEffects effect = SpriteEffects.None)
        {
            var color = Color.Gray;

            if (isMoveing || focus)
                color = Color.White;

            int framewidth = texture.Width / column_count;
            int framehigth = texture.Height / row_count;
            Rectangle source_rect = new Rectangle(framewidth * columnframe, framehigth * rowframe, framewidth, framehigth);
            spriteBatch.Draw(texture, this.current_position, source_rect, color, Rotation, origin, Scale, effect, Depth);
        }

        public void DrawFrameFlip(SpriteBatch spriteBatch)
        {
            DrawFrameFlip(spriteBatch, fps, time_cast);
        }

        public void DrawFrameFlip(SpriteBatch spriteBatch, int columnframe, int rowframe)
        {
            DrawFrame(spriteBatch, columnframe, rowframe, SpriteEffects.FlipHorizontally);
        }
        #endregion
        bool active = true;

        private void Animating_Attack_2()
        {
            Vector2 goal = new Vector2(targets[0].Position.X - (targets[0].frame_width / 8), targets[0].Position.Y);
            Transition(Position, goal, 32, 5);
            Transition(goal, Position, 70, 5);
        }

        public void Transition(Vector2 initial, Vector2 final, int startframe, int frame_count)
        {
            if (isattacking && frame > startframe && frame < startframe + frame_count)
            {
                current_position.X += Speed(initial, final, frame_count).X;
                current_position.Y += Speed(initial, final, frame_count).Y;
            }
        }

        public Vector2 Speed(Vector2 initial, Vector2 final, float frame)
        {
            return new Vector2((final.X - initial.X) / frame, (final.Y - initial.Y) / frame);
        }
    }
}
