namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class Log : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private DateTime _Date;
		public DateTime Date
		{
			set { _Date = value; AddChangeList("Date"); }
			get { return _Date; }
		}
		private string _Title;
		public string Title
		{
			set { _Title = value; AddChangeList("Title"); }
			get { return _Title; }
		}
		private int _Category;
		public int Category
		{
			set { _Category = value; AddChangeList("Category"); }
			get { return _Category; }
		}
		private string _OriginalMessage;
		public string OriginalMessage
		{
			set { _OriginalMessage = value; AddChangeList("OriginalMessage"); }
			get { return _OriginalMessage; }
		}
		private string _StackTrace;
		public string StackTrace
		{
			set { _StackTrace = value; AddChangeList("StackTrace"); }
			get { return _StackTrace; }
		}
		private string _ResponseCode;
		public string ResponseCode
		{
			set { _ResponseCode = value; AddChangeList("ResponseCode"); }
			get { return _ResponseCode; }
		}
		public string GetTable()
		{
			return "Log";
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
