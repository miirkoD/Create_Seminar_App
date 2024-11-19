using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace CreateSeminarApp.Utils
{
    internal class Titles
    {
        private string title { get; set; }
        private Font font { get; set;}
        private DateTime dateCreated { get; set; }

        public Titles(string title)
        {
            this.title = title;
        }

        public void SaveData(List<Titles> list)
        {
            string json = JsonSerializer.Serialize(list[0].title);
            File.WriteAllText("title.json",json);
        }

        public List<Titles> LoadData()
        {
            if (File.Exists("title.json"))
            {
                string json = File.ReadAllText("title.json");
                return JsonSerializer.Deserialize<List<Titles>>(json);
            }
            return new List<Titles>();
        }
    }
}
