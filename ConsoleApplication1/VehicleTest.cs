using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Vehicle : IComparable<Vehicle>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public float TCCRating { get; set; }
        public int HwyMpg { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Make : " + this.Make + ", Model :" + this.Model + ", Color: "+ this.Color 
                + ", Year: " + this.Year + ", Price : " + this.Price + ", TCCRating:" + this.TCCRating + ", HwyMpg:" + this.HwyMpg);
            return sb.ToString();
            //return String.Format("Make : {0}, Model : {1} , Color : {2}, Year : {3} , Price : {4} , TCCRating : {5} , HwyMpg : {6} ",
            //    this.Make, this.Model, this.Color, this.Price.ToString(), this.TCCRating.ToString(), this.HwyMpg.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Vehicle other)
        {
            return this.Make.CompareTo(other.Make);
        }
    }
    public class VehicleData
    {
        private List<Vehicle> getData()
        {
            return new List<Vehicle>()
            {
                new Vehicle()
                {
                    Make = "Honda", Model="CRV", Color ="Green",
                    Year =2016, Price = 23845, TCCRating = 8,
                    HwyMpg = 33
                },
                new Vehicle()
                {
                    Make = "Ford", Model="Escape", Color ="Red",
                    Year =2017, Price = 23590, TCCRating = 7.8F,
                    HwyMpg = 32
                },
                new Vehicle()
                {
                    Make = "Hyundai", Model="Sante Fe", Color ="Grey",
                    Year =2016, Price = 24950, TCCRating = 8,
                    HwyMpg = 27
                },
                new Vehicle()
                {
                    Make = "Mazda", Model="CX-5", Color="Red",
                    Year =2017, Price = 21795, TCCRating= 8,
                    HwyMpg = 35
                },
                new Vehicle()
                {
                    Make = "Subaru", Model="Forester", Color ="Blue",
                    Year =2016, Price = 22395, TCCRating = 8.4F,
                    HwyMpg = 32
                }
            };

        }
        /// <summary>
        /// 1) A function to calculate newest vehicles in order
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> getNewestVehicleInOrder()
        {
            var vehicleList = getData();
            return vehicleList.OrderByDescending(x => x.Year).ToList();
        }
        /// <summary>
        /// 2) A function to calculate alphabetized List of vehicles
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> getAlphabetizedList()
        {
            var vehicleList = getData();
            return vehicleList.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// 3) A function to calculate ordered List of Vehicles by Price
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> getOrderedListOfVehiclesByPrice()
        {
            var vehicleList = getData();
            return vehicleList.OrderByDescending(x => x.Price).ToList();
        }

        /// <summary>
        /// 4) A function to calculate the best value
        /// </summary>
        /// <returns></returns>
        public Vehicle getBestValueByMileage()
        {
            var vehicleList = getData();
            return vehicleList.OrderByDescending(x => x.HwyMpg).FirstOrDefault();
        }

        /// <summary>
        /// 5) A function to calculate fuel consumption
        /// </summary>
        /// <param name="distance"></param>
        public Vehicle getFuelConsumption()
        {
            var vehicleList = getData();
            return vehicleList.Where(x => x.HwyMpg == vehicleList.Max(y => y.HwyMpg))
                                    .Select(x => x).FirstOrDefault();
        }

        /// <summary>
        /// 6) A function to return a random car from the list
        /// </summary>
        /// <returns></returns>
        public Vehicle getRandomCar()
        {
            var vehicleList = getData();
            Random random = new Random();
            return (vehicleList[random.Next(vehicleList.Count)] as Vehicle);
        }
        /// <summary>
        /// 7) A function to return average MPG by year
        /// </summary>
        /// <returns></returns>
        public string getAverageMPGByYear()
        {
            var years = getData().Select(x => x.Year).Distinct();
            StringBuilder sb = new StringBuilder();
            foreach (var year in years)
            {
                var mpg = getData().Where(x => x.Year == year).Average(x => x.HwyMpg);
                sb.AppendLine(String.Format("Year - {0} , Miles - {1}", year, mpg));
            }
            return sb.ToString();
        }
    }
}
