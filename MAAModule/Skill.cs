using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule
{
    class Skill
    {
        #region Target and Cooldown
        public const int NA = 0;
        public const int Self = 1;
        public const int One_Ally = 1;
        public const int One_Enemy = -1;
        public const int All_Allies = 3;
        public const int All_Enemies = -3;
        #endregion

        #region Skills Data
        public static Skill Dr_Strange_Bolts_of_Balthakk = new Skill("Dr._Strange-Bolts_of_Balthakk", 19, Skill.One_Enemy, 1742, 2089, Skill.NA, 1);
        public static Skill Dr_Strange_Teresing_Boost = new Skill("Dr._Strange-Teresing_Boost", 23, Skill.All_Allies, Skill.NA, Skill.NA, 3, Skill.NA);
        public static Skill Dr_Strange_Vapors_of_Valtorr = new Skill("Dr._Strange-Vapors_of_Valtorr", 38, Skill.All_Enemies, 585, 703, Skill.NA, 1);
        public static Skill Dr_Strange_Shield_of_the_Seraphim = new Skill("Dr._Strange-Shield_of_the_Seraphim", 25, Skill.One_Ally, Skill.NA, Skill.NA, 2, Skill.NA);

        /*public static Skill Iron_Man_Repulsor_Cannons = new Skill("Iron_Man-Repulsor_Cannons", 19, Skill.One_Enemy, 656, 788, Skill.NA, 2);
        public static Skill Iron_Man_Missile_Bombardment = new Skill("Iron_Man-Missile_Bombardment", 22, Skill.All_Enemies, 374, 449, Skill.NA, 1);
        public static Skill Iron_Man_High_Energy_Laser = new Skill("Iron_Man-High_Energy_Laser", 28, Skill.All_Enemies, 769, 922, Skill.NA, 1);
        public static Skill Iron_Man_Heartbreaker_Unibeam = new Skill("Iron_Man-Heartbreaker_Unibeam", 39, Skill.One_Enemy, 1445, 1735, Skill.NA, 1);*/

        public static Skill Deadpool_Sharp_Pointy_Things = new Skill("Deadpool-Sharp_Pointy_Things", 13, Skill.One_Enemy, 1086, 1302, Skill.NA, 2);
        public static Skill Deadpool_Bang_Bang_Bang = new Skill("Deadpool-Bang_Bang_Bang!", 26, Skill.One_Enemy, 1150, 1600, Skill.NA, 25);
        public static Skill Deadpool_No_Holds_Barred = new Skill("Deadpool-No_Holds_Barred", 20, Skill.One_Enemy, 1779, 2313, Skill.NA, 3);
        public static Skill Deadpool_Happy_to_See_You = new Skill("Deadpool-Happy_to_See_You", 44, Skill.One_Enemy, 2382, 3573, 3, 3);

        public static Skill Cable_Plasma_Rifle = new Skill("Cable-Plasma_Rifle", 31, Skill.One_Enemy, 1364, 1636, Skill.NA, 1);
        public static Skill Cable_Bodyslide = new Skill("Cable-Bodyslide", 25, Skill.All_Enemies, 644, 772, Skill.NA, 4);
        public static Skill Cable_Askani_Arts = new Skill("Cable-Askani_Arts", 19, Skill.One_Enemy, 875, 1050, Skill.NA, 2);
        public static Skill Cable_Temporal_Shift = new Skill("Cable-Temporal_Shift", 25, Skill.One_Ally, Skill.NA, Skill.NA, 2, Skill.NA);

        public static Skill Ghost_Rider_Damnation_Chains = new Skill("Ghost_Rider-Damnation_Chains", 13, Skill.One_Enemy, 874, 1224, Skill.NA, 2);
        public static Skill Ghost_Rider_Penance_Stare = new Skill("Ghost_Rider-Penance_Stare", 20, Skill.One_Enemy, 723, 868, 2, 1);
        public static Skill Ghost_Rider_Highway_to_Hell = new Skill("Ghost_Rider-Highway_to_Hell", 18, Skill.One_Enemy, 1060, 1268, 3, 4);
        public static Skill Ghost_Rider_Burn_Out = new Skill("Ghost_Rider-Burn_Out", 20, Skill.All_Enemies, 544, 599, 3, 1);

        public static Skill Cyclops_Optic_Blast = new Skill("Cyclops-Optic_Blast", 20, Skill.One_Enemy, 920, 1379, Skill.NA, 1);
        public static Skill Cyclops_Exploit_Weakness = new Skill("Cyclops-Exploit_Weakness", 10, Skill.One_Enemy, 821, 986, Skill.NA, 1);
        public static Skill Cyclops_Evasive_Maneuvers = new Skill("Cyclops-Evasive_Maneuvers", 10, Skill.All_Allies, Skill.NA, Skill.NA, 3, Skill.NA);
        public static Skill Cyclops_Mega_Optic_Blast = new Skill("Cyclops-Mega_Optic_Blast", 30, Skill.All_Enemies, 530, 794, Skill.NA, 1);

        public static Skill Captain_America_Shield_Bash = new Skill("Captain_America-Shield_Bash", 18, Skill.One_Enemy, 868, 1388, Skill.NA, 1);
        public static Skill Captain_America_Leading_Strike = new Skill("Captain_America-Leading_Strike", 10, Skill.One_Enemy, 1066, 1279, Skill.NA, 1);
        public static Skill Captain_America_Shield_Throw = new Skill("Captain_America-Shield_Throw", 25, Skill.All_Enemies, 570, 855, Skill.NA, 1);
        public static Skill Captain_America_Shield_Guard = new Skill("Captain_America-Shield_Guard", 15, Skill.Self, Skill.NA, Skill.NA, 2, Skill.NA);

        public static Skill Ant_Man_Break_In = new Skill("Ant-Man-Break_In", 18, Skill.One_Enemy, 1072, 1286, Skill.NA, 2);
        public static Skill Ant_Man_Greatest_Allies = new Skill("Ant-Man-Greatest_Allies", 5, Skill.All_Enemies, 241, 288, 1, 1);
        public static Skill Ant_Man_Pint_Size_Surprise = new Skill("Ant-Man-Pint-Size_Surprise", 23, Skill.One_Enemy, 1146, 1375, Skill.NA, 1);
        public static Skill Ant_Man_Swarm_Cloud = new Skill("Ant-Man-Swarm_Cloud", 5, Skill.One_Enemy, 510, 612, 1, 1);

        public static Skill Hulk_Incredible_Rage_Punch = new Skill("Hulk-Incredible_Rage_Punch", 11, Skill.One_Enemy, 963, 1156, Skill.NA, 1);
        public static Skill Hulk_Monster_Size_Thunder_Clap = new Skill("Hulk-Monster-Size_Thunder_Clap", 17, Skill.All_Enemies, 483, 628, 1, 1);
        public static Skill Hulk_Indestructible_Titanic_Hurl = new Skill("Hulk-Indestructible_Titanic_Hurl", 33, Skill.All_Enemies, 244, 367, 1, 1);
        public static Skill Hulk_Giant_Size_Hulk_Smash = new Skill("Hulk-Giant-Size_Hulk_Smash", 22, Skill.One_Enemy, 1439, 2012, Skill.NA, 1);
        #endregion

        #region Fields
        private string name;
        private int stamina_cost;   //percent
        private int num_target;
        private int total_damage_min;
        private int total_damage_max;
        private int cooldown;
        private int num_hits;
        #endregion

        public Skill()
        {
            Character.Ant_Man.skills.Add(Skill.Ant_Man_Break_In);
            Character.Ant_Man.skills.Add(Skill.Ant_Man_Greatest_Allies);
            Character.Ant_Man.skills.Add(Skill.Ant_Man_Pint_Size_Surprise);
            Character.Ant_Man.skills.Add(Skill.Ant_Man_Swarm_Cloud);

            Character.Cable.skills.Add(Skill.Cable_Plasma_Rifle);
            Character.Cable.skills.Add(Skill.Cable_Bodyslide);
            Character.Cable.skills.Add(Skill.Cable_Askani_Arts);
            Character.Cable.skills.Add(Skill.Cable_Temporal_Shift);

            Character.Captain_America.skills.Add(Skill.Captain_America_Shield_Bash);
            Character.Captain_America.skills.Add(Skill.Captain_America_Leading_Strike);
            Character.Captain_America.skills.Add(Skill.Captain_America_Shield_Throw);
            Character.Captain_America.skills.Add(Skill.Captain_America_Shield_Guard);

            Character.Cyclops.skills.Add(Skill.Cyclops_Optic_Blast);
            Character.Cyclops.skills.Add(Skill.Cyclops_Exploit_Weakness);
            Character.Cyclops.skills.Add(Skill.Cyclops_Evasive_Maneuvers);
            Character.Cyclops.skills.Add(Skill.Cyclops_Mega_Optic_Blast);

            Character.Deadpool.skills.Add(Skill.Deadpool_Sharp_Pointy_Things);
            Character.Deadpool.skills.Add(Skill.Deadpool_Bang_Bang_Bang);
            Character.Deadpool.skills.Add(Skill.Deadpool_No_Holds_Barred);
            Character.Deadpool.skills.Add(Skill.Deadpool_Happy_to_See_You);

            Character.Dr_Strange.skills.Add(Skill.Dr_Strange_Bolts_of_Balthakk);
            Character.Dr_Strange.skills.Add(Skill.Dr_Strange_Teresing_Boost);
            Character.Dr_Strange.skills.Add(Skill.Dr_Strange_Vapors_of_Valtorr);
            Character.Dr_Strange.skills.Add(Skill.Dr_Strange_Shield_of_the_Seraphim);

            Character.Ghost_Rider.skills.Add(Skill.Ghost_Rider_Damnation_Chains);
            Character.Ghost_Rider.skills.Add(Skill.Ghost_Rider_Penance_Stare);
            Character.Ghost_Rider.skills.Add(Skill.Ghost_Rider_Highway_to_Hell);
            Character.Ghost_Rider.skills.Add(Skill.Ghost_Rider_Burn_Out);

            Character.Hulk.skills.Add(Skill.Hulk_Incredible_Rage_Punch);
            Character.Hulk.skills.Add(Skill.Hulk_Monster_Size_Thunder_Clap);
            Character.Hulk.skills.Add(Skill.Hulk_Indestructible_Titanic_Hurl);
            Character.Hulk.skills.Add(Skill.Hulk_Giant_Size_Hulk_Smash);
        }

        private Skill(string name, int stamina_cost, int num_target, int total_damage_min, int total_damage_max, int cooldown, int num_hits)
        {
            this.name = name;
            this.stamina_cost = stamina_cost;
            this.num_target = num_target;
            this.total_damage_min = total_damage_min;
            this.total_damage_max = total_damage_max;
            this.cooldown = cooldown;
            this.num_hits = num_hits;
        }

        public string Get_Name()
        {
            return name;
        }
    }
}
