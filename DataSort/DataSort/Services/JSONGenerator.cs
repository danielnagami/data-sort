using DataSort.Models;
using DataSort.Services.Sort;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DataSort.Services
{
    public class JSONGenerator : ISort
    {
        public void Execute(int[] array = null, int v1 = 0, int v2 = 0)
        {
            CreateJsonRandomFile(GenerateSateliteImage());

        }
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private Image[] GenerateSateliteImage()
        {
            int arrayLength = RandomNumber(5, 100);
            Image[] imageList = new Image[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                Image image = new Image();
                image.Latitude = RandomNumber(-180, 180);
                image.Longitude = RandomNumber(-90, 90);
                image.ScaneId = Guid.NewGuid().ToString();

                Random gen = new Random();
                int range = 10 * 365;
                DateTime randomDate = DateTime.Today.AddDays(-gen.Next(range))
                                                    .AddHours(RandomNumber(1, 23))
                                                    .AddMinutes(RandomNumber(0, 59));

                image.PassingDate = randomDate;

                imageList[i] = image;
            }

            return imageList;
        }

        private void CreateJsonRandomFile(Image[] imageListArray)
        {
            string jsonString = JsonConvert.SerializeObject(imageListArray);

            File.WriteAllText($"{Directory.GetCurrentDirectory()}/randomicJson.json", jsonString);
        }
    }
}
