using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class LocalFileSystem : IFileSystem
{
    private string _path = string.Empty;
    private DirectoryInfo? _directory;

    public void Connect(string address)
    {
        _directory = new DirectoryInfo(address);
        _path = address;
    }

    public void Disconnect()
    {
        _directory = null;
    }

    public void TreeGoto(string path)
    {
        _path = path;
    }

    public void TreeList(int depth)
    {
        throw new System.NotImplementedException();
    }

    public void FileShow(string address)
    {
        throw new System.NotImplementedException();
    }

    public void FileMove(string addressFrom)
    {
        throw new NotImplementedException();
    }

    public void FileMove(string addressFrom, string addressTo)
    {
        throw new System.NotImplementedException();
    }

    public void FileCopy(string addressFrom, string addressTo)
    {
        throw new System.NotImplementedException();
    }

    public void FileDelete(string address)
    {
        throw new System.NotImplementedException();
    }

    public void FileRename(string address, string newName)
    {
        throw new System.NotImplementedException();
    }
}