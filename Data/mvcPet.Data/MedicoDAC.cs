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
    public partial class MedicoDAC : DataAccessComponent, IRepository<Medico>
    {
        public Medico Create(Medico medico)
        {
            const string SQL_STATEMENT = "INSERT INTO Medico ([TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Especialidad], [FechaNacimiento], [Email], [Telefono]) VALUES(@TipoMatricula, @NumeroMatricula, @Apellido, @Nombre, @Especialidad, @FechaNacimiento, @Email, @Telefono); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                medico.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, medico.NumeroMatricula);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, medico.Especialidad);
                
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, medico.FechaNacimiento.Date); // Con .Date me quedo solamente con la fecha sil la hora.
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);

            }
            return medico;
        }

        public List<Medico> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Especialidad], [FechaNacimiento], [Email], [Telefono] FROM Medico ";

            List<Medico> result = new List<Medico>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Medico medico = LoadMedico(dr);
                        result.Add(medico);
                    }
                }
            }
            return result;
        }

        public Medico ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Especialidad], [FechaNacimiento], [Email], [Telefono] FROM Medico WHERE [Id]=@Id ";
            Medico medico = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        medico = LoadMedico(dr);
                    }
                }
            }
            return medico;
        }

        public void Update(Medico medico)
        {
            const string SQL_STATEMENT = "UPDATE Medico SET [TipoMatricula]= @TipoMatricula, [NumeroMatricula]= @NumeroMatricula, [Apellido]= @Apellido, [Nombre]= @Nombre, [Especialidad]= @Especialidad, [FechaNacimiento]= @FechaNacimiento, [Email]= @Email, [Telefono]= @Telefono WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, medico.Id);                
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, medico.NumeroMatricula);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                db.AddInParameter(cmd, "@especialidad", DbType.AnsiString, medico.Especialidad);

                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, medico.FechaNacimiento.Date); // Con .Date me quedo solamente con la fecha sil la hora.
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);

                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Medico WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Medico LoadMedico(IDataReader dr)
        {
            Medico medico = new Medico();

            medico.Id = GetDataValue<int>(dr, "Id");
            medico.TipoMatricula = GetDataValue<string>(dr, "TipoMatricula");
            medico.NumeroMatricula = GetDataValue<int>(dr, "NumeroMatricula");
            medico.Apellido = GetDataValue<string>(dr, "Apellido");
            medico.Nombre = GetDataValue<string>(dr, "Nombre");
            medico.Especialidad = GetDataValue<string>(dr, "Especialidad");
            medico.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            medico.Email = GetDataValue<string>(dr, "Email");
            medico.Telefono = GetDataValue<string>(dr, "Telefono");
            return medico;
        }
    }
}

