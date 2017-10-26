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

        private List<Character> heroes = new List<Character>();
        private List<Character> villains = new List<Character>();
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
            //Start with 3 your Heroes and set hero's state
            heroes.Add(new Character(Character.DrStrange, "Dr._Strange-Modern"));
            heroes[0].setState(2, 1, 5, 1, 5, 2, Character.CLASS_Infiltrator);

            heroes.Add(new Character(Character.Iron_Man, "Iron_Man-Mk_42_Armor"));
            heroes[1].setState(2, 2, 4, 4, 3, 2, Character.CLASS_Blaster);

            heroes.Add(new Character(Character.Deadpool, "Deadpool-Classic"));
            heroes[2].setState(4, 2, 5, 3, 3, 2, Character.CLASS_Scrapper);
            
            //set hero's skills and skill poperties
            heroes[0].skills.Add(new Skill("Dr._Strange-Bolts_of_Balthakk", 1, 1, 1, 1, 1));
            heroes[0].skills.Add(new Skill("Dr._Strange-Shield_of_the_Seraphim", 1, 1, 1, 1, 1));
            heroes[0].skills.Add(new Skill("Dr._Strange-Teresing_Boost", 1, 1, 1, 1, 1));
            heroes[0].skills.Add(new Skill("Dr._Strange-Vapors_of_Valtorr", 1, 1, 1, 1, 1));

            heroes[1].skills.Add(new Skill("Iron_Man-Repulsor_Cannons", 1, 1, 1, 1, 1));
            heroes[1].skills.Add(new Skill("Iron_Man-Missile_Bombardment", 1, 1, 1, 1, 1));
            heroes[1].skills.Add(new Skill("Iron_Man-High_Energy_Laser", 1, 1, 1, 1, 1));
            heroes[1].skills.Add(new Skill("Iron_Man-Heartbreaker_Unibeam", 1, 1, 1, 1, 1));

            heroes[2].skills.Add(new Skill("Deadpool-Bang_Bang_Bang!", 1, 1, 1, 1, 1));
            heroes[2].skills.Add(new Skill("Deadpool-No_Holds_Barred", 1, 1, 1, 1, 1));
            heroes[2].skills.Add(new Skill("Deadpool-Sharp_Pointy_Things", 1, 1, 1, 1, 1));
            heroes[2].skills.Add(new Skill("Deadpool-Happy_to_See_You", 1, 1, 1, 1, 1));
            //Set 3 Villains and set villain's state
            villains.Add(new Character(Character.Hela, "Hela"));
            villains[0].setState(5, 1, 3, 3, 4, 4, Character.CLASS_Tactician);
            villains.Add(new Character(Character.Sin, "Sin"));
            villains[1].setState(4, 4, 5, 3, 3, 4, Character.CLASS_Blaster);
            villains.Add(new Character(Character.Thanos, "Thanos"));
            villains[2].setState(4, 3, 4, 2, 5, 3, Character.CLASS_Bruiser);
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
            
            for (int i = 0; i < heroes.Count; i++)
            {
                List<Component> temp = new List<Component>();
                for (int j = 0; j < heroes[i].skills.Count; j++)
                {
                    var btnskill = new Button(Content.Load<Texture2D>("Character/" + heroes[i].Get_Name() + "/" + heroes[i].skills[j].Get_Name()));
                    btnskill.Position = new Vector2(((combat_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 2) * (btnskill.Get_Width() + 50)) + 50, 450);
                    temp.Add(btnskill);
                    btnskill.Click += btnskill_Click;
                }
                skillComponents.Add(temp);

                heroes[i] = new Character(Content.Load<Texture2D>("Character/" + heroes[i].Get_Name() + "/" + heroes[i].Get_subName()));
                heroes[i].position = new Vector2(40 + ((i % 2) * 150) - (i * 10), 330 + (i * 70) - heroes[i].Get_Height());
                
                villains[i] = new Character(Content.Load<Texture2D>("Character/" + villains[i].Get_Name() + "/" + villains[i].Get_subName()));
                villains[i].position = new Vector2(width - 40 - ((i % 2) * 150) + (i * 10) - villains[i].Get_Width(), 330 + (i * 70) - villains[i].Get_Height());
            }

            var btnNextTurn = new Button(Content.Load<Texture2D>("Character/Agent/Agent_Recharge"));
            btnNextTurn.Position = new Vector2((combat_background.Get_Width() - btnNextTurn.Get_Width()) / 2, 500);
            btnNextTurn.Click += btnNextTurn_Click;
            
            next = btnNextTurn;

            //set turn base
            foreach (Character avatar in heroes)
                turnbase.Add(avatar);

            foreach (Character avatar in villains)
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

            foreach (var hero in heroes)
                hero.Update();

            foreach (var villain in villains)
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

            foreach (var avatar in turnbase)
                avatar.Draw(spriteBatch);

            /*foreach (var hero in heroes)
                hero.Draw(spriteBatch);

            foreach (var villain in villains)
                villain.Draw(spriteBatch);*/

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
