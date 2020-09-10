namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class TestPieSeries : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
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
		private int _Disease3;
		public int Disease3
		{
			set { _Disease3 = value; AddChangeList("Disease3"); }
			get { return _Disease3; }
		}
		private int _Disease4;
		public int Disease4
		{
			set { _Disease4 = value; AddChangeList("Disease4"); }
			get { return _Disease4; }
		}
		public string GetTable()
		{
			return "TestPieSeries";
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
