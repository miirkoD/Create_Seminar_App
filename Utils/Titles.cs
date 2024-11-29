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
            dateCreated = DateTime.Now;
        }

        public static string GetFilePath()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string utilsFolder = Path.Combine(projectDirectory, "Utils");
            if (!Directory.Exists(utilsFolder))
            {
                Directory.CreateDirectory(utilsFolder);
            }
            return Path.Combine(utilsFolder, "titles.json");
        }
        public void SaveData(List<Titles> list)
        {
            string filePath=GetFilePath();
            string json = JsonSerializer.Serialize(list,new JsonSerializerOptions { WriteIndented=true});
            File.WriteAllText(filePath, json);
        }

        public static List<Titles> LoadData()
        {
            string filePath=GetFilePath();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Titles>>(json);
            }
            return new List<Titles>();
        }
    }
}
