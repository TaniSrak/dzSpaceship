using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzSpaceship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // командный флот
            var fleet = new CommandFleet
            {
                CommanderName = "Джон Доу",
                Rank = "Адмирал",
                Experience = 20
            };

            var spaceship1 = new Spaceship { Id = 1, Name = "Энтерпрайз", Model = "Исследователь", Cost = 1000000 };
            var spaceship2 = new Spaceship { Id = 2, Name = "Вояджер", Model = "Разведчик", Cost = 750000 };

            fleet.AddSpaceship(spaceship1);
            fleet.AddSpaceship(spaceship2);

            // Создаем миссию и назначаем ее кораблю
            var mission1 = new Mission { Id = 1, Name = "Исследовать Альфа Центавра", Objective = "Исследование", StartDate = DateTime.Now };
            fleet.AssignMission(1, mission1);

            //ищем дорогой корабль
            var expensiveSpaceships = fleet.FindSpaceships(s => s.Cost > 800000);
            // получение миссии
            var missionsForEnterprise = fleet.GetMissionsForSpaceship(1);

            fleet.SaveSpaceshipsToJson("spaceships.json");
            fleet.SaveMissionsToJson("missions.json");

            Console.WriteLine("Дорогие корабли:");
            foreach (var ship in expensiveSpaceships)
            {
                Console.WriteLine($"Название: {ship.Name}, Модель: {ship.Model}, Стоимость: {ship.Cost}");
            }

            Console.WriteLine("\nМиссии корабля Энтерпрайз:");
            foreach (var mission in missionsForEnterprise)
            {
                Console.WriteLine($"Название миссии: {mission.Name}, Цель: {mission.Objective}, Дата начала: {mission.StartDate}");
            }
        }
    }
}
