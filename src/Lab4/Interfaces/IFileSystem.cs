namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IFileSystem
{
    public void Connect(string address);
    public void Disconnect();
    public void TreeGoto(string path);
    public void TreeList(int depth);
    public void FileShow(string path);
    public void FileMove(string sourcePath, string destinationPath);
    public void FileCopy(string sourcePath, string destinationPath);
    public void FileDelete(string path);
    public void FileRename(string path, string newName);
}