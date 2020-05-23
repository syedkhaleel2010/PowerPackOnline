using PowerPack.Common.Helpers;

namespace PowerPack.Common.Enums
{
    public enum TransactionModes : byte
    {
        [StringValue("C")]
        Insert = 1,
        [StringValue("U")]
        Update=2,
        [StringValue("D")]
        Delete=3,
        [StringValue("BC")]
        BulkInsert,
    }

    public enum TransactionStatus
    {
        [StringValue("W")]
        Waiting,
        [StringValue("S")]
        Success,
        [StringValue("F")]
        Failed
    }
    public enum ContentType : byte
    {
        [StringValue("F")]
        Free = 1,
        [StringValue("P")]
        Paid = 2,
        [StringValue("D")]
        ContentResource = 3,
    }
}
