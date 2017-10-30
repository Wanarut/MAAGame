using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using MAAModule.Chars;
using MAAModule.Model;

namespace MAAModule
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MAAGame : Game
    {
    #region Game Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Calculator engine;

        public const int PLAYER = 1;

        public int width = 760;
        public int height = 630;

        private List<Character> teams = new List<Character>();
        private List<Character> enemies = new List<Character>();
        private List<List<Component>> skillComponents = new List<List<Component>>();
        private List<Component> menuComponent = new List<Component>();
        private List<Character> heroes = new List<Character>();
        protected int current = 0;

        Background combat_background;
        Background empty_status_bar;
    #endregion
        
        public MAAGame()
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
            engine = new Calculator();
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

    #region Grapic Setting
        protected Viewport viewport;
        protected const int framerate = 30;
    #endregion

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

            Set_Windows_size(width, height);

            // TODO: use this.Content to load your game content here
            //Load teams
            for (int i = 0; i < teams.Count; i++)
            {
                //Load Skill
                List<Component> temp = new List<Component>();
                for (int j = 0; j < teams[i].attacks.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + teams[i].Get_Name() + "/" + teams[i].attacks[j].Get_Name()));
                    btnskill.attack = teams[i].attacks[j];
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 4) * (btnskill.Get_Width() + 8)) + (btnskill.Get_Width() / 2), 496);
                    temp.Add(btnskill);
                    btnskill.Click += BtnAttack_Click;
                }
                skillComponents.Add(temp);
                //Load Status
                teams[i].hp_bar = new StatusBar(teams[i].Get_Name(), teams[i].Get_Health(), StatusBar.HEALTH);
                teams[i].hp_bar.Position = new Vector2(7, height - 71 + (i * 24));
                teams[i].hp_bar.Load(Content);
                teams[i].sp_bar = new StatusBar(teams[i].Get_Stamina(), StatusBar.STAMINA);
                teams[i].sp_bar.Position = new Vector2(7, height - 61 + (i * 24));
                teams[i].sp_bar.Load(Content);
                //Load Sprite
                teams[i].Load(Content, teams[i].Get_Name(), teams[i].Get_Uniform(), 15, 4, framerate);
                teams[i].Position = new Vector2(40 + ((i % 2) * 150) - (i * 10), 330 + (i * 70) - teams[i].Get_Height());
                teams[i].Click += Char_was_Click;
            }
            //Load enemies
            for (int i = 0; i < teams.Count; i++)
            {
                //Load Skill
                List<Component> temp = new List<Component>();
                for (int j = 0; j < enemies[i].attacks.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + enemies[i].Get_Name() + "/" + enemies[i].attacks[j].Get_Name()));
                    btnskill.attack = enemies[i].attacks[j];
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 4) * (btnskill.Get_Width() + 8)) + (btnskill.Get_Width() / 2), 496);
                    temp.Add(btnskill);
                    btnskill.Click += BtnAttack_Click;
                }
                skillComponents.Add(temp);
                //Load Status
                enemies[i].hp_bar = new StatusBar(enemies[i].Get_Name(), enemies[i].Get_Health(), StatusBar.HEALTH);
                enemies[i].hp_bar.Position = new Vector2(389, height - 71 + (i * 24));
                enemies[i].hp_bar.Load(Content);
                enemies[i].sp_bar = new StatusBar(enemies[i].Get_Stamina(), StatusBar.STAMINA);
                enemies[i].sp_bar.Position = new Vector2(389, height - 61 + (i * 24));
                enemies[i].sp_bar.Load(Content);
                //Load Sprite
                enemies[i].Load(Content, enemies[i].Get_Name(), enemies[i].Get_Uniform(), 15, 4, framerate);
                enemies[i].Position = new Vector2(width - 40 - ((i % 2) * 150) + (i * 10) - enemies[i].Get_Width(), 330 + (i * 70) - enemies[i].Get_Height());
                enemies[i].Click += Char_was_Click;
            }
            
#region Menu Btn
            //next turn btn
            var btnNextTurn = new Button(Content.Load<Texture2D>(Button.Agent_Recharge));
            btnNextTurn.Position = new Vector2(((combat_background.Get_Width() - btnNextTurn.Get_Width()) / 2) + ((4 - 0) * (btnNextTurn.Get_Width() + 8)) - (btnNextTurn.Get_Width() / 2), 496);
            menuComponent.Add(btnNextTurn);
            btnNextTurn.Set_Name(Button.Agent_Recharge);
            btnNextTurn.Click += BtnMenu_Click;

            var btnInventory = new Button(Content.Load<Texture2D>(Button.Agent_Inventory));
            btnInventory.Position = new Vector2(((combat_background.Get_Width() - btnInventory.Get_Width()) / 2) + ((4 - 1) * (btnInventory.Get_Width() + 8)) - (btnInventory.Get_Width() / 2), 496);
            menuComponent.Add(btnInventory);
            btnInventory.Set_Name(Button.Agent_Inventory);
            btnInventory.Click += BtnMenu_Click;

            var btnCall = new Button(Content.Load<Texture2D>(Button.Agent_Distress_Call));
            btnCall.Position = new Vector2(((combat_background.Get_Width() - btnCall.Get_Width()) / 2) + ((4 - 2) * (btnCall.Get_Width() + 8)) - (btnCall.Get_Width() / 2), 496);
            menuComponent.Add(btnCall);
            btnCall.Set_Name(Button.Agent_Distress_Call);
            btnCall.Click += BtnMenu_Click;

            var btnArc = new Button(Content.Load<Texture2D>(Button.Arc_Reactor_Charge));
            btnArc.Position = new Vector2(((combat_background.Get_Width() - btnArc.Get_Width()) / 2) + ((4 - 3) * (btnArc.Get_Width() + 8)) - (btnArc.Get_Width() / 2), 496);
            menuComponent.Add(btnArc);
            btnArc.Set_Name(Button.Arc_Reactor_Charge);
            btnArc.Click += BtnMenu_Click;
#endregion
            //set turn base
            for(int i = 0; i < Math.Max(teams.Count, enemies.Count); i++)
            {
                heroes.Add(teams[i]);
                heroes.Add(enemies[i]);
            }

            for(int i = 0; i < heroes.Count - 1; i++)
            {
                heroes[i].next = heroes[i + 1];
            }

            heroes[current].Set_Focus(true);
        }

        private void Char_was_Click(object sender, EventArgs e)
        {
            if (!pick_skill) return;

            if (heroes[current].current_attack.Get_Target() == TargetType.One_Enemy)
            {
                heroes[current].targets.Add(((Character)sender).Get_Me());
            }
            else
            {
                foreach (var target in enemies)
                    heroes[current].targets.Add(target);
            }

            heroes[current].SkillAction();
            /*if (heroes[current].isattacking)
            {
                foreach (var avatar in heroes)
                    avatar.Set_Focus(true);
            }*/
            if (current > heroes.Count - ((MAAGame.PLAYER % 2) + 1)) current = 0;
            /*else current += ((MAAGame.PLAYER % 2) + 1);*/
            heroes[current].Set_Focus(true);

            pick_skill = false;
        }
        
        bool pick_skill = false;

        private void BtnAttack_Click(object sender, EventArgs e)
        {
            heroes[current].current_attack = ((Button)sender).Get_Attack();
            Console.Out.WriteLine(heroes[current].current_attack.Get_Name() + "Was Click!!!");
            pick_skill = true;
            foreach (var avatar in heroes)
                avatar.Set_Focus(false);
            heroes[current].Set_Focus(true);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            string btnname = ((Button)sender).Get_Name();

            switch (btnname)
            {
                case Button.Agent_Recharge :
                    {
                        heroes[current].Set_Focus(false);
                        /*if (current >= heroes.Count - 1) current = 0;
                        else current++;*/
                        if (current >= heroes.Count - 1) current = 0;
                        else current++;
                        heroes[current].Set_Focus(true);
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
            base.UnloadContent();
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
            foreach (var avatar in heroes)
                avatar.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var component in skillComponents[current])
                component.Update(gameTime);

            foreach (var component in menuComponent)
                component.Update(gameTime);

            foreach(var avatar in heroes)
            {
                avatar.UpdateFrame(elapsed);
                avatar.Update(Content, gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            combat_background.Draw(spriteBatch);

            empty_status_bar.Draw(spriteBatch);

            foreach (var component in skillComponents[current])
                component.Draw(gameTime, spriteBatch);

            foreach (var component in menuComponent)
                component.Draw(gameTime, spriteBatch);
            
            foreach(var avatar in heroes)
                avatar.Draw(gameTime, spriteBatch);

            if (heroes[current].targets.Count == 0 || heroes[current].current_position.X <= teams[1].Position.X + teams[1].frame_width)
            {
                foreach (var avatar in heroes)
                {
                    if (avatar.Position.X <= width / 2) avatar.DrawFrame(spriteBatch);
                    else avatar.DrawFrameFlip(spriteBatch);
                }
                spriteBatch.End();
                base.Draw(gameTime);
                return;
            }
            else
            {
                /*for (int i = 0; i < heroes.Count; i++)
                {
                    if (heroes[i].Position.X <= width / 2) heroes[i].DrawFrame(spriteBatch);
                    else heroes[i].DrawFrameFlip(spriteBatch);

                    if (heroes[current].targets[0].Position.Y < heroes[current].Position.Y && heroes[current].targets[0].Position.Y == heroes[0].Position.Y)    //target up
                    {
                        if (heroes[3].Position.X <= width / 2) heroes[3].DrawFrame(spriteBatch);
                        else heroes[3].DrawFrameFlip(spriteBatch);
                    }
                    else

                    /*if(heroes[current].targets[0].Position.Y <= teams[0].Position.Y && i < 1)
                    {
                        if (heroes[current].Position.X <= width / 2) heroes[current].DrawFrame(spriteBatch);
                        else heroes[current].DrawFrameFlip(spriteBatch);
                    }else

                    if (heroes[current].targets[0].Position.Y > heroes[current].Position.Y && i == heroes.Count - 1)    //target down
                    {
                        if (heroes[current].Position.X <= width / 2) heroes[current].DrawFrame(spriteBatch);
                        else heroes[current].DrawFrameFlip(spriteBatch);
                    }
                }*/
                for(int i = 0; i < heroes.Count; i++)
                {
                    if (heroes[i].Position.X <= width / 2) heroes[i].DrawFrame(spriteBatch);
                    else heroes[i].DrawFrameFlip(spriteBatch);

                    if ((heroes[current].Position.Y == heroes[0].Position.Y || heroes[current].Position.Y == heroes[2].Position.Y) && heroes[current].targets[0].Position.Y == heroes[5].Position.Y)    //Form \
                    {
                        if (heroes[current].Position.X <= width / 2) heroes[current].DrawFrame(spriteBatch);
                        else heroes[current].DrawFrameFlip(spriteBatch);
                    }else
                    /*if(heroes[current].Position.Y == heroes[2].Position.Y && heroes[current].targets[0].Position.Y == heroes[5].Position.Y)
                    {
                        if (heroes[current].Position.X <= width / 2) heroes[current].DrawFrame(spriteBatch);
                        else heroes[current].DrawFrameFlip(spriteBatch);
                    }
                    else*/
                    if (heroes[current].Position.Y == heroes[4].Position.Y && heroes[current].targets[0].Position.Y == heroes[1].Position.Y)    //Form /
                    {
                        if (heroes[3].Position.X <= width / 2) heroes[3].DrawFrame(spriteBatch);
                        else heroes[3].DrawFrameFlip(spriteBatch);
                    }
                }
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void Set_Windows_size(int w, int h)
        {
            this.width = w;
            this.height = h;

            graphics.PreferredBackBufferWidth = w;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = h;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }
    }
}
