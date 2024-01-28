using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class Achievement : BaseEntity
    {
        public int RaceWin { get; set; }
        public int PolePosition { get; set; }
        public int FastedLap { get; set; }
        public int WorldChampionShip { get; set; }
        public Guid DriverId { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
