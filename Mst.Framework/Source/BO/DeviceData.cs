namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class DeviceData : IBaseBO
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
		private int _DeviceId;
		public int DeviceId
		{
			set { _DeviceId = value; AddChangeList("DeviceId"); }
			get { return _DeviceId; }
		}
		private DateTime _Date;
		public DateTime Date
		{
			set { _Date = value; AddChangeList("Date"); }
			get { return _Date; }
		}
		private string _Data;
		public string Data
		{
			set { _Data = value; AddChangeList("Data"); }
			get { return _Data; }
		}
		public string GetTable()
		{
			return "DeviceData";
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
