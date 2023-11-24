using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class LocalFileSystem : IFileSystem, IRootedPath
{
    private string _path = string.Empty;
    private DirectoryInfo? _directory;
    private FileInfo? _file;

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
        _directory = new DirectoryInfo(_path);
    }

    public void TreeList(int depth)
    {
        if (_directory is not null) BuildTree(_directory, depth, 0);
    }

    public void FileShow(string path)
    {
        if (!IsPathExists(path)) return;
        string fullPath = _path + '/' + path;
        Console.WriteLine(File.ReadAllText(fullPath));
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        _file = new FileInfo(sourcePath);
        if (_file.Exists)
        {
            _file.MoveTo(destinationPath + '/' + _file.Name);
        }
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        _file = new FileInfo(sourcePath);
        if (_file.Exists)
        {
            _file.CopyTo(destinationPath);
        }
    }

    public void FileDelete(string path)
    {
        _file = new FileInfo(path);
        if (_file.Exists)
        {
            _file.Delete();
        }
    }

    public void FileRename(string path, string newName)
    {
        _file = new FileInfo(path);
        if (_file.Exists)
        {
            File.Move(_file.Name, newName);
        }
    }

    public void BuildTree(DirectoryInfo dir, int depth, int tabCount)
    {
        if (dir is null) throw new ArgumentNullException(nameof(dir));
        if (depth == 0) return;
        depth--;
        tabCount++;
        foreach (DirectoryInfo s in dir.GetDirectories())
        {
            for (int i = 0; i < tabCount; i++) Console.Write("\t");
            Console.WriteLine(s.Name);
            BuildTree(s, depth, tabCount);
        }

        foreach (FileInfo z in dir.GetFiles())
        {
            for (int i = 0; i < tabCount; i++) Console.Write("\t");
            Console.WriteLine(z.Name);
        }
    }

    public bool IsRooted(string path)
    {
        if (!string.IsNullOrEmpty(path) && path[0] == '/') return true;
        return false;
    }

    public bool IsPathExists(string path)
    {
        return Directory.Exists(_path + '/' + path);
    }
}