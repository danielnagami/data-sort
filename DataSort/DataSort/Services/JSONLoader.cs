using DataSort.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataSort.Services
{
    public class JSONLoader
    {
        public static int[] GetTheArray(int type, IList<Image> imageList)
        {
            int[] array = new int[imageList.Count];
            if (type == 2)
            {
                int i = 0;
                foreach (var item in imageList)
                {
                    array[i] = (int)item.Latitude;
                    i++;
                }
                return array;
            }
            else
            {
                int i = 0;
                foreach (var item in imageList)
                {
                    array[i] = (int)item.Longitude;
                    i++;
                }
                return array;

            }
        }

        public static Image[] ReadJSON()
        {
            string jsonString = "";
            if (File.Exists($"{Directory.GetCurrentDirectory()}/randomicJson.json"))
            {
                jsonString = File.ReadAllText($"{Directory.GetCurrentDirectory()}/randomicJson.json");
                return JsonConvert.DeserializeObject<Image[]>(jsonString);
            }
            return null;
        }
    }
}
