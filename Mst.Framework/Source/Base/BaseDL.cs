namespace nmu.Source.Base
{
	using Mst.Data.Management;
	using Mst.Data.QueryBuilding;

	/* Main Data Layer Class */
	public class BaseDL : IBaseDL
	{
		protected IBaseBO _basebo;
		public BaseDL()
		{
		}
		public BaseDL(IBaseBO basebo)
		{
			_basebo = basebo;
		}
		public IDbManager Manager
		{
			get
			{
				return new MsSQLManager(@"Server=10.0.0.145; Initial Catalog=InCareTest; Persist Security Info=True; User Id=incareadmin; Password=incareadmin;");

			}
		}

		public int Insert()
		{
			return Manager.Insert(_basebo);
		}

		public int InsertAndGetId()
		{
			return Manager.InsertAndGetId(_basebo);
		}

		public int Update()
		{
			return Manager.Update(_basebo);
		}

		public int Delete()
		{
			return Manager.Delete(_basebo);
		}

	}
}
