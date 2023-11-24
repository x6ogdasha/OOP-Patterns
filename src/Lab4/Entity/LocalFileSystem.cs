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
        string currentPath = HandlePath(address);
        _directory = new DirectoryInfo(currentPath);
        _path = currentPath;
        Console.Write(_path + " ");
    }

    public void Disconnect()
    {
        _directory = null;
    }

    public void TreeGoto(string path)
    {
        string currentPath = HandlePath(path);
        _path = currentPath;
        _directory = new DirectoryInfo(_path);

        Console.Write(_path + " ");
    }

    public void TreeList(int depth)
    {
        if (_directory is not null) BuildTree(_directory, depth, 0);
        Console.Write(_path + " ");
    }

    public void FileShow(string path)
    {
        string currentPath = HandlePath(path);

        Console.WriteLine(File.ReadAllText(currentPath));

        Console.Write(_path + " ");
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        string currentSourcePath = HandlePath(sourcePath);
        string currentDestinationPath = HandlePath(destinationPath);
        _file = new FileInfo(currentSourcePath);

        if (_file.Exists)
        {
            _file.MoveTo(currentDestinationPath + '/' + _file.Name);
            Console.Write(_path + " ");
        }
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        string currentSourcePath = HandlePath(sourcePath);
        string currentDestinationPath = HandlePath(destinationPath);
        _file = new FileInfo(currentSourcePath);

        if (_file.Exists)
        {
            _file.CopyTo(currentDestinationPath + '/' + _file.Name);
            Console.Write(_path + " ");
        }
    }

    public void FileDelete(string path)
    {
        string currentPath = HandlePath(path);
        _file = new FileInfo(currentPath);
        if (_file.Exists)
        {
            _file.Delete();
            Console.Write(_path + " ");
        }
    }

    public void FileRename(string path, string newName)
    {
        string currentPath = HandlePath(path);
        _file = new FileInfo(currentPath);

        if (_file.Exists)
        {
            _file.MoveTo(_file.DirectoryName + '/' + newName);
            Console.Write(_path + " ");
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
        if (path is null) throw new ArgumentNullException(nameof(path));
        string[] s = path.Split('/');
        string newDirectory = s[0];
        if (!path.Contains('/', StringComparison.Ordinal)) return File.Exists(_path + '/' + path);
        return Directory.Exists(_path + '/' + newDirectory);
    }

    public string HandlePath(string path)
    {
        if (!IsRooted(path) && IsPathExists(path))
        {
            return _path + '/' + path;
        }

        return path;
    }
}