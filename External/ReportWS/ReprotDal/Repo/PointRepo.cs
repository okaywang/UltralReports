using ReprotDal.Model;
using Rinch.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprotDal.Repo
{
    public class PointRepo
    {
         private readonly Database dataBase = new Database(Config.DbConnectionString);
        public IEnumerable<Point> GetPoints(int type)
        {
            string sql = @"select Id,PointName from RtPoints where TableType = @tableType ";
            IEnumerable<Point> pointsList = dataBase.ExecuteDataReader<Point>(sql, new { tableType = type }, dr => { return GetByDataReader(dr); }
            );
            return pointsList;
        }
        private Point GetByDataReader(DbDataReader dr)
        {
            try
            {
                return new Point
                {
                    ID = (int)dr["Id"],
                    Name = (String)dr["PointName"],
                };
            }
            catch
            {

            }
            return null;
        }
    }
   
}
