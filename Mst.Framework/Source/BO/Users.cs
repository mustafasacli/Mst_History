namespace nmu.Source.BO
{
	using System;
	using System.Collections.Generic;
	using nmu.Source.Base;
	using Mst.Data.QueryBuilding;

	public class Users : IBaseBO
	{
		private int _OBJID;
		public int OBJID
		{
			set { _OBJID = value; AddChangeList("OBJID"); }
			get { return _OBJID; }
		}
		private string _FirstName;
		public string FirstName
		{
			set { _FirstName = value; AddChangeList("FirstName"); }
			get { return _FirstName; }
		}
		private string _LastName;
		public string LastName
		{
			set { _LastName = value; AddChangeList("LastName"); }
			get { return _LastName; }
		}
		private string _Email;
		public string Email
		{
			set { _Email = value; AddChangeList("Email"); }
			get { return _Email; }
		}
		private string _UserName;
		public string UserName
		{
			set { _UserName = value; AddChangeList("UserName"); }
			get { return _UserName; }
		}
		private string _Password;
		public string Password
		{
			set { _Password = value; AddChangeList("Password"); }
			get { return _Password; }
		}
		private Int16 _UserTypeId;
		public Int16 UserTypeId
		{
			set { _UserTypeId = value; AddChangeList("UserTypeId"); }
			get { return _UserTypeId; }
		}
		private string _Address;
		public string Address
		{
			set { _Address = value; AddChangeList("Address"); }
			get { return _Address; }
		}
		private DateTime _BirthDate;
		public DateTime BirthDate
		{
			set { _BirthDate = value; AddChangeList("BirthDate"); }
			get { return _BirthDate; }
		}
		private string _Picture;
		public string Picture
		{
			set { _Picture = value; AddChangeList("Picture"); }
			get { return _Picture; }
		}
		private DateTime _UserCreationDate;
		public DateTime UserCreationDate
		{
			set { _UserCreationDate = value; AddChangeList("UserCreationDate"); }
			get { return _UserCreationDate; }
		}
		private int _UpdateUserId;
		public int UpdateUserId
		{
			set { _UpdateUserId = value; AddChangeList("UpdateUserId"); }
			get { return _UpdateUserId; }
		}
		public string GetTable()
		{
			return "Users";
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
