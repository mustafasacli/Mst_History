namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class ExtLookupParams : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private string _Control;
		public string Control
		{
			set { _Control = value; AddChangeList("Control"); }
			get { return _Control; }
		}
		private string _TableName;
		public string TableName
		{
			set { _TableName = value; AddChangeList("TableName"); }
			get { return _TableName; }
		}
		private string _DisplayMember;
		public string DisplayMember
		{
			set { _DisplayMember = value; AddChangeList("DisplayMember"); }
			get { return _DisplayMember; }
		}
		private string _ValueMember;
		public string ValueMember
		{
			set { _ValueMember = value; AddChangeList("ValueMember"); }
			get { return _ValueMember; }
		}
		public string GetTable()
		{
			return "ExtLookupParams";
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
