using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TP_DotNet.JSON
{
    public static class JsonCreator
    {
        public static void CreateJson()
        {
            // Prüfe ob JSON existiert
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python"));
            string jsonfile = Path.GetFullPath(Path.Combine(path, "runData.json"));

            if (!File.Exists(jsonfile))
            {
                // Create new JSON
                var jsonFile = File.Create(jsonfile);
                jsonFile.Close();
                var runs = new JSON_Data();
                runs.Runs.Add(new Run());

                string inhalt = JsonConvert.SerializeObject(runs);
                File.WriteAllText(jsonfile, inhalt);

            }

            else
            {
               // Add a new Run to Existing JSON

                string text = File.ReadAllText(jsonfile);
                JSON_Data inhalt = JsonConvert.DeserializeObject<JSON_Data>(text);
                inhalt.Runs.Add(new Run());

                File.WriteAllText(jsonfile, JsonConvert.SerializeObject(inhalt));
            }
        }

        public static string JsonPath()
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python"));
            return Path.GetFullPath(Path.Combine(path, "runData.json"));
        }
    }
}
