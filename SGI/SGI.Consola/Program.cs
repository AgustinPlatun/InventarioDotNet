using Microsoft.VisualBasic;
using SGI.Aplicacion;
using System.IO;

Menu menu = new Menu();
menu.ingresarUsuario();
while(menu._Opcion != "0")
{
    menu.invocarMenu();
    menu.elegirOpcion();
}

Console.ReadKey();