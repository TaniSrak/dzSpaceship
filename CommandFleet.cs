using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzSpaceship
{
    internal class CommandFleet : Fleet
    {
        public string CommanderName { get; set; } // Имя командующего
        public string Rank { get; set; } // Звание
        public int Experience { get; set; } // Опыт
    }
}
