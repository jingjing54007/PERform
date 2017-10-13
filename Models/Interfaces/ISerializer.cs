namespace PERform.Models
{
    public interface ISerializer
    {
        void Serialize(object obj, string path);
        object Deserialize(string path);
    }
}
