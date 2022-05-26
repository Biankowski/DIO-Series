using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAllSeries();
                        break;
                    case "2":
                        InsertNewSeries();
                        break;
                    case "3":
                        DeleteSerie();
                        break;
                    case "4":
                        ViewSerie();
                        break;
                    case "5":
                        UpdateSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();

            }
        }
        private static void ListAllSeries()
        {
            System.Console.WriteLine("List Series");

            var lista = repositorio.SeriesList();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Zero series on DataBase");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.ReturnDeleted();
                if (!excluido)
                {
                    System.Console.WriteLine("#ID {0}: - {1}", serie.ReturnId(), serie.ReturnTitle());
                }
            }
        }
        public static void InsertNewSeries()
        {
            System.Console.WriteLine("Insert new serie.");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            System.Console.Write("Choose Genre: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Type serie Title: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Type the Year that was made: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Type series Description: ");
            string entradaDescricao = Console.ReadLine();

            Serie newSerie = new Serie(id: repositorio.NextId(), genre: (Genre)entradaGenero,
                                    title: entradaTitulo, year: entradaAno, description: entradaDescricao);

            repositorio.Insert(newSerie);
        }
        private static void UpdateSerie()
        {
            System.Console.WriteLine("Type serie Id.");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            System.Console.Write("Choose Genre: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Type serie Title: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Type the Year that was made: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Type series Description: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genre: (Genre)entradaGenero,
                                    title: entradaTitulo, year: entradaAno, description: entradaDescricao);

            repositorio.Update(indiceSerie, atualizaSerie);
        }
        private static void DeleteSerie()
        {
            System.Console.Write("Type serie Id: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Delete(indiceSerie);
        }
        private static void ViewSerie()
        {
            System.Console.Write("Type serie Id: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.ReturnById(indiceSerie);
            System.Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Welcome to your Movies and Tv Shows Hub!!!");
            System.Console.WriteLine("Choose one option: ");

            System.Console.WriteLine("1) List series: ");
            System.Console.WriteLine("2) Insert new serie: ");
            System.Console.WriteLine("3) Update serie: ");
            System.Console.WriteLine("4) Delete serie: ");
            System.Console.WriteLine("5) View serie: ");
            System.Console.WriteLine("C) Clear screen: ");
            System.Console.WriteLine("X) Exit: ");
            System.Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return userOption;
        }
    }
}