using ArrayCubos.Entidades;
using ArrayObjetos.Entidades;

namespace ArrayObjetos.Datos
{
    public class RepositorioDeCubos
    {
        private readonly string _archivo = Environment.CurrentDirectory + "\\Objetos.txt";
        private readonly string _archivoCopia = Environment.CurrentDirectory + "\\Objetos.bak";
        private List<Cubo> listaCubos;

        public RepositorioDeCubos()
        {
            listaCubos = new List<Cubo>();
            LeerDatos();
        }
        public List<Cubo> GetLista()
        {
            return listaCubos;
        }
        private void LeerDatos()
        {
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Cubo objeto = ConstruirObjeto(lineaLeida);
                    listaCubos.Add(objeto);
                }
                lector.Close();
            }
        }
        public void Editar(int ladoAnterior, Cubo CuboEditar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Cubo objeto = ConstruirObjeto(lineaLeida);
                        if (ladoAnterior != objeto.GetLado())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                        else
                        {
                            lineaLeida = ConstruirLinea(CuboEditar);
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
        }
        private Cubo ConstruirObjeto(string? lineaLeida)
        {
            var campos = lineaLeida.Split('|');
            int lado = int.Parse(campos[0]);
            ColorRelleno color = (ColorRelleno)int.Parse(campos[1]);
            TipodeBorde borde = (TipodeBorde)int.Parse(campos[2]);
            Cubo c = new Cubo(lado, borde, color);
            return c;
        }

        public void Agregar(Cubo objeto)
        {
            using (var escritor = new StreamWriter(_archivo, true))
            {
                string lineaEscribir = ConstruirLinea(objeto);
                escritor.WriteLine(lineaEscribir);
                escritor.Close();
            }


            listaCubos.Add(objeto);
        }
        private string ConstruirLinea(Cubo objeto)
        {
            return $"{objeto.GetLado()}|{objeto.TipoDeBorde.GetHashCode()}|{objeto.ColorRelleno.GetHashCode()}";
            
        }
        public int GetCantidad(int? valorFiltro = null)
        {
            if (valorFiltro != null)
            {
                return listaCubos.Count(c => c.GetLado() >= valorFiltro);
            }
            return listaCubos.Count;
        }
        public void Borrar(Cubo objetoBorrar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Cubo objetoLeido = ConstruirObjeto(lineaLeida);
                        if (objetoBorrar.GetLado() != objetoLeido.GetLado())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
            listaCubos.Remove(objetoBorrar);
        }
        public bool Existe(Cubo cubo)
        {
            listaCubos.Clear();
            LeerDatos();
            foreach (var itemCubo in listaCubos)
            {
                if (itemCubo.GetLado() == cubo.GetLado())
                {
                    return true;
                }
            }
            return false;
        }
        public List<Cubo> Filtrar(int intValor)
        {
            return listaCubos.Where(c => c.GetLado() >= intValor).ToList();
        }

        public List<Cubo> OrdenarAsc()
        {
            return listaCubos.OrderBy(c => c.GetLado()).ToList();
        }

        public List<Cubo> OrdenarDesc()
        {
            return listaCubos.OrderByDescending(c => c.GetLado()).ToList();
        }
    }
}