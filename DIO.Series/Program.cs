using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            Serie lSerie = new Serie(SerieRepository.GetInstance());
              lSerie.Titulo("x")
                .Descricao("Teste")
                .Save();
            Console.WriteLine("Resultado: ");
            Console.WriteLine(lSerie.ToString());
        }
    }
}
