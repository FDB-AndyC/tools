// -----------------------------------------public ---------------------------------------------------------------------------
// <copyright file="VisionSqlGenerator.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the VisionSqlGenerator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Model
{
    using System.Text;

    public static class VisionSqlGenerator
    {
        public static string GetPatientSql()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM patient AS p ");
            sb.AppendLine("WHERE p.entity_id = @currentPatientId");

            return sb.ToString();
        }

        public static string GetEthnicitySql()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM ethnicity AS eth ");
            sb.AppendLine("WHERE eth.master_id = @currentPatientId");

            return sb.ToString();
        }

        public static string GetAddressSql()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM newadd AS add ");
            sb.AppendLine("WHERE add.master_id = @currentPatientId");

            return sb.ToString();
        }

        public static string GetSidebarJoinedAddressDetailsSql()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT ");
            sb.AppendLine("add.house_name, add.house_no, add.road_name, add.local_name, add.town_name, add.county_nam, add.postcode, ");
            sb.AppendLine("p.entity_id, p.surname, p.forename1, p.nhs_no, p.sex as sexcode, p.dob, p.title, p.reg_gp, p.usual_gp, eth.read_term AS ethnicity ");
            sb.AppendLine("FROM patient AS p ");
            sb.AppendLine("INNER JOIN newadd AS add ON add.master_id = p.entity_id ");
            sb.AppendLine("LEFT JOIN ethnicity AS eth ON eth.master_id = p.entity_id AND eth.auditflag = 1 ");
            sb.AppendLine("WHERE p.auditflag = 1 AND add.auditflag = 1 AND add.master_ty = 1 AND p.entity_id = @currentPatientId");

            return sb.ToString();
        }

        public static string GetReferralsSql()
        {
            return
@"SELECT p.nhs_no, p.surname, r.prac_id, r.sysdate, dbo.PICK(r.category) AS category, r.read_code, r.read_term, dbo.PICK(r.fhsaspec) as fhsaspec, dbo.PICK(r.source) AS source, dbo.PICK(r.nhsspec) as nhsspec, dbo.PICK(r.inpatient) as inpatient, dbo.PICK(r.attendance) as attendance, dbo.PICK(r.urgency) as urgency, dbo.PICK(r.contract) as contract, dbo.PICK(l.lettertype) as lettertype, l.thirdparty, dbo.PICK(l.objecttype) AS objecttype, l.filename, add.addresses, dbo.STAFF(c.clinician) AS clinician

FROM referral r 
    INNER JOIN patient p ON r.master_id = p.entity_id 
    INNER JOIN
    (
        SELECT master_id, COUNT(master_id) AS addresses 
        FROM newadd 
        GROUP BY master_id
    ) AS add ON add.master_id = p.entity_id
    INNER JOIN letters l ON l.source_id = r.entity_id
    INNER JOIN consult c ON c.entity_id = r.consult_id

WHERE r.fhsaspec = 'SPE005' AND r.source = 'SOU001' AND r.nhsspec = 'DEP004' AND r.inpatient = 'RFT003' AND r.attendance = 'ATT001' AND r.urgency = 'URG002' AND r.contract = 'FCG001'

ORDER BY sysdate
";
        }
    }
}
