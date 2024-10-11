using System;

namespace SGI.Aplicacion;
    public class Categoria
    {
        private String path = "../SGI.Repositorios/listadoCategorias.txt";
        private int _id;
        private String _nombre;
        private String _descripcion;
        private DateTime _fechaCreacion;
        private DateTime _fechaUltimaModificacion;

        // Constructores de instancia
        public Categoria(int id, String nombre, String descripcion)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _fechaCreacion = DateTime.Now;
            _fechaUltimaModificacion = DateTime.Now;
                using (StreamWriter arch = new StreamWriter(path,true))
            {
                arch.WriteLine($"{_id},{nombre},{descripcion},{_fechaCreacion},{_fechaUltimaModificacion}");
            }
        }

        /* 
        Getters y Setters. 
        Descriptores de acceso(accessors)
        */
        public int Id 
        {
            get
            {
                return _id;
            }
        }
        public String Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                _fechaUltimaModificacion = DateTime.Now;
            }
        }
        public String Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
                _fechaUltimaModificacion = DateTime.Now;
            }
        }
        public DateTime FechaUltimaModificacion 
        {
            get
            {
                return _fechaUltimaModificacion;
            }
        }
        public DateTime FechaCreacion
        {
            get
            {
                return _fechaCreacion;
            }
        }

    }

 