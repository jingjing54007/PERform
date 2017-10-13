namespace PERform.Models
{
    public interface ISnippet
    {
        string Header { get; set; }
        PEREditor PerEditor { get; }

        void Rename(string newHeader);
    }
}
