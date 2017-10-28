using MAAModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule.Turn
{
    class MainPhase : MAAGame
    {
        private void btnskill_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            string btnname = ((Button)sender).Get_Name();

            switch (btnname)
            {
                case Button.Agent_Inventory:
                    {
                        //show Inventory Item
                        break;
                    }
            }
        }
    }
}
