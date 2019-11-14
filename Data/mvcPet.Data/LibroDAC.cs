using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Libreria.Data
{
    public partial class LibreriaDAC : DataAccessComponent, IRepository<Libreria>
    {
        public Libro Create(Libro libro)
        {
            const string SQL_STATEMENT = "INSERT INTO Libro ([Titulo], [Nombre], [Email], [Telefono], [Url], [FechaNacimiento], [Domicilio]) VALUES(@Apellido, @Nombre, @Email, @Telefono, @Url, @FechaNacimiento, @Domicilio); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                            
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);               
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, cliente.Url);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, cliente.FechaNacimiento.Date.ToString("yyyy-MM-dd"));
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);
                cliente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return cliente;
        }

        public List<Libro> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Titulo], [Editorial], [AnioPublicacion], [Idioma], [Genero], [Observacion] FROM Libro ";

            List<Libro> result = new List<Libro>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Libro libro = LoadLibro(dr);
                        result.Add(libro);
                    }
                }
            }
            return result;
        }

        public Cliente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Apellido], [Nombre], [Email], [Telefono], [Url], [FechaNacimiento], [Domicilio] FROM Cliente WHERE [Id]=@Id ";
            Cliente cliente = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cliente = LoadCliente(dr);
                    }
                }
            }
            return cliente;
        }

        public void Update(Cliente cliente)
        {
            const string SQL_STATEMENT = "UPDATE Cliente SET [Apellido]= @Apellido, [Nombre]= @Nombre, [Email]= @Email, [Telefono]= @Telefono, [Url]= @Url, [FechaNacimiento]= @FechaNacimiento, [Domicilio]= @Domicilio WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, cliente.Id);                                
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);                
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, cliente.Url);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, cliente.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);

                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cliente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        //  Este ya está listo
        private Libro LoadLibro(IDataReader dr)
        {
            Libro libro = new Libro();

            libro.Id = GetDataValue<int>(dr, "Id");
            libro.Titulo = GetDataValue<string>(dr, "Titulo");
            libro.Editorial = GetDataValue<int>(dr, "Editorial");
            libro.AnioPublicacion = GetDataValue<DateTime>(dr, "AnioPublicacion");
            libro.Idioma = GetDataValue<int>(dr, "Idioma");
            libro.Genero = GetDataValue<int>(dr, "Genero");
            libro.Observacion = GetDataValue<string>(dr, "Observacion");
            
            return libro;
        }


        //  Devuelve una lista de clientes para ser utilizada en una lista desplegable.
        public List<ListaClientes> CreateListClient()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Apellido], [Nombre] FROM Cliente";

            List<ListaClientes> lista = new List<ListaClientes>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ListaClientes cliente = LoadClienteList(dr);
                        lista.Add(cliente);
                    }
                }
            }
            return lista;
        }

        private ListaClientes LoadClienteList(IDataReader dr)
        {
            ListaClientes cliente = new ListaClientes();
            cliente.Id = GetDataValue<int>(dr, "Id");
            cliente.NApellido = GetDataValue<string>(dr, "Nombre") + " " + GetDataValue<string>(dr, "Apellido");

            return cliente;
        }
    }
}

