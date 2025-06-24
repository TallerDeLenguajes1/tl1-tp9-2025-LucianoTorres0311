
bool existeArchivo;
string ruta;
do
{
    Console.WriteLine("Ingrese la direccion del archivo .mp3");
    ruta = Console.ReadLine();
    existeArchivo = File.Exists(ruta);
    if (!existeArchivo)
    {
        Console.WriteLine("Ingrese una ruta valida");
    }
} while (!existeArchivo);
byte[] buffer = new byte[128];
using (FileStream archivoMp3 = new FileStream(ruta, FileMode.Open))
{
    archivoMp3.Read(buffer, 3, 93);
    


}
