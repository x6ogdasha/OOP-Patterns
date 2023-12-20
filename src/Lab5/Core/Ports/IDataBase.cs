namespace Core.Ports;

public interface IDataBase
{
    public void Create();
    public void Read();
    public void Update();
    public void Delete();
}