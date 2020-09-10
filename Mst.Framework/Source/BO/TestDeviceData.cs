namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class TestDeviceData : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _Patient1;
		public int Patient1
		{
			set { _Patient1 = value; AddChangeList("Patient1"); }
			get { return _Patient1; }
		}
		private int _Patient2;
		public int Patient2
		{
			set { _Patient2 = value; AddChangeList("Patient2"); }
			get { return _Patient2; }
		}
		private int _patient3;
		public int patient3
		{
			set { _patient3 = value; AddChangeList("patient3"); }
			get { return _patient3; }
		}
		private int _patient4;
		public int patient4
		{
			set { _patient4 = value; AddChangeList("patient4"); }
			get { return _patient4; }
		}
		private int _Disease1;
		public int Disease1
		{
			set { _Disease1 = value; AddChangeList("Disease1"); }
			get { return _Disease1; }
		}
		private int _Disease2;
		public int Disease2
		{
			set { _Disease2 = value; AddChangeList("Disease2"); }
			get { return _Disease2; }
		}
		public string GetTable()
		{
			return "TestDeviceData";
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
