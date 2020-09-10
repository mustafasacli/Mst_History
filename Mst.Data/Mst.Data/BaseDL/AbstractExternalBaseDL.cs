namespace Mst.Data.BaseDL
{
    using Mst.Data.Management;
    using Mst.Data.QueryBuilding;
    using System;
    using System.Data;

    public class AbstractExternalBaseDL : IBaseDL
    {

        protected IBaseBO _baseBO;

        public virtual IDbManager Manager
        {
            get
            {
                throw new NotImplementedException("Manager not implemented.");
            }
        }

        public int Insert()
        {
            try
            {
                QueryBuilder queryBuilder =
                     Manager.CreateQueryBuilder(QueryTypes.Insert, _baseBO);

                return Manager.ExecuteQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int InsertAndGetId()
        {
            try
            {
                QueryBuilder queryBuilder =
                     Manager.CreateQueryBuilder(QueryTypes.InsertAndGetId, _baseBO);

                return Convert.ToInt32(Manager.ExecuteScalarQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Update()
        {
            try
            {
                QueryBuilder queryBuilder =
                    Manager.CreateQueryBuilder(QueryTypes.Update, _baseBO);

                return Manager.ExecuteQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Delete()
        {
            try
            {
                QueryBuilder queryBuilder =
                    Manager.CreateQueryBuilder(QueryTypes.Delete, _baseBO);

                return Manager.ExecuteQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public DataTable GetAllRecords()
        {
            try
            {
                QueryBuilder queryBuilder = Manager.CreateQueryBuilder(
                    QueryTypes.Select, _baseBO);

                return Manager.GetResultSetOfQuery(
                    queryBuilder.QueryString).Tables[0];
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        public DataTable GetById(int Id)
        {
            try
            {
                QueryBuilder queryBuilder =
                    Manager.CreateQueryBuilder(QueryTypes.SelectWhereId, _baseBO);

                DataTable dT = Manager.GetResultSetOfQuery(
                    queryBuilder.QueryString,
                    queryBuilder.QueryParameters).Tables[0];


                return dT;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

    }
}
