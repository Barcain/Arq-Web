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
    public partial class CitaDAC : DataAccessComponent, IRepository<Cita>
    {
        public Cita Create(Cita cita)
        {
            const string SQL_STATEMENT = "INSERT INTO Sala ([Nombre], [TipoSala]) VALUES(@Nombre, @TipoSala); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
               /* db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, sala.Nombre);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, sala.TipoSala);*/
                cita.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return cita;
        }

        public List<Cita> Read(DateTime today)
        {
            DateTime date = today.Date;

            const string SQL_STATEMENT = "SELECT [Id], [Fecha], [MedicoId], [PacienteId], [SalaId], [TipoServicioId], [Estado], [CreatedBy], [CreatedDate], [ChangedBy], [ChangedDate], [DeletedBy], [DeletedDate], [Deleted] FROM Cita WHERE [Fecha]=@date ";

            List<Cita> result = new List<Cita>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@date", DbType.DateTime, date);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cita cita = LoadCita(dr);
                        result.Add(cita);
                    }
                }
            }
            return result;
        }

        //  This method is used to crate a custom list of Turns of the desired date.
        public List<ListaTurnos> CreateList(FechaTurno dateToSearch)
        {
            string date = dateToSearch.FechaConsulta;

            const string SQL_STATEMENT = "SELECT T.[Id], T.[Fecha], T.[MedicoId], M.[Apellido] AS MApellido, M.[Nombre] AS MNombre, T.[PacienteId], P.[Nombre] AS PNombre, T.[SalaId], S.[Nombre] AS SNombre, T.[TipoServicioId], TS.[Nombre] AS TSNombre, T.[Estado], T.[Deleted] FROM Cita T JOIN Medico M ON T.[MedicoId] = M.[Id] JOIN Paciente P ON t.[PacienteId] = P.[Id] JOIN Sala S ON T.[SalaId] = S.[Id] JOIN TipoServicio TS On T.[TipoServicioId] = TS.[Id] WHERE T.[Fecha]=@date AND T.[Deleted]=0";

            List<ListaTurnos> result = new List<ListaTurnos>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@date", DbType.DateTime, date);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ListaTurnos turno = LoadListaTurnos(dr);
                        result.Add(turno);
                    }
                }
            }
            return result;
        }


        public Cita ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala WHERE [Id]=@Id ";
            Cita cita = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cita = LoadCita(dr);
                    }
                }
            }
            return cita;
        }

        public void Update(Cita cita)
        {
            const string SQL_STATEMENT = "UPDATE Sala SET [Nombre]= @Nombre, [TipoSala]= @TipoSala WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                /*db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, sala.TipoSala);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, sala.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, sala.Id);*/
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Sala WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Cita LoadCita(IDataReader dr)
        {
            Cita cita = new Cita();
            cita.Id = GetDataValue<int>(dr, "Id");
            cita.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            cita.MedicoId = GetDataValue<int>(dr, "MedicoId");
            cita.PacienteId = GetDataValue<int>(dr, "PacienteId");
            cita.SalaId = GetDataValue<int>(dr, "SalaId");
            cita.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            cita.Estado = GetDataValue<string>(dr, "Estado");
            cita.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            cita.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");
            cita.ChangedBy = GetDataValue<int>(dr, "ChangedBy");
            cita.ChangedDate = GetDataValue<DateTime>(dr, "ChangedDate");
            cita.DeletedBy = GetDataValue<int>(dr, "DeletedBy");
            cita.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");
            cita.Deleted = GetDataValue<Boolean>(dr, "Deleted");
            return cita;
        }

        private ListaTurnos LoadListaTurnos(IDataReader dr)
        {
            ListaTurnos turno = new ListaTurnos();
            turno.Id = GetDataValue<int>(dr, "Id");

            DateTime fech = GetDataValue<DateTime>(dr, "Fecha");
            turno.Fecha = fech.Date.ToString("dd/MM/yyyy");
            turno.Hora = fech.Hour.ToString();

            turno.MedicoId = GetDataValue<int>(dr, "MedicoId");
            turno.NMedico = GetDataValue<string>(dr, "MNombre") + " " + GetDataValue<string>(dr, "MApellido");
            turno.PacienteId = GetDataValue<int>(dr, "PacienteId");
            turno.NPaciente = GetDataValue<string>(dr, "PNombre");
            turno.SalaId = GetDataValue<int>(dr, "SalaId");
            turno.NSala = GetDataValue<string>(dr, "SNombre");
            turno.NServicio = GetDataValue <string>(dr, "TSNombre");
            turno.Estado = GetDataValue<string>(dr, "Estado");
           
            return turno;
        }

        public List<Cita> Read()
        {
            throw new NotImplementedException();
        }
    }
}

