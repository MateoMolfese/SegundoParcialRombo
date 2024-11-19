using SegundoParcialRombo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombos
    {
        private List<Rombo> rombos;
        private string? nombreArchivo = "Rombos.txt";
        private string? rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;
        public RepositorioRombos()
        {
            rombos = leerDatos();
        }
        public void AgregarRombo(Rombo rombo)
        {
            rombos.Add(rombo);
        }
        public void EliminarRombo(Rombo rombo)
        {
            rombos.Remove(rombo);
        }
        public bool Existe(Rombo rombo)
        {
            return rombos.Any(e => e.DiagonalMenor == rombo.DiagonalMenor &&
                e.DiagonalMayor == rombo.DiagonalMenor);
        }

        public List<Rombo>? Filtrar(Contorno ContornoSeleccionado)
        {
            return rombos.Where(e => e.TipoBorde == ContornoSeleccionado).ToList();
        }

        public int GetCantidad(Contorno? ContornoSeleccionado = null)
        {
            if (ContornoSeleccionado == null)
                return rombos.Count;
            return rombos.Count(e => e.TipoBorde == ContornoSeleccionado);
        }
        public List<Rombo> ObtenerRombos()
        {
            return new List<Rombo>(rombos);
        }
        public List<Rombo>? OrdenarAsc()
        {
            return rombos.OrderBy(e => e.Area()).ToList();
        }

        public List<Rombo>? OrdenarDesc()
        {
            return rombos.OrderByDescending(e => e.Area()).ToList();
        }
        public bool Existe(int dM, int dm)
        {
            return rombos.Any(e => e.DiagonalMayor == dM &&
            e.DiagonalMenor == dm);
        }
        public void GuardarDatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            using (var escritor = new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var rombo in rombos)
                {
                    string linea = ConstruirLinea(rombo);
                    escritor.WriteLine(linea);
                }
            }
        }

        private string ConstruirLinea(Rombo rombo)
        {
            return $"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.TipoBorde.GetHashCode()}";
        }

        private List<Rombo>? leerDatos()
        {
            var listaRombos = new List<Rombo>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            if (!File.Exists(rutaCompletaArchivo))
            {
                return listaRombos;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string? linea = lector.ReadLine();
                    Rombo? rombo = ConstruirRombo(linea);
                    listaRombos.Add(rombo!);
                }
            }
            return listaRombos;
        }

        private Rombo? ConstruirRombo(string? linea)
        {
            var campos = linea!.Split('|');
            var dM = int.Parse(campos[0]);
            var dm = int.Parse(campos[1]);
            var tipoBorde = (Contorno)int.Parse(campos[2]);
            return new Rombo(dM, dm, tipoBorde);
        }
    }
}
