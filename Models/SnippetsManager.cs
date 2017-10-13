using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System;
using System.Windows;

namespace PERform.Models
{
    public class SnippetsManager : Notifier
    {

        public SnippetsManager()
        {
            SnippetsCollection = new ObservableCollection<SnippetParent>((App.Current as App).SerializedSnippetParents);

            //pass SnippetsCollection reference to app.xaml.cs so it will be serialized on 
            //Application.Exit event (consider replacing with built-in resource file)
            (App.Current as App).SerializedSnippetParents = SnippetsCollection;
        }

        public ObservableCollection<SnippetParent> SnippetsCollection { get; }

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
