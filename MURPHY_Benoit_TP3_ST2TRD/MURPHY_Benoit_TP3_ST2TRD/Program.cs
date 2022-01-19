using System;
using System.Linq;


namespace MURPHY_Benoit_TP3_ST2TRD
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Display the title of the oldest movie: ");
            var context = new MovieCollection();
            var old =
                (from wdm in context.Movies
                 orderby wdm.ReleaseDate ascending
                 select wdm).First();
            Console.WriteLine(old.Title);

            Console.WriteLine("\n2 - Count all movies: ");
            var allMovies =
                (from wdm in context.Movies
                 select wdm).Count();
            Console.WriteLine(allMovies);

            Console.WriteLine("\n3 - Count all movies with the letter 'e' at least once in the title: ");
            var letterE =
                (from wdm in context.Movies
                 where wdm.Title.Contains("e") == true
                 select wdm).Count();
            Console.WriteLine(letterE);

            Console.WriteLine("\n4 - Count how many time the letter 'f' is in all the titles from this list: ");
            var letterF =
                (from wdm in context.Movies
                 select wdm.Title.Count(letterF => letterF == 'f')).Sum();
            Console.WriteLine("{0} times \n", letterF);

            Console.WriteLine("\n5 - Display the title of the film with the higher budget: ");
            var hB =
                (from wdm in context.Movies
                 orderby wdm.Budget descending
                 select wdm).First();
            Console.WriteLine(hB.Title);

            Console.WriteLine("\n6 - Display the title of the movie with the lowest box office: ");
            var lB =
                (from wdm in context.Movies
                 orderby wdm.BoxOffice ascending
                 where (wdm.BoxOffice != null && wdm.BoxOffice >1000)
                 select wdm).First();
            Console.WriteLine(lB.Title);

            Console.WriteLine("\n7 - Order the movies by reversed alphabetical order and print the first 11 of the list:\n");
            var x =
                (from wdm in context.Movies
                 orderby wdm.Title ascending
                 select wdm.Title).Take(11);
            int i = 1;
            foreach (string m in x)
            {
                Console.WriteLine(" ({0}) {1}\n", i, m);
                i++;
            }

            Console.WriteLine("\n8- Count all the movies made before 1980: ");
            var y =
                (from wdm in context.Movies
                where wdm.ReleaseDate < new DateTime(1980, 01, 01)
                select wdm).Count();

            Console.WriteLine(y);

            Console.WriteLine("\n9 - Display the average running time of movies having a vowel as the first letter: ");
            char[] vowels = new[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            var avg =
                (from wdm in context.Movies
                where vowels.Contains(wdm.Title[0])
                select wdm.RunningTime).Average();

            Console.WriteLine(avg);

            Console.WriteLine("\n10 - Print all movies with the letter H or W in the title, but not the letter I or T: \n");
            var w =
                from wdm in context.Movies
                where ((wdm.Title.ToLower().Contains('h') || wdm.Title.ToLower().Contains('w')) && ( wdm.Title.ToLower().Contains('i') == false || wdm.Title.ToLower().Contains('t') == false ))
                select wdm.Title;
            foreach (string m in w)
            {
                Console.WriteLine("   " + m);
            }

            Console.WriteLine("\n11 - Calculate the mean of all Budget / Box Office of every movie ever: ");
            var mean =
                (from wdm in context.Movies
                where (wdm.BoxOffice != null && wdm.Budget != null && (wdm.Budget / wdm.BoxOffice) < 50 )
                select (wdm.Budget / wdm.BoxOffice)).Average();
            Console.WriteLine(mean);

            Console.WriteLine("\n12 - Group all films by the number of characters in the title screen and print the count of movies by letter in the film: \n");
            var nb =
                from wdm in (from wdm in context.Movies
                           group wdm.Title by wdm.Title.Length into newgroup
                           select newgroup)
                orderby wdm.Key ascending
                select wdm;
            foreach (var a in nb)
            {
                Console.WriteLine("  " + a.Key + " char => " + a.Count() + " films \n");
            }

            Console.WriteLine("\n13 - Calculate the mean of all Budget / Box Office of every movie grouped by yearly release date\n");
            var mn =
                (from a in (from wdm in context.Movies
                            where (wdm.BoxOffice != null && wdm.Budget != null)
                            group (wdm.Budget/wdm.BoxOffice) by wdm.ReleaseDate.Year into newgroup
                            select newgroup)
                orderby a.Key ascending
                select a);
            foreach (var a in mn)
            {
                Console.WriteLine("  " + a.Key + " => " + "$" + a.Average() + "\n");
            }


            Ex2 exo2 = new Ex2();
            Ex2.Space();

        }

    }
}