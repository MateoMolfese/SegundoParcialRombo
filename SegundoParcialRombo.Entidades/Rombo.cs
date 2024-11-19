using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        public int DiagonalMayor { get; set; }
        public int DiagonalMenor { get; set; }
        public Contorno TipoBorde { get; set; }
        public Rombo()
        {

        }
        public Rombo(int Mayor, int Menor, Contorno tipoBorde)
        {
            if (Mayor <= 0 || Menor <= 0)
            {
                throw new ArgumentException("Las diagonales deben ser mayores ser mayores que cero.");
            }
            DiagonalMayor = Mayor;
            DiagonalMenor = Menor;
            TipoBorde = tipoBorde;
        }
        public double Lado()
        {
            return Math.Sqrt((DiagonalMayor / 2) * 2 + (DiagonalMayor / 2) * 2);    
        }
        public double Perimetro()
        {
            return 4*Lado();
        }
        public double Area()
        {
            return (DiagonalMayor * DiagonalMenor) / 2;
        }
        public override string ToString()
        {
            return $"Elipse [Diag Mayor: {DiagonalMayor}, Diag Menor: {DiagonalMenor}, Borde: {TipoBorde}]";
        }
    }
}
