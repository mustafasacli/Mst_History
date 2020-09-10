namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class OrderEntry : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _PatientId;
		public int PatientId
		{
			set { _PatientId = value; AddChangeList("PatientId"); }
			get { return _PatientId; }
		}
		private int _CreatedByUser;
		public int CreatedByUser
		{
			set { _CreatedByUser = value; AddChangeList("CreatedByUser"); }
			get { return _CreatedByUser; }
		}
		private DateTime _CreatedDate;
		public DateTime CreatedDate
		{
			set { _CreatedDate = value; AddChangeList("CreatedDate"); }
			get { return _CreatedDate; }
		}
		private int _Priority;
		public int Priority
		{
			set { _Priority = value; AddChangeList("Priority"); }
			get { return _Priority; }
		}
		private DateTime _OrderStartTime;
		public DateTime OrderStartTime
		{
			set { _OrderStartTime = value; AddChangeList("OrderStartTime"); }
			get { return _OrderStartTime; }
		}
		private DateTime _OrderEndTime;
		public DateTime OrderEndTime
		{
			set { _OrderEndTime = value; AddChangeList("OrderEndTime"); }
			get { return _OrderEndTime; }
		}
		private int _OrderStatus;
		public int OrderStatus
		{
			set { _OrderStatus = value; AddChangeList("OrderStatus"); }
			get { return _OrderStatus; }
		}
		private int _ApprovedByUser;
		public int ApprovedByUser
		{
			set { _ApprovedByUser = value; AddChangeList("ApprovedByUser"); }
			get { return _ApprovedByUser; }
		}
		private DateTime _ApprovedDate;
		public DateTime ApprovedDate
		{
			set { _ApprovedDate = value; AddChangeList("ApprovedDate"); }
			get { return _ApprovedDate; }
		}
		private int _Administer;
		public int Administer
		{
			set { _Administer = value; AddChangeList("Administer"); }
			get { return _Administer; }
		}
		private int _OrderCategory;
		public int OrderCategory
		{
			set { _OrderCategory = value; AddChangeList("OrderCategory"); }
			get { return _OrderCategory; }
		}
		private int _Location;
		public int Location
		{
			set { _Location = value; AddChangeList("Location"); }
			get { return _Location; }
		}
		private string _Remarks;
		public string Remarks
		{
			set { _Remarks = value; AddChangeList("Remarks"); }
			get { return _Remarks; }
		}
		private int _GiveInPerKg;
		public int GiveInPerKg
		{
			set { _GiveInPerKg = value; AddChangeList("GiveInPerKg"); }
			get { return _GiveInPerKg; }
		}
		private int _PatientWeight;
		public int PatientWeight
		{
			set { _PatientWeight = value; AddChangeList("PatientWeight"); }
			get { return _PatientWeight; }
		}
		private string _OrderParametersXML;
		public string OrderParametersXML
		{
			set { _OrderParametersXML = value; AddChangeList("OrderParametersXML"); }
			get { return _OrderParametersXML; }
		}
		private DateTime _UpdateTime;
		public DateTime UpdateTime
		{
			set { _UpdateTime = value; AddChangeList("UpdateTime"); }
			get { return _UpdateTime; }
		}
		private int _UpdateByUser;
		public int UpdateByUser
		{
			set { _UpdateByUser = value; AddChangeList("UpdateByUser"); }
			get { return _UpdateByUser; }
		}
		public string GetTable()
		{
			return "OrderEntry";
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
