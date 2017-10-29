using MAAModule.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule.Chars
{
    class NEW_HERO : Character  //Fix Name for Build New Hero
    {
        public NEW_HERO()   //Fix Constructure Name
        {
        #region Set Stat
            this.name = Hero.Ant_Man; //Fix Hero Name
            this.alternate_uniform = Suit.Ant_Man_Modern;    //Fix Hero's Form Name
            this.health = 999;     //Fix Health Point
            this.max_health = health;
            this.stamina = 999;    //Fix Stamina Point
            this.max_stamina = stamina;
            this.attack = 999;     //Fix Attack Point
            this.defense = 999;    //Fix Defense Point
            this.accuracy = 999;   //Fix Accuracy Point
            this.evasion = 999;    //Fix Evasion Point
            this._class = Character.CLASS_Generalist;   //Fix Class Type
        #endregion

        #region Set 1st Attack
            Attack skill = new Attack("AttackName");    //Fix Attack Name
            skill.Set_Time(5);                          //Fix Time Cast
            skill.Set_Stamina_Cost(100);                //Fix Stamina Cost Between 0 - 100 Percent
            skill.Set_Num_Target(TargetType.One_Enemy); //Fix # of Target
            skill.Set_Min_Damage(999);                  //Fix Minimum Damage of Attack
            skill.Set_Max_Damage(9999);                 //Fix Maximum Damage of Attack
            skill.Set_Cooldown(999);                    //Fix Cooldown Time
            skill.Set_Hits_Num(999);                    //Fix # of Hits Attack
            skill.Set_Hits_Chance(100);                 //Fix Hits Chance Between 0 - 100 Percent
            skill.Set_Cri_Chance(100);                  //Fix Critical Chance Between 0 - 100 Percent

            this.attacks.Add(skill);
            #endregion

        #region Set 2nd Attack
            skill = new Attack("AttackName");           //Fix Attack Name
            skill.Set_Time(5);                          //Fix Time Cast
            skill.Set_Stamina_Cost(100);                //Fix Stamina Cost Between 0 - 100 Percent
            skill.Set_Num_Target(TargetType.One_Enemy); //Fix # of Target
            skill.Set_Min_Damage(999);                  //Fix Minimum Damage of Attack
            skill.Set_Max_Damage(9999);                 //Fix Maximum Damage of Attack
            skill.Set_Cooldown(999);                    //Fix Cooldown Time
            skill.Set_Hits_Num(999);                    //Fix # of Hits Attack
            skill.Set_Hits_Chance(100);                 //Fix Hits Chance Between 0 - 100 Percent
            skill.Set_Cri_Chance(100);                  //Fix Critical Chance Between 0 - 100 Percent

            this.attacks.Add(skill);
            #endregion

        #region Set 3rd Attack
            skill = new Attack("AttackName");           //Fix Attack Name
            skill.Set_Time(5);                          //Fix Time Cast
            skill.Set_Stamina_Cost(100);                //Fix Stamina Cost Between 0 - 100 Percent
            skill.Set_Num_Target(TargetType.One_Enemy); //Fix # of Target
            skill.Set_Min_Damage(999);                  //Fix Minimum Damage of Attack
            skill.Set_Max_Damage(9999);                 //Fix Maximum Damage of Attack
            skill.Set_Cooldown(999);                    //Fix Cooldown Time
            skill.Set_Hits_Num(999);                    //Fix # of Hits Attack
            skill.Set_Hits_Chance(100);                 //Fix Hits Chance Between 0 - 100 Percent
            skill.Set_Cri_Chance(100);                  //Fix Critical Chance Between 0 - 100 Percent

            this.attacks.Add(skill);
            #endregion

        #region Set 4th Attack
            skill = new Attack("AttackName");           //Fix Attack Name
            skill.Set_Time(5);                          //Fix Time Cast
            skill.Set_Stamina_Cost(100);                //Fix Stamina Cost Between 0 - 100 Percent
            skill.Set_Num_Target(TargetType.One_Enemy); //Fix # of Target
            skill.Set_Min_Damage(999);                  //Fix Minimum Damage of Attack
            skill.Set_Max_Damage(9999);                 //Fix Maximum Damage of Attack
            skill.Set_Cooldown(999);                    //Fix Cooldown Time
            skill.Set_Hits_Num(999);                    //Fix # of Hits Attack
            skill.Set_Hits_Chance(100);                 //Fix Hits Chance Between 0 - 100 Percent
            skill.Set_Cri_Chance(100);                  //Fix Critical Chance Between 0 - 100 Percent

            this.attacks.Add(skill);
        #endregion
        }
    }
}
