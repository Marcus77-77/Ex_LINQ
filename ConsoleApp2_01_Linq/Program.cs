using ConsoleApp2_01_Linq;





/////////////////////////////////////////////////
//       1St Exercise(Done in Class)          //
///////////////////////////////////////////////


internal class Program
{
    private static void Main(string[] args)
    {
        static List<Person> GetPeople()
        {
            return new List<Person>()
              {
                  new Person { Id = 1, Name = "Mario", Surname = "Neri", Age = 32, City = "Torino" },
                  new Person { Id = 2, Name = "Giulia", Surname = "Verdi", Age = 20, City = "Roma" },
                  new Person { Id = 3, Name = "Marco", Surname = "Azzurro", Age = 19, City = "Domodossola" },
                  new Person { Id = 4, Name = "Andrea", Surname = "Violetta", Age = 35, City = "Salerno" },
                  new Person { Id = 5, Name = "Renato", Surname = "Grigi", Age = 50, City = "Ronchi" },
                  new Person { Id = 6, Name = "Fabio", Surname = "Viola", Age = 100, City = "Savona" }
              };

        }

        //1) a list of strings with only the names(use `Select`)

        var person = GetPeople();
        var names = person
            .Select(p => p.Name)
            .ToList();


        // 2) a list of strings where every string is Name+Surname of the original Person (use `Select`)

        var namesSurnames = person
          .Select(p => $"{p.Name} {p.Surname}");

        // 3) the average `Age` (use `Aggregate` to accumulate the sum of the `Age` and then divide by the count of people)

        var averageAge = person.Aggregate(0.0, (ageSum, currentPerson) => ageSum += currentPerson.Age) / person.Count();

        // 4) a list of cities and how many people in every city (use `GroupBy` and then `Select`)

        var cities = person
        .GroupBy(p => p.City)
        .Select(g => new
        {
            City = g.Key,
            PeopleCount = g.Count()
        });

        // 5) a list of cities, and the average of Age of every city
        // (use `GroupBy`, then `Select`, and in the `Select` use `Aggregate` to calculate the average)

        var citiesWithAverages = person
        .GroupBy(p => p.City)
         .Select(g => new
         {
             City = g.Key,
             AverageAge = g.Average(p => p.Age),
         });

        /////////////////////////////////////////////////
        //       2nd Exercise                         //
        ///////////////////////////////////////////////

        static List<Room> GetRoom()
        {
            return new List<Room>()
              {
                  new Room {Length = 50 , Height = 3, Width = 10 },
                  new Room {Length = 25 , Height = 4, Width = 15 },
                  new Room {Length = 95 , Height = 5, Width = 20 },
                  new Room {Length = 30 , Height = 7, Width = 40 },
                  new Room {Length = 10 , Height = 3, Width = 90 },
                  new Room {Length = 5  , Height = 2, Width = 30 }
              };

        }

        var room = GetRoom();


        //1) a list of volumes(use `Select` to calculate the volume)

        var RoomVolume = room
            .Select(r => r.Length * r.Width * r.Height)
            .ToList();


        //2) a list of areas (use `Select` to calculate the total area of every single `Room`)

        var RoomArea = room
           .Select(r => r.Length * r.Width)
           .ToList();


        //3) The sum of all volumes (use `Sum`)
        var summedVolumes = room
            .Select(r => r.Length * r.Width * r.Height)
            .Sum();



        //4) 4) The minimum of all areas (use `Min`)
        var MinimumArea = room
            .Select(r => r.Length * r.Width)
            .Min();



        /////////////////////////////////////////////////
        //       3rd Exercise                         //
        ///////////////////////////////////////////////



        static List<Farm> GetFarm()
        {
            return new List<Farm>()
            {
                new Farm
                {
                    Owner = "Mario Rossi",       Fields = new List<Field>()
                        {
                         new Field {Vegetable =  "Artichokes"   , Extension = 100},
                         new Field {Vegetable =  "Soy"          , Extension = 10},
                         new Field {Vegetable =  "Carrots"      , Extension = 30}
                        }
                },
                new Farm
                {
                    Owner = "Benjamin Rodrigues", Fields = new List<Field>()
                    {
                          new Field {Vegetable =  "Apples"       , Extension = 20},
                          new Field {Vegetable =  "Olives"       , Extension = 50},
                          new Field {Vegetable =  "Lettuce"      , Extension = 50}
                    }
                },
                new Farm
                {
                    Owner = "Lapo Salvia",        Fields = new List<Field>()
                    {
                          new Field {Vegetable =  "Soy"            , Extension = 250},
                          new Field {Vegetable =  "Artichokes"     , Extension = 300},
                          new Field {Vegetable =  "Lettuce"        , Extension = 80}
                    }
                },
                new Farm
                {
                    Owner = "Lorenzo Perego",        Fields = new List<Field>()
                    {
                          new Field {Vegetable =  "Bananas"        , Extension = 5},
                          new Field {Vegetable =  "Carrots"        , Extension = 500},
                          new Field {Vegetable =  "Cucumbers"      , Extension = 15}
                    }
                }
            };


        }


        //1) A flat list of `Fields` (use `SelectMany`)



        var farms = GetFarm();


        var flatlist = farms
            .SelectMany(f => f.Fields)
            .ToList();

        //2) A list of items where every item has `Vegetable` and the list of `Fields` of that `Vegetable`
        //(use `SelectMany` to flat the list, then use `GroupBy` to group by `Vegetable`, then `Select` to create the final items)

        var ListofVegetables = farms
            .SelectMany(f => f.Fields)
            .GroupBy(f => f.Vegetable)
            .ToList();

        //3) A list of items where every item has `Vegetable` and `TotalExtension` (use `SelectMany` to flat the list, then GroupBy using Vegetable as `Key`,
        //then project with Select using `Aggregate` to calculate the total extension of every group)

        var totalVegetableExtension = farms
            .SelectMany(f => f.Fields)
            .GroupBy(f => f.Vegetable)
            .Select(g => new
            {
                vegetable = g.Key,
                totalextention = g.Sum(f => f.Extension)
            })
            .ToList();


        //4) a list of `Farms` containing only the `Farms` with a total `Extension` of more than `100`

        var extentionMore100 = farms
            .SelectMany(f => f.Fields)
            .GroupBy(f => f.Vegetable)
            .Select(g => new
            {
                vegetable = g.Key,
                totalextention = g.Sum(f => f.Extension)
            })
            .Where(f => f.totalextention > 100)
            .ToList();

        //5) a list of all `Farms`, but every `Farm` must contain only the `Fields` with an `Extension` greater than `20`

        var farmWithFieldsGreater20 = farms
            .SelectMany(f => f.Fields)
            .GroupBy(f => f.Vegetable)
            .Select(g => new
            {
                vegetable = g.Key,
                extension = g.TakeWhile(f => f.Extension > 20)
            })
            .ToList();

        //6) a list of `Owners`, where every `Owner` has a `Name` and a list of `Farms` (and every `Farm` has its list of `Fields`)
        var ownerList = farms
            .Select(j => new
            {
                j.Owner,
                j.Fields
            })
            .ToList();

        //7) a list of `Owners`, where every `Owner` has a `Name` and a list of `VegetablePercentages`,
        //    where a `VegetablePercentage` has the Name of the `Vegetable` and the percentage of `Extension` of that `Vegetable` on the `Farms` of that `Owner` 
        //    (for example, `Mario` has many `Farms` and `Fields`, 
        //    for a total of 60 areas of corn and 140 areas of wheat: there will be 2 items in the `Mario`'s list, one with the infos 'Corn' and 30%, and the other with the infos 'Wheat' and 70%)
        var vegetablePercentage = farms
            .Select(j => new
            {
                j.Owner,
                j.Fields,


                percentage = j.Fields.Select(f => (double)f.Extension / j.Fields.Sum(x => x.Extension) * 100)
            })
            .ToList(); 
            
            


        Console.ReadLine();
    }
}