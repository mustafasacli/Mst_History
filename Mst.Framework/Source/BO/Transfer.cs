namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class Transfer : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _TransportId;
		public int TransportId
		{
			set { _TransportId = value; AddChangeList("TransportId"); }
			get { return _TransportId; }
		}
		private int _DestinationId;
		public int DestinationId
		{
			set { _DestinationId = value; AddChangeList("DestinationId"); }
			get { return _DestinationId; }
		}
		private DateTime _TransportTime;
		public DateTime TransportTime
		{
			set { _TransportTime = value; AddChangeList("TransportTime"); }
			get { return _TransportTime; }
		}
		private int _EstimateTime;
		public int EstimateTime
		{
			set { _EstimateTime = value; AddChangeList("EstimateTime"); }
			get { return _EstimateTime; }
		}
		public string GetTable()
		{
			return "Transfer";
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
