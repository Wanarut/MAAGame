using MAAModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule
{
    class Attack
    {
        #region Skills Data
        /*public static Attack Dr_Strange_Bolts_of_Balthakk = new Attack("Dr._Strange-Bolts_of_Balthakk", 19, Attack.One_Enemy, 1742, 2089, Attack.NA, 1);
        public static Attack Dr_Strange_Teresing_Boost = new Attack("Dr._Strange-Teresing_Boost", 23, Attack.All_Allies, Attack.NA, Attack.NA, 3, Attack.NA);
        public static Attack Dr_Strange_Vapors_of_Valtorr = new Attack("Dr._Strange-Vapors_of_Valtorr", 38, Attack.All_Enemies, 585, 703, Attack.NA, 1);
        public static Attack Dr_Strange_Shield_of_the_Seraphim = new Attack("Dr._Strange-Shield_of_the_Seraphim", 25, Attack.One_Ally, Attack.NA, Attack.NA, 2, Attack.NA);

        public static Attack Deadpool_Sharp_Pointy_Things = new Attack("Deadpool-Sharp_Pointy_Things", 13, Attack.One_Enemy, 1086, 1302, Attack.NA, 2);
        public static Attack Deadpool_Bang_Bang_Bang = new Attack("Deadpool-Bang_Bang_Bang!", 26, Attack.One_Enemy, 1150, 1600, Attack.NA, 25);
        public static Attack Deadpool_No_Holds_Barred = new Attack("Deadpool-No_Holds_Barred", 20, Attack.One_Enemy, 1779, 2313, Attack.NA, 3);
        public static Attack Deadpool_Happy_to_See_You = new Attack("Deadpool-Happy_to_See_You", 44, Attack.One_Enemy, 2382, 3573, 3, 3);

        public static Attack Cable_Plasma_Rifle = new Attack("Cable-Plasma_Rifle", 31, Attack.One_Enemy, 1364, 1636, Attack.NA, 1);
        public static Attack Cable_Bodyslide = new Attack("Cable-Bodyslide", 25, Attack.All_Enemies, 644, 772, Attack.NA, 4);
        public static Attack Cable_Askani_Arts = new Attack("Cable-Askani_Arts", 19, Attack.One_Enemy, 875, 1050, Attack.NA, 2);
        public static Attack Cable_Temporal_Shift = new Attack("Cable-Temporal_Shift", 25, Attack.One_Ally, Attack.NA, Attack.NA, 2, Attack.NA);

        public static Attack Ghost_Rider_Damnation_Chains = new Attack("Ghost_Rider-Damnation_Chains", 13, Attack.One_Enemy, 874, 1224, Attack.NA, 2);
        public static Attack Ghost_Rider_Penance_Stare = new Attack("Ghost_Rider-Penance_Stare", 20, Attack.One_Enemy, 723, 868, 2, 1);
        public static Attack Ghost_Rider_Highway_to_Hell = new Attack("Ghost_Rider-Highway_to_Hell", 18, Attack.One_Enemy, 1060, 1268, 3, 4);
        public static Attack Ghost_Rider_Burn_Out = new Attack("Ghost_Rider-Burn_Out", 20, Attack.All_Enemies, 544, 599, 3, 1);

        public static Attack Cyclops_Optic_Blast = new Attack("Cyclops-Optic_Blast", 20, Attack.One_Enemy, 920, 1379, Attack.NA, 1);
        public static Attack Cyclops_Exploit_Weakness = new Attack("Cyclops-Exploit_Weakness", 10, Attack.One_Enemy, 821, 986, Attack.NA, 1);
        public static Attack Cyclops_Evasive_Maneuvers = new Attack("Cyclops-Evasive_Maneuvers", 10, Attack.All_Allies, Attack.NA, Attack.NA, 3, Attack.NA);
        public static Attack Cyclops_Mega_Optic_Blast = new Attack("Cyclops-Mega_Optic_Blast", 30, Attack.All_Enemies, 530, 794, Attack.NA, 1);

        public static Attack Captain_America_Shield_Bash = new Attack("Captain_America-Shield_Bash", 18, Attack.One_Enemy, 868, 1388, Attack.NA, 1);
        public static Attack Captain_America_Leading_Strike = new Attack("Captain_America-Leading_Strike", 10, Attack.One_Enemy, 1066, 1279, Attack.NA, 1);
        public static Attack Captain_America_Shield_Throw = new Attack("Captain_America-Shield_Throw", 25, Attack.All_Enemies, 570, 855, Attack.NA, 1);
        public static Attack Captain_America_Shield_Guard = new Attack("Captain_America-Shield_Guard", 15, Attack.Self, Attack.NA, Attack.NA, 2, Attack.NA);

        public static Attack Ant_Man_Break_In = new Attack("Ant-Man-Break_In", 18, Attack.One_Enemy, 1072, 1286, Attack.NA, 2);
        public static Attack Ant_Man_Greatest_Allies = new Attack("Ant-Man-Greatest_Allies", 5, Attack.All_Enemies, 241, 288, 1, 1);
        public static Attack Ant_Man_Pint_Size_Surprise = new Attack("Ant-Man-Pint-Size_Surprise", 23, Attack.One_Enemy, 1146, 1375, Attack.NA, 1);
        public static Attack Ant_Man_Swarm_Cloud = new Attack("Ant-Man-Swarm_Cloud", 5, Attack.One_Enemy, 510, 612, 1, 1);

        public static Attack Hulk_Incredible_Rage_Punch = new Attack("Hulk-Incredible_Rage_Punch", 11, Attack.One_Enemy, 963, 1156, Attack.NA, 1);
        public static Attack Hulk_Monster_Size_Thunder_Clap = new Attack("Hulk-Monster-Size_Thunder_Clap", 17, Attack.All_Enemies, 483, 628, 1, 1);
        public static Attack Hulk_Indestructible_Titanic_Hurl = new Attack("Hulk-Indestructible_Titanic_Hurl", 33, Attack.All_Enemies, 244, 367, 1, 1);
        public static Attack Hulk_Giant_Size_Hulk_Smash = new Attack("Hulk-Giant-Size_Hulk_Smash", 22, Attack.One_Enemy, 1439, 2012, Attack.NA, 1);*/
        #endregion

#region Fields
        protected string name;
        protected int time_cast;
        protected int stamina_cost;
        protected int num_target;
        protected int min_damage;
        protected int max_damage;
        protected int cooldown;
        protected int hits_num;
        protected int hits_chance;
        protected int cri_chance;
        #endregion

#region Construcktor Function
        public Attack(string name)
        {
            this.name = name;
        }
#endregion

#region Set Attack Poperties
        public void Set_Time(int time_cast)
        {
            this.time_cast = time_cast;
        }

        public void Set_Stamina_Cost(int stamina_cost)
        {
            this.stamina_cost = stamina_cost;
        }

        public void Set_Num_Target(int num_target)
        {
            this.num_target = num_target;
        }

        public void Set_Min_Damage(int min_damage)
        {
            this.min_damage = min_damage;
        }

        public void Set_Max_Damage(int max_damage)
        {
            this.max_damage = max_damage;
        }
        public void Set_Cooldown(int cooldown)
        {
            this.cooldown = cooldown;
        }
        public void Set_Hits_Num(int hits_num)
        {
            this.hits_num = hits_num;
        }
        public void Set_Hits_Chance(int hits_chance)
        {
            this.hits_chance = hits_chance;
        }
        public void Set_Cri_Chance(int cri_chance)
        {
            this.cri_chance = cri_chance;
        }
        #endregion

#region Get Attack Poperties
        public int Get_Time()
        {
            return time_cast;
        }

        public string Get_Name()
        {
            return name;
        }

        public int Get_StaminaCost()
        {
            return stamina_cost;
        }

        public int Get_Target()
        {
            return num_target;
        }

        public int Get_MinDamage()
        {
            return min_damage;
        }

        public int Get_MaxDamage()
        {
            return max_damage;
        }

        public int Get_Cooldown()
        {
            return cooldown;
        }

        public int Get_NumberHits()
        {
            return hits_num;
        }

        public int Get_HitChance()
        {
            return hits_chance;
        }

        public int Get_CriticalChance()
        {
            return cri_chance; ;
        }
#endregion

        /*public Attack()
        {
            Character.Ant_Man.skills.Add(Attack.Ant_Man_Break_In);
            Character.Ant_Man.skills.Add(Attack.Ant_Man_Greatest_Allies);
            Character.Ant_Man.skills.Add(Attack.Ant_Man_Pint_Size_Surprise);
            Character.Ant_Man.skills.Add(Attack.Ant_Man_Swarm_Cloud);

            Character.Cable.skills.Add(Attack.Cable_Plasma_Rifle);
            Character.Cable.skills.Add(Attack.Cable_Bodyslide);
            Character.Cable.skills.Add(Attack.Cable_Askani_Arts);
            Character.Cable.skills.Add(Attack.Cable_Temporal_Shift);

            Character.Captain_America.skills.Add(Attack.Captain_America_Shield_Bash);
            Character.Captain_America.skills.Add(Attack.Captain_America_Leading_Strike);
            Character.Captain_America.skills.Add(Attack.Captain_America_Shield_Throw);
            Character.Captain_America.skills.Add(Attack.Captain_America_Shield_Guard);

            Character.Cyclops.skills.Add(Attack.Cyclops_Optic_Blast);
            Character.Cyclops.skills.Add(Attack.Cyclops_Exploit_Weakness);
            Character.Cyclops.skills.Add(Attack.Cyclops_Evasive_Maneuvers);
            Character.Cyclops.skills.Add(Attack.Cyclops_Mega_Optic_Blast);

            Character.Deadpool.skills.Add(Attack.Deadpool_Sharp_Pointy_Things);
            Character.Deadpool.skills.Add(Attack.Deadpool_Bang_Bang_Bang);
            Character.Deadpool.skills.Add(Attack.Deadpool_No_Holds_Barred);
            Character.Deadpool.skills.Add(Attack.Deadpool_Happy_to_See_You);

            Character.Dr_Strange.skills.Add(Attack.Dr_Strange_Bolts_of_Balthakk);
            Character.Dr_Strange.skills.Add(Attack.Dr_Strange_Teresing_Boost);
            Character.Dr_Strange.skills.Add(Attack.Dr_Strange_Vapors_of_Valtorr);
            Character.Dr_Strange.skills.Add(Attack.Dr_Strange_Shield_of_the_Seraphim);

            Character.Ghost_Rider.skills.Add(Attack.Ghost_Rider_Damnation_Chains);
            Character.Ghost_Rider.skills.Add(Attack.Ghost_Rider_Penance_Stare);
            Character.Ghost_Rider.skills.Add(Attack.Ghost_Rider_Highway_to_Hell);
            Character.Ghost_Rider.skills.Add(Attack.Ghost_Rider_Burn_Out);

            Character.Hulk.skills.Add(Attack.Hulk_Incredible_Rage_Punch);
            Character.Hulk.skills.Add(Attack.Hulk_Monster_Size_Thunder_Clap);
            Character.Hulk.skills.Add(Attack.Hulk_Indestructible_Titanic_Hurl);
            Character.Hulk.skills.Add(Attack.Hulk_Giant_Size_Hulk_Smash);
        }

        private Attack(string name, int stamina_cost, int num_target, int total_damage_min, int total_damage_max, int cooldown, int num_hits)
        {
            this.name = name;
            this.stamina_cost = stamina_cost;
            this.num_target = num_target;
            this.total_damage_min = total_damage_min;
            this.total_damage_max = total_damage_max;
            this.cooldown = cooldown;
            this.num_hits = num_hits;
        }*/
    }
}