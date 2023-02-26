using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JET.View.BurgerMenu
{
    public class BurgerMenuFlyoutMenuItem
    {
        public BurgerMenuFlyoutMenuItem()
        {
            TargetType = typeof(BurgerMenuFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}