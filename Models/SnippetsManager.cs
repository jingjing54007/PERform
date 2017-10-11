using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models
{
    public class SnippetsManager : Notifier
    {
        public SnippetsManager()
        {
            SnippetsCollection = new ObservableCollection<Snippet>();

            SnippetsCollection.Add(new Snippet("General", true));
        }

        public ObservableCollection<Snippet> SnippetsCollection { get; set; }

        public void Add(Snippet parentSnippet, string newHeader)
        {
            parentSnippet.Snippets.Add(new Snippet(newHeader, true));
        }

        public void Rename(Snippet snippet, string newHeader)
        {
            snippet?.Rename(newHeader);
        }

        public void Remove(Snippet snippet)
        {
            // TODO
        }
    }
}
