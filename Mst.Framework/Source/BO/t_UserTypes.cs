namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class t_UserTypes : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private string _UserTypeName;
		public string UserTypeName
		{
			set { _UserTypeName = value; AddChangeList("UserTypeName"); }
			get { return _UserTypeName; }
		}
		private string _Abbreviate;
		public string Abbreviate
		{
			set { _Abbreviate = value; AddChangeList("Abbreviate"); }
			get { return _Abbreviate; }
		}
		private int _ColorCode;
		public int ColorCode
		{
			set { _ColorCode = value; AddChangeList("ColorCode"); }
			get { return _ColorCode; }
		}
		public string GetTable()
		{
			return "t_UserTypes";
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
