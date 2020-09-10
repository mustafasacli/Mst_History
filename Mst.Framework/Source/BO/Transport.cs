namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class Transport : IBaseBO
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
		private int _SNurseId;
		public int SNurseId
		{
			set { _SNurseId = value; AddChangeList("SNurseId"); }
			get { return _SNurseId; }
		}
		private DateTime _EndTime;
		public DateTime EndTime
		{
			set { _EndTime = value; AddChangeList("EndTime"); }
			get { return _EndTime; }
		}
		private int _RNurseId;
		public int RNurseId
		{
			set { _RNurseId = value; AddChangeList("RNurseId"); }
			get { return _RNurseId; }
		}
		private int _FromBed;
		public int FromBed
		{
			set { _FromBed = value; AddChangeList("FromBed"); }
			get { return _FromBed; }
		}
		private int _ToBed;
		public int ToBed
		{
			set { _ToBed = value; AddChangeList("ToBed"); }
			get { return _ToBed; }
		}
		private DateTime _UpdateTime;
		public DateTime UpdateTime
		{
			set { _UpdateTime = value; AddChangeList("UpdateTime"); }
			get { return _UpdateTime; }
		}
		public string GetTable()
		{
			return "Transport";
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
