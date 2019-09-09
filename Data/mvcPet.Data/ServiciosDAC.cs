using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using mvcPet.Entities;

namespace mvcPet.Data
{
    public partial class ServiciosDAC : DataAccessComponent, IRepository<Servicios>
    {
        public Servicios Create(Servicios servicios)
        {
            const string SQL_STATEMENT = "INSERT INTO Servicios ([Nombre]) VALUES(@Nombre); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, servicios.Nombre);
                servicios.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return servicios;
        }

        public List<Servicios> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio ";

            List<Servicios> result = new List<Servicios>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Servicios servicios = LoadServicios(dr);
                        result.Add(servicios);
                    }
                }
            }
            return result;
        }

        public Servicios ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Servicios WHERE [Id]=@Id ";
            Servicios servicios = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        servicios = LoadServicios(dr);
                    }
                }
            }
            return servicios;
        }

        public void Update(Servicios servicios)
        {
            const string SQL_STATEMENT = "UPDATE Servicios SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, servicios.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, servicios.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Servicios WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Servicios LoadServicios(IDataReader dr)
        {
            Servicios servicios = new Servicios();
            servicios.Id = GetDataValue<int>(dr, "Id");
            servicios.Nombre = GetDataValue<string>(dr, "Nombre");
            return servicios;
        }
    }
}

