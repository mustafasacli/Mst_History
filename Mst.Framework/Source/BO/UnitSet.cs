namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class UnitSet : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _UnitId;
		public int UnitId
		{
			set { _UnitId = value; AddChangeList("UnitId"); }
			get { return _UnitId; }
		}
		private int _SetId;
		public int SetId
		{
			set { _SetId = value; AddChangeList("SetId"); }
			get { return _SetId; }
		}
		private int _UnitType;
		public int UnitType
		{
			set { _UnitType = value; AddChangeList("UnitType"); }
			get { return _UnitType; }
		}
		public string GetTable()
		{
			return "UnitSet";
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
