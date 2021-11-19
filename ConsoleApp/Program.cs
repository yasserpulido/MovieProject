using Core.Entities;
using Core.Services;

namespace HelloWorld
{
    class Program
    {
        public static MovieService movieService { get; set; }

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Administrator to CRUD Movie information.");
            Console.WriteLine("[1].Create");
            Console.WriteLine("[2].Read");
            Console.WriteLine("[3].Update");
            Console.WriteLine("[4].Delete");
            Console.WriteLine("[5].Exit");
            Console.WriteLine("");
            int optionSelected = ChooseMenu(1, 5);
            switch (optionSelected)
            {
                case 1:
                    CreateMovie();
                    break;
                default:
                    break;
            }
        }

        static int ChooseMenu(int min, int max)
        {
            int optionMenu = -1;
            bool validateMenu = true;
            while (validateMenu)
            {
                Console.Write("Type an option: ");
                while (!int.TryParse(Console.ReadLine(), out optionMenu))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                }
                if (optionMenu >= min && optionMenu <= max)
                {
                    validateMenu = false;
                }
                else
                {
                    Console.Write($"Please enter an integer value between {min}-{max}: ");
                    validateMenu = true;
                }
            }
            return optionMenu;
        }

        static async void CreateMovie()
        {
            Console.WriteLine("Type the following data to create the movie file:");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Movie movie = new Movie();
            FillFile(movie);

            Console.ForegroundColor = ConsoleColor.Gray;

            bool result = await movieService.CreateMovie(movie);
            Console.WriteLine("");

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The movie was created succesfully.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The movie was not created.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("");
            Console.WriteLine("Do you want to add another movie?");
            Console.WriteLine("[1].Yes");
            Console.WriteLine("[2].No");
            Console.WriteLine("");
            int optionSelected = ChooseMenu(1, 2);
            switch (optionSelected)
            {
                case 1:
                    CreateMovie();
                    break;
                case 2:
                    Menu();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void FillFile(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}