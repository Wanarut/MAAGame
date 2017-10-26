using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule
{
    class Skill
    {
        private string name;
        private int stamina_cost;
        private int num_target;
        private int total_damage;
        private int cooldown;
        private int num_hits;

        public Skill(string name, int stamina_cost, int num_target, int total_damage, int cooldown, int num_hits)
        {
            this.name = name;
            this.stamina_cost = stamina_cost;
            this.num_target = num_target;
            this.total_damage = total_damage;
            this.cooldown = cooldown;
            this.num_hits = num_hits;
        }

        public string Get_Name()
        {
            return name;
        }
    }
}
