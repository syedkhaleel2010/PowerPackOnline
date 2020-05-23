using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Helpers
{

    public enum ModuleCodes
    {

        CalculateAverage,
        ElectiveClassList
    }
    public enum PermissionCodes
    {
        V_Assignment,
        U_Assignment,
        V_Incident,
        U_Incident,
        U_AddIncInvestigator,
        U_MyFiles,
        V_ShowAllTask,
        U_ViewLockerFiles,
        U_ViewSchoolSpaceFiles,
        U_ViewGroupFiles,
        V_Quiz,
        U_Quiz,
        V_Chatter,
        U_Chatter,
        V_ExemplarWall,
        U_ExemplarWall,
        V_Observation,
        U_Observation,
        V_HSEPerformAudit,
        V_HSELibrary,
        V_AllAudit,
        U_InvestigationCreation,
        V_Admin,
        V_AssignPermission,
        U_AssignPermission,
        M_HSEPerformAuditMail,
        CC_In_Investigator_Email,
        View_Reported_By_Any,
        V_ScorecardApproval,
        V_AuditEditAfterMissed,
        V_AuditApproval,
        Reopen_Incident,
        Approve_HSE_Investigation,
        Allow_Major_Serious_Severity,
        V_SchoolBanner ,
        U_SchoolBanner,
        V_SchoolBadge,
        U_SchoolBadge,
        V_MyPlanner,
        U_MyPlanner,
        V_EventCategory,
        U_EventCategory,
        V_LessonPlan,
        U_LessonPlan,
        V_PlanTemplate,
        U_PlanTemplate,
       // U_EventCategory,
       //  U_MyPlanner,
        V_StudentCertificate,
        U_StudentCertificate,
        V_ErrorLogs,
        U_ErrorLogs
    }
    public enum ConfigurableModuleCodes
    {

        [StringValue("MedicalIncident")]
        MedicalIncident,
        [StringValue("HonorRollReport")]
        HonorRollReport
    }
   

    public enum ApplicationList
    {
        [StringValue("Control Panel")]
        AdminHome,
        [StringValue("SIS")]
        SISHome
    }
}
