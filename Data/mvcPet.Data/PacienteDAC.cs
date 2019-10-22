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
    public partial class PacienteDAC : DataAccessComponent, IRepository<Paciente>
    {
        public Paciente Create(Paciente paciente)
        {
            const string SQL_STATEMENT = "INSERT INTO Paciente ([ClienteId], [Nombre], [FechaNacimiento], [EspecieId], [Observacion]) VALUES(@ClienteId, @Nombre, @FechaNacimiento, @EspecieId, @Observacion); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ClienteId", DbType.Int32, paciente.ClienteId);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, paciente.FechaNacimiento);
                db.AddInParameter(cmd, "@EspecieId", DbType.Int32, paciente.EspecieId);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return paciente;
        }

        public List<Paciente> Read()
        {
            const string SQL_STATEMENT = "SELECT P.[Id], P.[ClienteId], C.[Apellido] AS CApellido, C.[Nombre] AS CNombre, P.[Nombre], P.[FechaNacimiento], P.[EspecieId], E.[Nombre] AS ENombre, P.[Observacion] FROM Paciente P JOIN Cliente C ON P.[ClienteId] = C.[Id] JOIN Especie E ON P.[EspecieId] = E.[Id]";

            List<Paciente> result = new List<Paciente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Paciente paciente = LoadPaciente(dr);
                        result.Add(paciente);
                    }
                }
            }
            return result;
        }

        public Paciente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT P.[Id], P.[ClienteId], C.[Apellido] AS CApellido, C.[Nombre] AS CNombre, P.[Nombre], P.[FechaNacimiento], P.[EspecieId], E.[Nombre] AS ENombre, P.[Observacion] FROM Paciente P JOIN Cliente C ON P.[ClienteId] = C.[Id] JOIN Especie E ON P.[EspecieId] = E.[Id] WHERE P.Id = @Id";
            Paciente paciente = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        paciente = LoadPaciente(dr);
                    }
                }
            }
           return paciente;
        }
         
                
        public void Update(Paciente paciente)
        {
            const string SQL_STATEMENT = "UPDATE Paciente SET [ClienteId]= @ClienteId, [Nombre]= @Nombre, [FechaNacimiento]= @FechaNacimiento, [EspecieId]= @EspecieId, [FechaNacimiento]= @FechaNacimiento, [Observacion]= @Observacion WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ClienteId", DbType.Int32, paciente.ClienteId);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, paciente.FechaNacimiento);
                db.AddInParameter(cmd, "@EspecieId", DbType.Int32, paciente.EspecieId);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Paciente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Paciente LoadPaciente(IDataReader dr)
        {
            Paciente paciente = new Paciente();
            paciente.Id = GetDataValue<int>(dr, "Id");
            paciente.ClienteId = GetDataValue<int>(dr, "ClienteId");
            paciente.Cliente = GetDataValue<string>(dr, "CNombre") + " " + GetDataValue<string>(dr, "CApellido");
            paciente.Nombre = GetDataValue<string>(dr, "Nombre");
            paciente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            paciente.EspecieId = GetDataValue<int>(dr, "EspecieId");
            paciente.ENombre = GetDataValue<string>(dr, "ENombre");
            paciente.Observacion = GetDataValue<string>(dr, "Observacion");
            return paciente;
        }

        //  Devuelve una lista de pacientes para ser utilizada en una lista desplegable.
        public List<ListaPacientes> CreateListPatient()
        {
            const string SQL_STATEMENT_2 = "SELECT [Id], [Nombre] FROM Paciente";

            List<ListaPacientes> lista = new List<ListaPacientes>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT_2))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ListaPacientes especie = LoadEspecieList(dr);
                        lista.Add(especie);
                    }
                }
            }
            return lista;
        }

        private ListaPacientes LoadEspecieList(IDataReader dr)
        {
            ListaPacientes paciente = new ListaPacientes();
            paciente.Id = GetDataValue<int>(dr, "Id");
            paciente.PNombre = GetDataValue<string>(dr, "Nombre");

            return paciente;
        }
    }
}

