namespace leerMp3
{
    class Id3v1Tag
    {
        public string header { get; set; }
        public string titulo { get; set; }
        public string artista { get; set; }
        public string album { get; set; }
        public string anio { get; set; }

        public void cargarId3v1Tag()
        {
            bool existeArchivo;
            string nombreArchivo;
            do
            {
                Console.WriteLine("Ingrese el nombre del archivo .mp3");
                nombreArchivo = Console.ReadLine();
                existeArchivo = File.Exists(nombreArchivo);
                if (!existeArchivo)
                {
                    Console.WriteLine("Ingrese un nombre del archivo valido");
                   // Console.WriteLine($"Ruta ingresada: {nombreArchivo}");
                }
            } while (!existeArchivo);

            byte[] buffer = new byte[128];
            using (FileStream archivoMp3 = new FileStream(nombreArchivo, FileMode.Open))
            using (BinaryReader br = new BinaryReader(archivoMp3))
            {
                if (archivoMp3.Length >= 128)
                {
                    archivoMp3.Seek(-128, SeekOrigin.End);
                    buffer = br.ReadBytes(128);
                    header = System.Text.Encoding.ASCII.GetString(buffer, 0, 3);
                    if (header == "TAG")
                    {
                        titulo = System.Text.Encoding.ASCII.GetString(buffer, 3, 30);
                        artista = System.Text.Encoding.ASCII.GetString(buffer, 33, 30);
                        album = System.Text.Encoding.ASCII.GetString(buffer, 63, 30);
                        anio = System.Text.Encoding.ASCII.GetString(buffer, 93, 4);
                    }
                }
            }
        }
        public void mostrarDatos()
        {
            Console.WriteLine($"El titulo de la cancion es[{titulo}]");
            Console.WriteLine($"El nombre del artista es[{artista}]");
            Console.WriteLine($"El nombre del album es[{album}]");
            Console.WriteLine($"El año es[{anio}]");
        }
     }
 
}