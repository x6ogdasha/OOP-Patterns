using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service;

public class SystemContext
{
    public IFileSystem? FileSystem { get; set; }
    public CommandHandler? LastHandler { get; set; }
}