namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class t_Units : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private string _UnitName;
		public string UnitName
		{
			set { _UnitName = value; AddChangeList("UnitName"); }
			get { return _UnitName; }
		}
		private float _Multiplier;
		public float Multiplier
		{
			set { _Multiplier = value; AddChangeList("Multiplier"); }
			get { return _Multiplier; }
		}
		private float _Addition;
		public float Addition
		{
			set { _Addition = value; AddChangeList("Addition"); }
			get { return _Addition; }
		}
		private Int16 _IsBaseUnit;
		public Int16 IsBaseUnit
		{
			set { _IsBaseUnit = value; AddChangeList("IsBaseUnit"); }
			get { return _IsBaseUnit; }
		}
		private Int16 _PerInKg;
		public Int16 PerInKg
		{
			set { _PerInKg = value; AddChangeList("PerInKg"); }
			get { return _PerInKg; }
		}
		private int _ParentUnitId;
		public int ParentUnitId
		{
			set { _ParentUnitId = value; AddChangeList("ParentUnitId"); }
			get { return _ParentUnitId; }
		}
		private int _UnitGroupId;
		public int UnitGroupId
		{
			set { _UnitGroupId = value; AddChangeList("UnitGroupId"); }
			get { return _UnitGroupId; }
		}
		public string GetTable()
		{
			return "t_Units";
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
