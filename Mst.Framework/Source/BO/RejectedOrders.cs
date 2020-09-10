namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class RejectedOrders : IBaseBO
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
		private int _RejectedByUser;
		public int RejectedByUser
		{
			set { _RejectedByUser = value; AddChangeList("RejectedByUser"); }
			get { return _RejectedByUser; }
		}
		private DateTime _RejectedDate;
		public DateTime RejectedDate
		{
			set { _RejectedDate = value; AddChangeList("RejectedDate"); }
			get { return _RejectedDate; }
		}
		private string _RejectReason;
		public string RejectReason
		{
			set { _RejectReason = value; AddChangeList("RejectReason"); }
			get { return _RejectReason; }
		}
		public string GetTable()
		{
			return "RejectedOrders";
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
