namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class OrderSchedules : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _OrderId;
		public int OrderId
		{
			set { _OrderId = value; AddChangeList("OrderId"); }
			get { return _OrderId; }
		}
		private DateTime _ScheduleTime;
		public DateTime ScheduleTime
		{
			set { _ScheduleTime = value; AddChangeList("ScheduleTime"); }
			get { return _ScheduleTime; }
		}
		private int _ScheduleStatus;
		public int ScheduleStatus
		{
			set { _ScheduleStatus = value; AddChangeList("ScheduleStatus"); }
			get { return _ScheduleStatus; }
		}
		public string GetTable()
		{
			return "OrderSchedules";
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
