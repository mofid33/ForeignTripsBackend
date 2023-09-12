using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class RequestEmployeeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestEmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeFamily { get; set; } = null!;

    public string EmployeeFatherName { get; set; } = null!;

    public string BirthCertificationNumber { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string BirthCertificationDate { get; set; } = null!;

    public int GenderId { get; set; }

    public int MaritalStatusId { get; set; }

    public string Degree { get; set; } = null!;

    public string FieldOfStudy { get; set; } = null!;

    public int LanguageId { get; set; }

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int PassPortTypeId { get; set; }

    public string WorkExperience { get; set; } = null!;

    public string JobLocation { get; set; } = null!;

    public int PositionId { get; set; }

    public string EmployeeStatus { get; set; } = null!;

    public int RequestId { get; set; }

    public virtual GenderTypeTbl Gender { get; set; } = null!;

    public virtual LanguageTypeTbl Language { get; set; } = null!;

    public virtual MaritalStatusTbl MaritalStatus { get; set; } = null!;

    public virtual PassportTypeTbl PassPortType { get; set; } = null!;

    public virtual PositionTypeTbl Position { get; set; } = null!;
}
