using System.Collections.ObjectModel;

namespace PERform.Models
{
    public interface ISerializer
    {
        void Serialize(ObservableCollection<SnippetParent> obj, string path);
        ObservableCollection<SnippetParent> Deserialize(string path);
    }
}
