using CobaltPracticalCrashCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CobaltPracticalCrashCourse.ViewModels
{
    public class ExplorerViewModel
    {
        public List<DirModel> DirModels;
        public List<FileModel> FileModels;

        public string FolderName;
        public string ParentFolderName;
        public string URL;

        public ExplorerViewModel(List<DirModel> dirModels, List<FileModel> fileModels)
        {
            DirModels = dirModels;
            FileModels = fileModels;
        }
    }
}