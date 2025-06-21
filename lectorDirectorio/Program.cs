using System.Formats.Asn1;

bool existeDirectorio;
string path;
do
{
    Console.WriteLine("Ingrese la direccion del directorio que desea consultar");
    path = Console.ReadLine();
    existeDirectorio = Directory.Exists(path);
    if (!existeDirectorio)
    {
        Console.WriteLine("Ingrese una direccion valida");
    }
} while (!existeDirectorio);
string[] carpetas = Directory.GetDirectories(path);
string[] archivos = Directory.GetFiles(path);
foreach (var carpeta in carpetas)
{
    Console.WriteLine($"Nombre de la carpeta[{Path.GetFileName(carpeta)}]");
}
string pathCsv = Path.Combine(path, "reporte_archivo.csv");
using (StreamWriter archivoStream = new StreamWriter(pathCsv))
{
    archivoStream.WriteLine("Nombre del archivo, Tamaño del archivo(KB), fecha de ultima modificacion");
    foreach (var archivo in archivos)
    {
        FileInfo info = new FileInfo(archivo);
        string fecha = info.LastWriteTime.ToString("dd-MM-yyyy");
        string nombre = Path.GetFileName(archivo);
        double pesoKb = info.Length / 1024.00;
        Console.WriteLine($"Nombre del archivo[{nombre}], fecha de modificacion[{fecha}]su peso es[{pesoKb:F2}]");
        archivoStream.WriteLine($"{nombre},{pesoKb:F2},{fecha}");
    }
}
