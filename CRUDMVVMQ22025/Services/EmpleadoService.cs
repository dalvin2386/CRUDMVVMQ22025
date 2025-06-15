

using Android.Telecom;
using CRUDMVVMQ22025.Models;
using SQLite;

namespace CRUDMVVMQ22025.Services
{
    public class EmpleadoService

    {
        private readonly SQLiteConnection _connection;

        public EmpleadoService()
        {
            //Path to storage database
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Empleado.db3");
            _connection = new SQLiteConnection(dbPath);

            //crear tabla
            _connection.CreateTable<Empleado>();
        }

        public List<Empleado> GetAll()
        {
            //It's equal to SELECT * FROM Empleado
            return _connection.Table<Empleado>().ToList();
        
        }
        public int Insert(Empleado empleado)
        {
           //It's equal to INSERT Empleado VALUES....
            return _connection.Insert(empleado);
        }

        public int Update(Empleado empleado)
        {
            //It's equal UPDATE Empleado set xxxx=xxx Where id = xx
            return _connection.Update(empleado);
        }

        //It's equal to DELETE FROM EMpleado WHERE id=xxx
        public int Delete(Empleado empleado)
        {
            return _connection.Delete(empleado);
        }
    }
}
