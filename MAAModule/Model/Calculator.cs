using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule.Model
{
    class Calculator
    {
        public Calculator()
        {
        }

        public List<Character> StatCalculate(Character attacker, List<Character> attackeds)
        {
            foreach (Character attacked in attackeds)
            {
                Random rand = new Random();

                int total_damage = rand.Next(attacker.current_attack.Get_MinDamage(), attacker.current_attack.Get_MaxDamage() + 1) + attacker.Get_Attack() - attacked.Get_Defense();

                attacked.Set_Health(attacked.Get_Health() - total_damage);

                attacked.hp_bar.Set_Value(attacked.Get_Health());

                int stamina_cost = (attacker.current_attack.Get_StaminaCost() * attacker.Get_Max_Stamina()) / 100;

                attacker.Set_Stamina(attacker.Get_Stamina() - stamina_cost);

                attacker.sp_bar.Set_Value(attacker.Get_Stamina());
            }
            return attackeds;
        }

        /*public List<Character> SortPosition(List<Character> heroes)
        {
            for(int i = 0; i < heroes.Count; i++)
            {
                for(int j = 0;j < heroes.Count; j++)
                {
                    if()
                }
            }
        }*/
    }
}
