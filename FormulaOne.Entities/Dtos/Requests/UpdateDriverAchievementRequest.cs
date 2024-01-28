using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Requests
{
    public class UpdateDriverAchievementRequest
    {
        public Guid DriverId { get; set; }
        public int WorldChampionShip { get; set; }
        public int FastedLap { get; set; }
        public int PolePosition { get; set; }
        public int Wins { get; set; }
    }
}
