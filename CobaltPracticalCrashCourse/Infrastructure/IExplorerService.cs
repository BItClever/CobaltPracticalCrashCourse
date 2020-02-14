using CobaltPracticalCrashCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobaltPracticalCrashCourse.Infrastructure
{
    public interface IExplorerService
    {
        List<DirModel> MapDirs(string path);
        List<FileModel> MapFiles(string path);
    }
}
