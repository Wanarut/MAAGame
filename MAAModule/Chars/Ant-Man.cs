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
            Attack AntManBreakIn = new Attack("Ant-Man-Break_In");
            AntManBreakIn.Set_Stamina_Cost(18);
            AntManBreakIn.Set_Num_Target(TargetType.One_Enemy);
            AntManBreakIn.Set_Min_Damage(1072);
            AntManBreakIn.Set_Max_Damage(1286);
            AntManBreakIn.Set_Cooldown(0);
            AntManBreakIn.Set_Hits_Num(2);
            AntManBreakIn.Set_Hits_Chance(88);
            AntManBreakIn.Set_Cri_Chance(11);

            this.attacks.Add(AntManBreakIn);
#endregion

#region Set 2nd Attack
            Attack AntManGreatestAllies = new Attack("Ant-Man-Greatest_Allies");
            AntManGreatestAllies.Set_Stamina_Cost(5);
            AntManGreatestAllies.Set_Num_Target(TargetType.All_Enemies);
            AntManGreatestAllies.Set_Min_Damage(241);
            AntManGreatestAllies.Set_Max_Damage(288);
            AntManGreatestAllies.Set_Cooldown(1);
            AntManGreatestAllies.Set_Hits_Num(1);
            AntManGreatestAllies.Set_Hits_Chance(100);
            AntManGreatestAllies.Set_Cri_Chance(60);

            this.attacks.Add(AntManGreatestAllies);
            #endregion

#region Set 3rd Attack
            Attack AntManPintSizeSurprise = new Attack("Ant-Man-Pint-Size_Surprise");
            AntManPintSizeSurprise.Set_Stamina_Cost(23);
            AntManPintSizeSurprise.Set_Num_Target(TargetType.One_Enemy);
            AntManPintSizeSurprise.Set_Min_Damage(1146);
            AntManPintSizeSurprise.Set_Max_Damage(1375);
            AntManPintSizeSurprise.Set_Cooldown(0);
            AntManPintSizeSurprise.Set_Hits_Num(1);
            AntManPintSizeSurprise.Set_Hits_Chance(88);
            AntManPintSizeSurprise.Set_Cri_Chance(11);

            this.attacks.Add(AntManPintSizeSurprise);
            #endregion

#region Set 4th Attack
            Attack AntManSwarmCloud = new Attack("Ant-Man-Swarm_Cloud");
            AntManSwarmCloud.Set_Stamina_Cost(5);
            AntManSwarmCloud.Set_Num_Target(TargetType.One_Enemy);
            AntManSwarmCloud.Set_Min_Damage(510);
            AntManSwarmCloud.Set_Max_Damage(612);
            AntManSwarmCloud.Set_Cooldown(1);
            AntManSwarmCloud.Set_Hits_Num(1);
            AntManSwarmCloud.Set_Hits_Chance(100);
            AntManSwarmCloud.Set_Cri_Chance(60);

            this.attacks.Add(AntManSwarmCloud);
#endregion
        }
    }
}
