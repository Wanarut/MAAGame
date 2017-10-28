using MAAModule.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule.Chars
{
    class Ant_Man : Character
    {
        public Ant_Man()
        {
        #region Set Stat
            this.name = "Ant-Man";
            this.alternate_uniform = "Ant-Man-Modern";
            this.health = 6438;
            this.stamina = 7868;
            this.attack = 1431;
            this.defense = 1288;
            this.accuracy = 1431;
            this.evasion = 1574;
            this._class = Character.CLASS_Infiltrator;
        #endregion

        #region Set 1st Attack
            Attack skill = new Attack("Ant-Man-Break_In");
            skill.Set_Stamina_Cost(18);
            skill.Set_Num_Target(TargetType.One_Enemy);
            skill.Set_Min_Damage(1072);
            skill.Set_Max_Damage(1286);
            skill.Set_Cooldown(0);
            skill.Set_Hits_Num(2);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            this.attacks.Add(skill);
        #endregion

        #region Set 2nd Attack
            skill = new Attack("Ant-Man-Greatest_Allies");
            skill.Set_Stamina_Cost(5);
            skill.Set_Num_Target(TargetType.All_Enemies);
            skill.Set_Min_Damage(241);
            skill.Set_Max_Damage(288);
            skill.Set_Cooldown(1);
            skill.Set_Hits_Num(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            this.attacks.Add(skill);
            #endregion

        #region Set 3rd Attack
            skill = new Attack("Ant-Man-Pint-Size_Surprise");
            skill.Set_Stamina_Cost(23);
            skill.Set_Num_Target(TargetType.One_Enemy);
            skill.Set_Min_Damage(1146);
            skill.Set_Max_Damage(1375);
            skill.Set_Cooldown(0);
            skill.Set_Hits_Num(1);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            this.attacks.Add(skill);
        #endregion

        #region Set 4th Attack
            skill = new Attack("Ant-Man-Swarm_Cloud");
            skill.Set_Stamina_Cost(5);
            skill.Set_Num_Target(TargetType.One_Enemy);
            skill.Set_Min_Damage(510);
            skill.Set_Max_Damage(612);
            skill.Set_Cooldown(1);
            skill.Set_Hits_Num(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            this.attacks.Add(skill);
        #endregion
        }
    }
}
