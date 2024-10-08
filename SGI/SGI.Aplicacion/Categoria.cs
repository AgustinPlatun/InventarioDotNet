using System;

namespace SGI.Repositorios;
    public class Categoria
    {
        private int _id;
        private String _nombre;
        private String _descripcion;
        private DateTime _fechaCreacion;
        private DateTime _fechaUltimaModificacion;

        // Constructores de instancia
        public Categoria(int id, String nombre, String descripcion)
        {
            StreamWriter archivo = new StreamWriter("../SGI.Repositorios/listadoCategorias.txt");

            _id = id;
            _nombre = nombre;
            CategoriaValidador validadorCat= new CategoriaValidador(nombre);
            validadorCat.validacionException(); // Sujeto a cambios. Mañana preguntar.
            _descripcion = descripcion;
            _fechaCreacion = DateTime.Now;
            _fechaUltimaModificacion = DateTime.Now;
            archivo.WriteLine($"{_id},{_nombre},{_descripcion},{_fechaCreacion},{_fechaUltimaModificacion}");
            archivo.Close();
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
        public String nombre
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
        public String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                descripcion = descripcion;
                _fechaUltimaModificacion = DateTime.Now;
            }
        }
        public DateTime fechaUltimaModificacion 
        {
            get
            {
                return _fechaUltimaModificacion;
            }
        }
        public DateTime fechaCreacion
        {
            get
            {
                return _fechaCreacion;
            }
        }

    }

 