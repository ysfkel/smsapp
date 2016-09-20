//using System.Collections.Generic;
//using ServiceStack.OrmLite;
//using DomainModel.Repository;

//namespace DomainModel
//{
//    public class SMSRepository:IDataRepository
//    {
//        // The IDbConnection passed in from the IOC container on the service
//        System.Data.IDbConnection _dbConnection;

//        // Store the database connection passed in
//        public SMSRepository(System.Data.IDbConnection dbConnection)
//        {
//            _dbConnection = dbConnection;
//        }

//        // Inserts a new row into the Person table
//        public int Add(SMS p)
//        {
//            return (int)_dbConnection.Insert<SMS>(p, selectIdentity: true);
//        }

//        // Return a list of people from our DB
//        // (this is the equivilent of “SELECT * FROM Person”)
//        public List<SMS> Get()
//        {
//            return _dbConnection.Select<SMS>();
//        }

//        // Return a single person given their ID
//        public SMS GetByID(int id)
//        {
//            return _dbConnection.SingleById<SMS>(id);
//        }

//        // Updates a row in the Person table. Note that this call updates
//        // all fields, in order to update only certain fields using OrmLite,
//        // use an anonymous type like the below line, which would only
//        // update the FirstName and LastName fields:
//        // _dbConnection.Update(new { FirstName = “Gene”, LastName = “Rayburn” });
//        public SMS Update(SMS p)
//        {
//            _dbConnection.Update<SMS>(p);
//            return p;
//        }

//        // Deletes a row from the Person table
//        public int DeleteByID(int id)
//        {
//            return _dbConnection.Delete(id);
//        }
//    }
//}
