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
            SnippetsCollection = new ObservableCollection<SnippetParent>();
        }

        public ObservableCollection<SnippetParent> SnippetsCollection { get; set; }

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
    }
}
