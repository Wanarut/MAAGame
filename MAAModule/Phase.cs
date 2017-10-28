using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using MAAModule.Chars;

namespace MAAModule
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Phase : Game
    {
        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public int width = 760;
        public int height = 630;

        private List<Character> teams = new List<Character>();
        private List<Character> enemies = new List<Character>();
        private List<List<Component>> skillComponents = new List<List<Component>>();
        private List<Component> menuComponent = new List<Component>();
        private List<Character> turnbase = new List<Character>();
        private int currentturn = 0;

        Background combat_background;
        Background empty_status_bar;
        #endregion
        
        public Phase()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            // Frame rate is 30 fps by default for Zune.
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Start with your 3 Heroes
            teams.Add(new Ant_Man());
            teams.Add(new Ant_Man());
            teams.Add(new Ant_Man());

            //Set Enemies team
            enemies.Add(new Ant_Man());
            enemies.Add(new Ant_Man());
            enemies.Add(new Ant_Man());

            //Set background
            combat_background = new Background(Content.Load<Texture2D>(Background.Background_010));

            base.Initialize();
        }

        private Viewport viewport;
        private const int framerate = 15;
        private const int action_time = 5;
        private const int FramesPerSec = 15;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            viewport = graphics.GraphicsDevice.Viewport;

            empty_status_bar = new Background(Content.Load<Texture2D>("Character/Agent/Empty_status_bar"));
            empty_status_bar.position = new Vector2(0, 630 - empty_status_bar.Get_Height());

            setWindows_size(width, height);

            // TODO: use this.Content to load your game content here
            //Load teams
            for (int i = 0; i < teams.Count; i++)
            {
                List<Component> temp = new List<Component>();
                for (int j = 0; j < teams[i].attacks.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + teams[i].Get_Name() + "/" + teams[i].attacks[j].Get_Name()));
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 4) * (btnskill.Get_Width() + 8)) + (btnskill.Get_Width() / 2), 496);
                    temp.Add(btnskill);
                    btnskill.Set_btn_Name(teams[i].attacks[j].Get_Name());
                    btnskill.Click += btnskill_Click;
                }
                skillComponents.Add(temp);
                
                teams[i].Load(Content, teams[i].Get_Name(), teams[i].Get_Uniform(), 10, 6, 15);
                teams[i].current_position = new Vector2(40 + ((i % 2) * 150) - (i * 10), 330 + (i * 70) - teams[i].Get_Height());
            }
            //Load enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                List<Component> temp = new List<Component>();
                for (int j = 0; j < enemies[i].attacks.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + enemies[i].Get_Name() + "/" + enemies[i].attacks[j].Get_Name()));
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 4) * (btnskill.Get_Width() + 8)) + (btnskill.Get_Width() / 2), 496);
                    temp.Add(btnskill);
                    btnskill.Set_btn_Name(enemies[i].attacks[j].Get_Name());
                    btnskill.Click += btnskill_Click;
                }
                skillComponents.Add(temp);

                enemies[i].Load(Content, enemies[i].Get_Name(), enemies[i].Get_Uniform(), 10, 6, 15);
                enemies[i].current_position = new Vector2(width - 40 - ((i % 2) * 150) + (i * 10) - enemies[i].Get_Width(), 330 + (i * 70) - enemies[i].Get_Height());
            }

            //next turn btn
            var btnNextTurn = new Button(Content.Load<Texture2D>(Button.Agent_Recharge));
            btnNextTurn.Position = new Vector2(((combat_background.Get_Width() - btnNextTurn.Get_Width()) / 2) + ((4 - 0) * (btnNextTurn.Get_Width() + 8)) - (btnNextTurn.Get_Width() / 2), 496);
            menuComponent.Add(btnNextTurn);
            btnNextTurn.Set_btn_Name(Button.Agent_Recharge);
            btnNextTurn.Click += btnMenu_Click;

            var btnInventory = new Button(Content.Load<Texture2D>(Button.Agent_Inventory));
            btnInventory.Position = new Vector2(((combat_background.Get_Width() - btnInventory.Get_Width()) / 2) + ((4 - 1) * (btnInventory.Get_Width() + 8)) - (btnInventory.Get_Width() / 2), 496);
            menuComponent.Add(btnInventory);
            btnInventory.Set_btn_Name(Button.Agent_Inventory);
            btnInventory.Click += btnMenu_Click;

            var btnCall = new Button(Content.Load<Texture2D>(Button.Agent_Distress_Call));
            btnCall.Position = new Vector2(((combat_background.Get_Width() - btnCall.Get_Width()) / 2) + ((4 - 2) * (btnCall.Get_Width() + 8)) - (btnCall.Get_Width() / 2), 496);
            menuComponent.Add(btnCall);
            btnCall.Set_btn_Name(Button.Agent_Distress_Call);
            btnCall.Click += btnMenu_Click;

            var btnArc = new Button(Content.Load<Texture2D>(Button.Arc_Reactor_Charge));
            btnArc.Position = new Vector2(((combat_background.Get_Width() - btnArc.Get_Width()) / 2) + ((4 - 3) * (btnArc.Get_Width() + 8)) - (btnArc.Get_Width() / 2), 496);
            menuComponent.Add(btnArc);
            btnArc.Set_btn_Name(Button.Arc_Reactor_Charge);
            btnArc.Click += btnMenu_Click;

            //set turn base
            foreach (Character avatar in teams)
                turnbase.Add(avatar);

            foreach (Character avatar in enemies)
                turnbase.Add(avatar);

            turnbase[0].YourTurn(true);
        }

        private void btnskill_Click(object sender, EventArgs e)
        {
            string btnname = ((Button)sender).Get_Name();
            Console.Out.WriteLine("Skill " + btnname + " was used!!!");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            string btnname = ((Button)sender).Get_Name();

            switch (btnname)
            {
                case Button.Agent_Recharge :
                    {
                        turnbase[currentturn].YourTurn(false);
                        if (currentturn == turnbase.Count - 1) currentturn = 0;
                        else currentturn++;
                        turnbase[currentturn].YourTurn(true);
                        break;
                    }
                case Button.Agent_Inventory:
                    {
                        //show Inventory Item
                        break;
                    }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var avatar in turnbase)
                avatar.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var component in skillComponents[currentturn])
                component.Update(gameTime);

            foreach (var component in menuComponent)
                component.Update(gameTime);

            /*foreach (var avatar in turnbase)
                avatar.UpdateFrame(elapsed);*/

            foreach (var hero in teams)
                hero.UpdateFrame(elapsed);

            foreach (var villain in enemies)
                villain.UpdateFrame(elapsed);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(BG);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            combat_background.Draw(spriteBatch);

            foreach (var hero in teams)
                hero.DrawFrame(spriteBatch, hero.current_position);

            foreach (var hero in enemies)
                hero.DrawFrameFlip(spriteBatch, hero.current_position);

            empty_status_bar.Draw(spriteBatch);
            
            foreach (var component in skillComponents[currentturn])
                component.Draw(gameTime, spriteBatch);

            foreach (var component in menuComponent)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void setWindows_size(int w, int h)
        {
            this.width = w;
            this.height = h;

            graphics.PreferredBackBufferWidth = w;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = h;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }
    }
}
