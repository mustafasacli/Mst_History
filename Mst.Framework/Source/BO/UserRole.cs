namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class UserRole : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _UserId;
		public int UserId
		{
			set { _UserId = value; AddChangeList("UserId"); }
			get { return _UserId; }
		}
		private int _RoleId;
		public int RoleId
		{
			set { _RoleId = value; AddChangeList("RoleId"); }
			get { return _RoleId; }
		}
		public string GetTable()
		{
			return "UserRole";
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
