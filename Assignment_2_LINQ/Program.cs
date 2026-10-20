using LINQ.DataSources;
using LINQ.Models;
namespace Assignment_2_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Q1:
            var result1 = Source.ProductList.OrderByDescending(item => item.UnitPrice).Take(3);
            foreach (var item in result1)
            {
                Console.WriteLine($"{item.ProductName} -> {item.UnitPrice}");
            }

            // Q2:
            var result2 = Source.ProductList.Skip(5).Take(5);
            foreach (var item in result2)
            {
                Console.WriteLine(item.ProductName);
            }

            // Q3:
            var result3 = Source.ProductList
                                .OrderBy(prod => prod.UnitPrice)
                                .TakeWhile(prod => prod.UnitPrice < 25m);
            foreach (var item in result3)
            {
                Console.WriteLine(item.ProductName);
            }

            // Q4:
            bool result4 = Source.ProductList
                                 .Where(p => p.Category == "Seafood")
                                 .All(p => p.UnitsInStock > 0);
            Console.WriteLine(result4);

            // Q5:
            int[] numbers = { 3, 9, 13, 18 };
            bool result5 = numbers.Contains(9);
            Console.WriteLine(result5);

            // Q6:
            var result6 = Source.ProductList.GroupBy(p => p.Category);
            foreach (var g in result6)
            {
                Console.WriteLine($"{g.Key} : {g.Count()}");
            }

            // Q7:
            var result7 = from p in Source.ProductList
                          group p by p.Category into grp
                          select new
                          {
                              Cat = grp.Key,
                              Names = grp.Select(x => x.ProductName)
                          };

            foreach (var group in result7)
            {
                Console.WriteLine(group.Cat);
                foreach (var name in group.Names)
                {
                    Console.WriteLine($"- {name}");
                }
            }

            // Q8:
            var result8 = Source.ProductList
                                .GroupBy(x => x.Category)
                                .Where(g => g.Count() > 3);

            foreach (var g in result8)
            {
                Console.WriteLine(g.Key);
            }

            // Q9:
            var result9 = from cust in Source.CustomerList
                          group cust by cust.Country into cGroup
                          select new
                          {
                              Country = cGroup.Key,
                              Count = cGroup.Count(),
                              TotalOrderValue = cGroup.SelectMany(c => c.Orders).Sum(o => o.Total)
                          };

            foreach (var x in result9)
            {
                Console.WriteLine($"{x.Country} | {x.Count} | {x.TotalOrderValue}");
            }

            // Q10:
            var result10 = Source.ProductList.Sum(x => x.UnitsInStock);
            Console.WriteLine(result10);

            // Q11:
            var minVal = Source.ProductList.Min(p => p.UnitPrice);
            var maxVal = Source.ProductList.Max(p => p.UnitPrice);
            Console.WriteLine($"Min: {minVal}, Max: {maxVal}");

            // Q12:
            var result12 = (from p in Source.ProductList select p.Category).Distinct();
            foreach (var c in result12)
            {
                Console.WriteLine(c);
            }

            // Q13:
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var result13 = setA.Where(val => !setB.Contains(val));
            foreach (var v in result13)
            {
                Console.WriteLine(v);
            }

            // Q14:
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var result14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            foreach (var c in result14)
            {
                Console.WriteLine(c);
            }

            // Q15:
            Dictionary<int, Product> dict = Source.ProductList
                                                  .DistinctBy(p => p.ProductID)
                                                  .ToDictionary(p => p.ProductID);

            var target = dict[18];
            Console.WriteLine($"{target.ProductID} : {target.ProductName}");

            // Q16:
            var result16 = Source.ProductList.First(p => p.UnitPrice > 50m);
            Console.WriteLine($"{result16.ProductName} - {result16.UnitPrice}");

            // Q17:
            var result17 = Source.ProductList.FirstOrDefault(p => p.UnitPrice > 500m);
            Console.WriteLine(result17 == null ? "null" : result17.ProductName);

            // Q18:
            var result18 = Enumerable.Range(1, 12).Select(n => n * 7);
            foreach (var n in result18)
            {
                Console.WriteLine(n);
            }

            // Q19:
            var result19 = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
            foreach (var n in result19)
            {
                Console.WriteLine(n);
            }

            // Q20:
            var result20 = Source.ProductList.Select(p => p.ProductName).Take(3)
                                 .Concat(Source.CustomerList.Select(c => c.CustomerName).Take(3));

            foreach (var i in result20)
            {
                Console.WriteLine(i);
            }

            // Q21:
            var result21 = Source.ProductList.Select(p => p.ProductName)
                                 .Zip(Source.CustomerList.Select(c => c.CustomerName),
                                 (prod, cust) => $"{prod} sold to {cust}");

            foreach (var i in result21)
            {
                Console.WriteLine(i);
            }
        }
    }
}