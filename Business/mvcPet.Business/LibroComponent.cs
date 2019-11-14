using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Libreria.Business
{
    public partial class LibroComponent
    {
        //  Hecho
        public Libro Agregar(Libro libro)
        {
            Libro result = default(Libro);
            var libroDAC = new LibroDAC();
            result = libroDAC.Create(libro);
            return result;
        }

        //  Hecho
        public List<Libro> ListarTodos()
        {
            List<Libro> result = default(List<Libro>);
            var libroDAC = new LibroDAC();
            result = libroDAC.Read();
            return result;

        }
       
        //  Hecho
        public void Eliminar(int id)
        {
            var libroDAC = new LibroDAC();
            libroDAC.Delete(id);

        }

        public void Editar(Cliente model)
        {

            var clienteDAC = new ClienteDAC();
            clienteDAC.Update(model);

        }

        public Cliente FindBy(int id)
        {
            var clienteDAC = new ClienteDAC();
            return clienteDAC.ReadBy(id);

        }
    }
}
