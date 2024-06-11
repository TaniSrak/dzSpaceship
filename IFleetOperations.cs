using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzSpaceship
{
    public interface IFleetOperations
    {
        void AddSpaceship(Spaceship spaceship); //добавить корабль
        void RemoveSpaceship(int id); //удалить корабль
        void AssignMission(int spaceshipId, Mission mission); //назначить миссию корблю
    }

    public struct Spaceship
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Cost { get; set; } //стоимость
    }

    public struct Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; } //цель миссии
        public DateTime StartDate { get; set; } //дата начала
    }
}
