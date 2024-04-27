using System;
using System.IO;
using Newtonsoft.Json;

namespace HelloWorld
{

    public class Serializador
    {
        public void Serializar<T>(string nombreArchivo, T objeto)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                };

                string json = JsonConvert.SerializeObject(objeto, settings);
                File.WriteAllText(nombreArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al serializar el objeto: " + ex.Message);
            }

        }

        public T Deserializar<T>(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Deserializar el objeto: " + ex.Message);
            }
        }
    }

}
