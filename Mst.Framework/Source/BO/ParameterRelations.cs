namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class ParameterRelations : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private int _OrderCategoryId;
		public int OrderCategoryId
		{
			set { _OrderCategoryId = value; AddChangeList("OrderCategoryId"); }
			get { return _OrderCategoryId; }
		}
		private int _ParameterId;
		public int ParameterId
		{
			set { _ParameterId = value; AddChangeList("ParameterId"); }
			get { return _ParameterId; }
		}
		private int _RelatedParameterId;
		public int RelatedParameterId
		{
			set { _RelatedParameterId = value; AddChangeList("RelatedParameterId"); }
			get { return _RelatedParameterId; }
		}
		private Int16 _IsActive;
		public Int16 IsActive
		{
			set { _IsActive = value; AddChangeList("IsActive"); }
			get { return _IsActive; }
		}
		public string GetTable()
		{
			return "ParameterRelations";
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
