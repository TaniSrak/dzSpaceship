using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace dzSpaceship
{
    public class Fleet : IFleetOperations
    {
        //храним корабль и миссии в коллекциях
        protected List<Spaceship> spaceships = new List<Spaceship>();
        protected List<Mission> missions = new List<Mission>();
        protected Dictionary<int, List<Mission>> spaceshipMissions = new Dictionary<int, List<Mission>>();

        public void AddSpaceship(Spaceship spaceship)
        {
            spaceships.Add(spaceship);
        }

        public void RemoveSpaceship(int id)
        {
            spaceships.RemoveAll(s => s.Id == id);
            spaceshipMissions.Remove(id);
        }

        public void AssignMission(int spaceshipId, Mission mission)
        {
            if (!spaceshipMissions.ContainsKey(spaceshipId))
            {
                spaceshipMissions[spaceshipId] = new List<Mission>();
            }
            spaceshipMissions[spaceshipId].Add(mission);
            missions.Add(mission);
        }

        //поиск корабля
        public IEnumerable<Spaceship> FindSpaceships(Func<Spaceship, bool> predicate)
        {
            return spaceships.Where(predicate);
        }

        //все миссии одного корабля
        public IEnumerable<Mission> GetMissionsForSpaceship(int spaceshipId)
        {
            if (spaceshipMissions.ContainsKey(spaceshipId))
            {
                return spaceshipMissions[spaceshipId];
            }
            return Enumerable.Empty<Mission>();
        }

        //сохранения списка кораблей в файл
        public void SaveSpaceshipsToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(spaceships, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // загрузка списка кораблей из файла
    public void LoadSpaceshipsFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            spaceships = JsonConvert.DeserializeObject<List<Spaceship>>(json);
        }

        //сохранение списка миссий в файл
        public void SaveMissionsToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(missions, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        //загрузка миссий из файла
        public void LoadMissionsFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            missions = JsonConvert.DeserializeObject<List<Mission>>(json);
        }

    }


}
