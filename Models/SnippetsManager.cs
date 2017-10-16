using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System;
using System.Windows;
using PERform.Utilities;

namespace PERform.Models
{
    public class SnippetsManager : Notifier, ISerializer
    {

        public SnippetsManager()
        {
            SnippetsCollection = new ObservableCollection<SnippetParent>(Deserialize(PATHS.SnippetsPath));
            App.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
            Serialize(SnippetsCollection, PATHS.SnippetsPath);
        }

        public ObservableCollection<SnippetParent> SnippetsCollection { get; private set; }

        public void Add(ISnippet snippet, string header)
        {
            if (snippet is SnippetParent)
            {
                var parentSnippet = snippet as SnippetParent;
                parentSnippet.Childrens.Add(new SnippetChild() { Header = header });
            }
            else
            {
                SnippetsCollection.Add(new SnippetParent() { Header = header });
            }
        }

        public void Rename(ISnippet snippet, string newHeader)
        {
            snippet.Rename(newHeader);
        }

        public void Remove(ISnippet snippet)
        {
            if (snippet is SnippetParent)
            {
                SnippetsCollection.Remove(snippet as SnippetParent);
            }
            else
            {
                var snippetChild = snippet as SnippetChild;
                var snippetParent = (from snip in SnippetsCollection
                                    where snip.Childrens.Contains(snippetChild)
                                    select snip).FirstOrDefault();

                if (!snippetParent.Equals(null))
                {
                    snippetParent.Childrens.Remove(snippetChild);
                }
            }
        }

        public void Serialize(ObservableCollection<SnippetParent> obj, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        public ObservableCollection<SnippetParent> Deserialize(string path)
        {
            if (!File.Exists(path))
                return new ObservableCollection<SnippetParent>();
            else
                return JsonConvert.DeserializeObject<ObservableCollection<SnippetParent>>(File.ReadAllText(path));
        }
    }
}
