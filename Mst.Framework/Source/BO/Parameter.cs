namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class Parameter : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private string _ParameterName;
		public string ParameterName
		{
			set { _ParameterName = value; AddChangeList("ParameterName"); }
			get { return _ParameterName; }
		}
		private int _ParameterType;
		public int ParameterType
		{
			set { _ParameterType = value; AddChangeList("ParameterType"); }
			get { return _ParameterType; }
		}
		private int _UnitSetId;
		public int UnitSetId
		{
			set { _UnitSetId = value; AddChangeList("UnitSetId"); }
			get { return _UnitSetId; }
		}
		private string _Abbreviation;
		public string Abbreviation
		{
			set { _Abbreviation = value; AddChangeList("Abbreviation"); }
			get { return _Abbreviation; }
		}
		private Int16 _InfuseActive;
		public Int16 InfuseActive
		{
			set { _InfuseActive = value; AddChangeList("InfuseActive"); }
			get { return _InfuseActive; }
		}
		private Int16 _RepeatedSetActive;
		public Int16 RepeatedSetActive
		{
			set { _RepeatedSetActive = value; AddChangeList("RepeatedSetActive"); }
			get { return _RepeatedSetActive; }
		}
		private int _DefaultSetTimesId;
		public int DefaultSetTimesId
		{
			set { _DefaultSetTimesId = value; AddChangeList("DefaultSetTimesId"); }
			get { return _DefaultSetTimesId; }
		}
		public string GetTable()
		{
			return "Parameter";
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
