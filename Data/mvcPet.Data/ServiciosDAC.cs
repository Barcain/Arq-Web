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
            //  Aquí persisto los valores que corresponden a la tabla TipoServicio.
            const string SQL_STATEMENT = "INSERT INTO TipoServicio ([Nombre]) VALUES(@Nombre); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, servicios.Nombre);
                servicios.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            //  Aquí persisto los valores que corresponden a la tabla Precio.           
            const string SQL_STATEMENT2 = "INSERT INTO Precio ([TipoServicioId], [FechaDesde], [FechaHasta], [Valor]) VALUES(@TipoServicioId, @FechaDesde, @FechaHasta, @Valor); SELECT SCOPE_IDENTITY();";
            servicios.TipoServicioId = servicios.Id;
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT2))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, servicios.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.Date, servicios.FechaDesde.Date.ToString("yyyy-MM-dd"));
                db.AddInParameter(cmd, "@FechaHasta", DbType.Date, servicios.FechaHasta.Date.ToString("yyyy-MM-dd"));
                db.AddInParameter(cmd, "@Valor", DbType.Decimal, servicios.Valor);
                servicios.IdPrecio = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return servicios;
        }

        public List<Servicios> Read()
        {
            const string SQL_STATEMENT = "SELECT TS.[Id], TS.[Nombre], P.[TipoServicioId], P.[FechaDesde], P.[FechaHasta], P.[Valor], P.[IdPrecio] FROM TipoServicio TS, Precio P WHERE TS.[Id] = P.[TipoServicioId] ";

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
            const string SQL_STATEMENT = "SELECT TS.[Id], TS.[Nombre], P.[TipoServicioId], P.[FechaDesde], P.[FechaHasta], P.[Valor], P.[IdPrecio] FROM TipoServicio TS JOIN Precio P ON TS.[Id] = P.[TipoServicioId] WHERE TS.[Id] = @Id ";
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
            //  Aquí modifico los valores que corresponden a la tabla TipoServicio.
            const string SQL_STATEMENT = "UPDATE TipoServicio SET [Nombre]= @Nombre WHERE Id = @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, servicios.Nombre);
                db.ExecuteNonQuery(cmd);
            }

            //  Aquí modifico los valores que corresponden a la tabla Precio.           
            const string SQL_STATEMENT2 = "UPDATE Precio SET [TipoServicioId]= @TipoServicioId, [FechaDesde]= @FechaDesde, [FechaHasta]= @FechaHasta, [Valor]= @Valor WHERE [IdPrecio]= @IdPrecio ";
            
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT2))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, servicios.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.Date, servicios.FechaDesde.Date.ToString("yyyy-MM-dd"));
                db.AddInParameter(cmd, "@FechaHasta", DbType.Date, servicios.FechaHasta.Date.ToString("yyyy-MM-dd"));
                db.AddInParameter(cmd, "@Valor", DbType.Decimal, servicios.Valor);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoServicio WHERE [Id]= @Id ";

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
            servicios.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            servicios.FechaDesde = GetDataValue<DateTime>(dr, "FechaDesde");
            servicios.FechaHasta = GetDataValue<DateTime>(dr, "FechaHasta");
            servicios.Valor = GetDataValue<decimal>(dr, "Valor");
            servicios.IdPrecio = GetDataValue<int>(dr, "IdPrecio");
            return servicios;
        }
    }
}

