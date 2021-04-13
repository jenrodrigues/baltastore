using System;
using BaltaStore.Shared;
using System.Data.SqlClient;
using System.Data;

namespace BaltaStore.Infra.DataContexts{
    public class BaltaDataContext: IDisposable{
        public SqlConnection Connection {get;set;}

        public BaltaDataContext(){
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose(){
            if(Connection.State != ConnectionState.Closed){

            }
        }
    }
}