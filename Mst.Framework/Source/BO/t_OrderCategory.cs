namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class t_OrderCategory : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private string _OrderCatName;
		public string OrderCatName
		{
			set { _OrderCatName = value; AddChangeList("OrderCatName"); }
			get { return _OrderCatName; }
		}
		private Int16 _HasAdditives;
		public Int16 HasAdditives
		{
			set { _HasAdditives = value; AddChangeList("HasAdditives"); }
			get { return _HasAdditives; }
		}
		private int _ParentId;
		public int ParentId
		{
			set { _ParentId = value; AddChangeList("ParentId"); }
			get { return _ParentId; }
		}
		private Int16 _ShowInTree;
		public Int16 ShowInTree
		{
			set { _ShowInTree = value; AddChangeList("ShowInTree"); }
			get { return _ShowInTree; }
		}
		private string _OrderCategoryXMLPattern;
		public string OrderCategoryXMLPattern
		{
			set { _OrderCategoryXMLPattern = value; AddChangeList("OrderCategoryXMLPattern"); }
			get { return _OrderCategoryXMLPattern; }
		}
		public string GetTable()
		{
			return "t_OrderCategory";
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
