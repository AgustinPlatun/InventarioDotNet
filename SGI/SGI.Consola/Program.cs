using Microsoft.VisualBasic;
using SGI.Repositorios;
using System.IO;

Menu menu = new Menu();
while(!menu.opcion.Equals("0"))
{
    menu.invocarMenu();
    menu.opcion = Console.ReadLine() ?? "999";
    menu.elegirOpciones();
}
Console.ReadKey();

//asdsad