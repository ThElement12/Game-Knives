using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class ClassComparer : IComparer<PlayerStats>
    {
        public int Compare(PlayerStats x, PlayerStats y)
        {
            return x.Points.CompareTo(y.Points);
        }
    }
}
