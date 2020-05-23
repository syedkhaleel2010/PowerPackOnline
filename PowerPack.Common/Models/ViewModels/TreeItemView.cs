using System.Collections.Generic;

namespace PowerPack.Common.ViewModels
{
    public class TreeItemView
    {
        public int? id { get; set; }
        public int? parentId { get; set; }
        public string name { get; set; }
        public bool checkbox { get; set; }
        public string url { get; set; }
        public string ModuleCode { get; set; }
    }
    
    public class TopicTreeItem
    {
        public string id { get; set; }
        public string parentId { get; set; }
        public string name { get; set; }
        public bool checkbox { get; set; }
        public string url { get; set; }
        public string ModuleCode { get; set; }
        public bool isLesson { get; set; }
        public int SubjectId { get; set; }
    }

    public class ParentTree
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool @checked { get; set; }
        public TreeAttributes attributes { get; set; }
        public List<ParentTree> children { get; set; }
    }

    public class TreeAttributes
    {
        public int HeaderRowNum { get; set; }
        public short LevelNo { get; set; }
    }

    public class FileTreeItem
    {
        public string id { get; set; }
        public long parentId { get; set; }
        public string name { get; set; }
        public bool checkbox { get; set; }
        public string url { get; set; }
        public string ModuleCode { get; set; }
        public bool isFolder { get; set; }
    }

}
