using Microsoft.VisualBasic;
using SGI.Aplicacion;
using System.IO;

Menu menu = new Menu();
menu.elegirOpciones();
while(menu.Opcion != "0"){
    menu.invocarMenu();
    menu.Opcion = Console.ReadLine();
    menu.elegirOpciones();
}
Console.ReadKey();