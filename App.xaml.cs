using Newtonsoft.Json;
using PERform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PERform
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application, ISerializer
    {
        public ObservableCollection<SnippetParent> SerializedSnippetParents { get; set; } 

        private void AppExitEvent(object sender, ExitEventArgs e)
        {
            Serialize(SerializedSnippetParents, "AppData/serializer.txt");
        }

        private void AppStartupEvent(object sender, StartupEventArgs e)
        {
            SerializedSnippetParents = new ObservableCollection<SnippetParent>(Deserialize("AppData/serializer.txt") as ObservableCollection<SnippetParent>);
        }




        public void Serialize(object obj, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        public object Deserialize(string path)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<SnippetParent>>(File.ReadAllText(path));
        }

    }
}
