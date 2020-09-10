namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class Patient : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private Int16 _GenderId;
		public Int16 GenderId
		{
			set { _GenderId = value; AddChangeList("GenderId"); }
			get { return _GenderId; }
		}
		private string _HospitalId;
		public string HospitalId
		{
			set { _HospitalId = value; AddChangeList("HospitalId"); }
			get { return _HospitalId; }
		}
		private string _FirstName;
		public string FirstName
		{
			set { _FirstName = value; AddChangeList("FirstName"); }
			get { return _FirstName; }
		}
		private string _LastName;
		public string LastName
		{
			set { _LastName = value; AddChangeList("LastName"); }
			get { return _LastName; }
		}
		private string _OtherForename;
		public string OtherForename
		{
			set { _OtherForename = value; AddChangeList("OtherForename"); }
			get { return _OtherForename; }
		}
		private string _MaidenName;
		public string MaidenName
		{
			set { _MaidenName = value; AddChangeList("MaidenName"); }
			get { return _MaidenName; }
		}
		private string _FatherName;
		public string FatherName
		{
			set { _FatherName = value; AddChangeList("FatherName"); }
			get { return _FatherName; }
		}
		private string _PatientIdentityNumber;
		public string PatientIdentityNumber
		{
			set { _PatientIdentityNumber = value; AddChangeList("PatientIdentityNumber"); }
			get { return _PatientIdentityNumber; }
		}
		private string _SocialSecurityNumber;
		public string SocialSecurityNumber
		{
			set { _SocialSecurityNumber = value; AddChangeList("SocialSecurityNumber"); }
			get { return _SocialSecurityNumber; }
		}
		private DateTime _BirthDate;
		public DateTime BirthDate
		{
			set { _BirthDate = value; AddChangeList("BirthDate"); }
			get { return _BirthDate; }
		}
		private float _Age;
		public float Age
		{
			set { _Age = value; AddChangeList("Age"); }
			get { return _Age; }
		}
		private Int16 _MaritalStatusId;
		public Int16 MaritalStatusId
		{
			set { _MaritalStatusId = value; AddChangeList("MaritalStatusId"); }
			get { return _MaritalStatusId; }
		}
		private Int16 _NationalityId;
		public Int16 NationalityId
		{
			set { _NationalityId = value; AddChangeList("NationalityId"); }
			get { return _NationalityId; }
		}
		private Int16 _EthnicGroupId;
		public Int16 EthnicGroupId
		{
			set { _EthnicGroupId = value; AddChangeList("EthnicGroupId"); }
			get { return _EthnicGroupId; }
		}
		private Int16 _ReligionId;
		public Int16 ReligionId
		{
			set { _ReligionId = value; AddChangeList("ReligionId"); }
			get { return _ReligionId; }
		}
		private DateTime _AddmissionDate;
		public DateTime AddmissionDate
		{
			set { _AddmissionDate = value; AddChangeList("AddmissionDate"); }
			get { return _AddmissionDate; }
		}
		private DateTime _FromTime;
		public DateTime FromTime
		{
			set { _FromTime = value; AddChangeList("FromTime"); }
			get { return _FromTime; }
		}
		private float _AdmissionWeight;
		public float AdmissionWeight
		{
			set { _AdmissionWeight = value; AddChangeList("AdmissionWeight"); }
			get { return _AdmissionWeight; }
		}
		private float _Height;
		public float Height
		{
			set { _Height = value; AddChangeList("Height"); }
			get { return _Height; }
		}
		private string _HomePhone;
		public string HomePhone
		{
			set { _HomePhone = value; AddChangeList("HomePhone"); }
			get { return _HomePhone; }
		}
		private string _WorkPhone;
		public string WorkPhone
		{
			set { _WorkPhone = value; AddChangeList("WorkPhone"); }
			get { return _WorkPhone; }
		}
		private string _Address;
		public string Address
		{
			set { _Address = value; AddChangeList("Address"); }
			get { return _Address; }
		}
		private string _ReferredFrom;
		public string ReferredFrom
		{
			set { _ReferredFrom = value; AddChangeList("ReferredFrom"); }
			get { return _ReferredFrom; }
		}
		private string _ReferredBy;
		public string ReferredBy
		{
			set { _ReferredBy = value; AddChangeList("ReferredBy"); }
			get { return _ReferredBy; }
		}
		private string _ReferredPhone;
		public string ReferredPhone
		{
			set { _ReferredPhone = value; AddChangeList("ReferredPhone"); }
			get { return _ReferredPhone; }
		}
		private string _BirthPlace;
		public string BirthPlace
		{
			set { _BirthPlace = value; AddChangeList("BirthPlace"); }
			get { return _BirthPlace; }
		}
		private int _AttendingPhysicianId;
		public int AttendingPhysicianId
		{
			set { _AttendingPhysicianId = value; AddChangeList("AttendingPhysicianId"); }
			get { return _AttendingPhysicianId; }
		}
		private string _PhysicianService;
		public string PhysicianService
		{
			set { _PhysicianService = value; AddChangeList("PhysicianService"); }
			get { return _PhysicianService; }
		}
		private int _AttendingNurseId;
		public int AttendingNurseId
		{
			set { _AttendingNurseId = value; AddChangeList("AttendingNurseId"); }
			get { return _AttendingNurseId; }
		}
		private string _Remarks;
		public string Remarks
		{
			set { _Remarks = value; AddChangeList("Remarks"); }
			get { return _Remarks; }
		}
		private string _ContactName;
		public string ContactName
		{
			set { _ContactName = value; AddChangeList("ContactName"); }
			get { return _ContactName; }
		}
		private string _ContactPhone;
		public string ContactPhone
		{
			set { _ContactPhone = value; AddChangeList("ContactPhone"); }
			get { return _ContactPhone; }
		}
		private string _BloodGroup;
		public string BloodGroup
		{
			set { _BloodGroup = value; AddChangeList("BloodGroup"); }
			get { return _BloodGroup; }
		}
		private string _Allergies;
		public string Allergies
		{
			set { _Allergies = value; AddChangeList("Allergies"); }
			get { return _Allergies; }
		}
		private string _Title;
		public string Title
		{
			set { _Title = value; AddChangeList("Title"); }
			get { return _Title; }
		}
		private int _OccupationId;
		public int OccupationId
		{
			set { _OccupationId = value; AddChangeList("OccupationId"); }
			get { return _OccupationId; }
		}
		private string _MailingAddress;
		public string MailingAddress
		{
			set { _MailingAddress = value; AddChangeList("MailingAddress"); }
			get { return _MailingAddress; }
		}
		private int _OfflineFlag;
		public int OfflineFlag
		{
			set { _OfflineFlag = value; AddChangeList("OfflineFlag"); }
			get { return _OfflineFlag; }
		}
		private string _PersonId;
		public string PersonId
		{
			set { _PersonId = value; AddChangeList("PersonId"); }
			get { return _PersonId; }
		}
		private int _StatusId;
		public int StatusId
		{
			set { _StatusId = value; AddChangeList("StatusId"); }
			get { return _StatusId; }
		}
		private string _FileNumber;
		public string FileNumber
		{
			set { _FileNumber = value; AddChangeList("FileNumber"); }
			get { return _FileNumber; }
		}
		private int _BedId;
		public int BedId
		{
			set { _BedId = value; AddChangeList("BedId"); }
			get { return _BedId; }
		}
		public string GetTable()
		{
			return "Patient";
		}
		public string GetIdColumn()
		{
			return "OBJID";
		}
		public int Insert()
		{
			return (new BaseDL(this)).Insert();
		}

		public int InsertAndGetId()
		{
			return (new BaseDL(this)).InsertAndGetId();
		}

		public int Update()
		{
			return (new BaseDL(this)).Update();
		}

		public int Delete()
		{
			return (new BaseDL(this)).Delete();
		}

		protected List<string> columnList = new List<string>();

		public List<string> GetColumnChangeList()
		{
			return columnList;
		}

		public void AddChangeList(string column)
		{
			if (!columnList.Contains(column))
				columnList.Add(column);
		}

	}
}
