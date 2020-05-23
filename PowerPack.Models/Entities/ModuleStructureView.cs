namespace PowerPack.Models
{
    public class ModuleStructure
    {
        public ModuleStructure() { }
        public short? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleIconCssClass { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleUrl { get; set; }
        public short? ParentModuleId { get; set; }
        public decimal Sequence { get; set; }
        public short LevelNumber { get; set; }
        public bool IsPwdReVerificationEnabled { get; set; }
        public bool IsCurrentPage { get; set; }
    }
}
