using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule.Model
{
    class TargetType
    {
        #region Target and Cooldown
        public const int Self = 0;
        public const int One_Ally = 1;
        public const int One_Enemy = 2;
        public const int All_Allies = 3;
        public const int All_Enemies = 4;
        #endregion
    }
}
