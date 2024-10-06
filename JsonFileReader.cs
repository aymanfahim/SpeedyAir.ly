using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpeedyAir.ly
{
    internal class JsonFileReader
    {
        public static async Task<T> ReadJsonAsync<T>(string filePath)
        {
            CheckFileValid(filePath);

            using (FileStream stream = File.OpenRead(filePath))
            {
                try
                {
                    return await JsonSerializer.DeserializeAsync<T>(stream);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private static void CheckFileValid(string filePath)
        {
            File.Exists(filePath);
            //add more checks for ex:-if file has data or not
        }
    }
}
