public class CategoriaValidador(String nombre){
         public void validacionException()
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre NO puede estar vacio.");
            }
        }   
}
// Sujeto a cambios. mañana preguntar.