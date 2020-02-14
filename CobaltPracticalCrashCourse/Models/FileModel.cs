using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CobaltPracticalCrashCourse.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public string FileSizeText { get; set; }
        public DateTime FileAccessed { get; set; }
    }
}