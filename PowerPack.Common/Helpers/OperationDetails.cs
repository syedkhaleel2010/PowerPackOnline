using System;

namespace PowerPack.Common.Helpers
{
    public class OperationDetails
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public int InsertedRowId { get; set; }
        public string CssClass { get; set; }
        public string Identifier { set; get; }
        public string HeaderText { set; get; }
        public string NotificationType { set; get; }
        public string RelatedHtml { set; get; }

        public OperationDetails() { }

        public OperationDetails(bool success, string message, Exception exception)
            : this(success, message, exception, 0)
        {
        }

        public OperationDetails(bool success, string message, Exception exception, int insertedRowId)
        {
            Success = success;
            Message = message;
            Exception = exception;
            InsertedRowId = insertedRowId;
        }

        public OperationDetails(string message)
        {
           
            Message = message;
           
        }

        public OperationDetails(bool success, string message)
        {
            Success = success;
            Message = message;
            NotificationType = StringEnum.GetStringValue(NotificationTypeConstants.Warning);

        }

        public OperationDetails(bool success)
        {
            Success = success;
            Message = success ? Localization.LocalizationHelper.UpdateSuccessMessage : Localization.LocalizationHelper.TechnicalErrorMessage;
            NotificationType = success ? StringEnum.GetStringValue(NotificationTypeConstants.Success) : StringEnum.GetStringValue(NotificationTypeConstants.Error);
        }

    }

    public enum NotificationTypeConstants
    {
        [StringValue("error")]
        Error = 0,
        [StringValue("success")]
        Success = 1,
        [StringValue("warning")]
        Warning = 2
    }
}
