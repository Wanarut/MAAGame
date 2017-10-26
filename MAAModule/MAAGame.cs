using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace MAAModule
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MAAGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        protected int width;
        protected int height;

        private List<Character> teams = new List<Character>();
        private List<Character> enemies = new List<Character>();
        private List<List<Component>> skillComponents = new List<List<Component>>();
        private Component next;
        private Component btn_1st_skill;
        private Component btn_2nd_skill;
        private Component btn_3rd_skill;
        private Component btn_4th_skill;
        private List<Character> turnbase = new List<Character>();
        private int currentturn = 0;

        Background combat_background = new Background();

        public MAAGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Skill skill_lib = new Skill();
            //Start with 3 your Heroes and set hero's state
            teams.Add(Character.Dr_Strange);
            teams.Add(Character.Ant_Man);
            teams.Add(Character.Deadpool);
            //Set 3 Villains and set villain's state
            enemies.Add(Character.Hulk);
            enemies.Add(Character.Cable);
            enemies.Add(Character.Captain_America);

            //Set background
            combat_background = new Background("Combat_Background_024");
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            combat_background = new Background(Content.Load<Texture2D>("Combat_Background/" + combat_background.Get_Name()));

            setWindows_size(combat_background.Get_Width(), combat_background.Get_Height());
            
            for (int i = 0; i < teams.Count; i++)
            {
                List<Component> temp = new List<Component>();
                for (int j = 0; j < teams[i].skills.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + teams[i].Get_Name() + "/" + teams[i].skills[j].Get_Name()));
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 2) * (btnskill.Get_Width() + 50)) + 50, 450);
                    temp.Add(btnskill);
                    btnskill.Click += btnskill_Click;
                }
                skillComponents.Add(temp);

                teams[i] = new Character(Content.Load<Texture2D>("Character/" + teams[i].Get_Name() + "/" + teams[i].Get_subName()));
                teams[i].position = new Vector2(40 + ((i % 2) * 150) - (i * 10), 330 + (i * 70) - teams[i].Get_Height());
            }

            for (int i = 0; i < teams.Count; i++)
            {
                List<Component> temp = new List<Component>();
                for (int j = 0; j < enemies[i].skills.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + enemies[i].Get_Name() + "/" + enemies[i].skills[j].Get_Name()));
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 2) * (btnskill.Get_Width() + 50)) + 50, 450);
                    temp.Add(btnskill);
                    btnskill.Click += btnskill_Click;
                }
                skillComponents.Add(temp);

                enemies[i] = new Character(Content.Load<Texture2D>("Character/" + enemies[i].Get_Name() + "/" + enemies[i].Get_subName()));
                enemies[i].position = new Vector2(width - 40 - ((i % 2) * 150) + (i * 10) - enemies[i].Get_Width(), 330 + (i * 70) - enemies[i].Get_Height());
            }

            var btnNextTurn = new Button(Content.Load<Texture2D>("Character/Agent/Agent_Recharge"));
            btnNextTurn.Position = new Vector2((combat_background.Get_Width() - btnNextTurn.Get_Width()) / 2, 500);
            btnNextTurn.Click += btnNextTurn_Click;
            
            next = btnNextTurn;

            //set turn base
            foreach (Character avatar in teams)
                turnbase.Add(avatar);

            foreach (Character avatar in enemies)
                turnbase.Add(avatar);

            turnbase[0].YourTurn(true);
            // TODO: use this.Content to load your game content here
        }

        private void btnskill_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNextTurn_Click(object sender, EventArgs e)
        {
            turnbase[currentturn].YourTurn(false);

            if (currentturn == turnbase.Count - 1) currentturn = 0;
            else currentturn++;

            turnbase[currentturn].YourTurn(true);
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
            try
            {
                foreach (var component in skillComponents[currentturn])
                    component.Update(gameTime);
            }
            catch
            {

            }
            next.Update(gameTime);

            foreach (var hero in teams)
                hero.Update();

            foreach (var villain in enemies)
                villain.Update();

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
            try
            {
                foreach (var component in skillComponents[currentturn])
                    component.Draw(gameTime, spriteBatch);
            }
            catch
            {

            }
            next.Draw(gameTime, spriteBatch);

            /*foreach (var avatar in turnbase)
                avatar.Draw(spriteBatch);*/

            foreach (var hero in teams)
                hero.Draw(spriteBatch);

            foreach (var villain in enemies)
                villain.DrawFlip(spriteBatch);

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
