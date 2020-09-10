namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class PatientBed : IBaseBO
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
		private DateTime _FromTime;
		public DateTime FromTime
		{
			set { _FromTime = value; AddChangeList("FromTime"); }
			get { return _FromTime; }
		}
		private int _BedId;
		public int BedId
		{
			set { _BedId = value; AddChangeList("BedId"); }
			get { return _BedId; }
		}
		private int _UpdateUserId;
		public int UpdateUserId
		{
			set { _UpdateUserId = value; AddChangeList("UpdateUserId"); }
			get { return _UpdateUserId; }
		}
		private DateTime _UpdateTime;
		public DateTime UpdateTime
		{
			set { _UpdateTime = value; AddChangeList("UpdateTime"); }
			get { return _UpdateTime; }
		}
		public string GetTable()
		{
			return "PatientBed";
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
