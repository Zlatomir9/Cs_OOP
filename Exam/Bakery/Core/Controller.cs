using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private decimal totalIncome;
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {

            if (type == "Tea" || type == "Water")
            {
                IDrink drink = null;
                switch (type)
                {
                    case "Tea":
                        drink = new Tea(name, portion, brand);
                        break;
                    case "Water":
                        drink = new Water(name, portion, brand);
                        break;
                }
                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink menu";
            }

            return string.Empty;
        }

        public string AddFood(string type, string name, decimal price)
        {

            if (type == "Bread" || type == "Cake")
            {
                IBakedFood food = null;
                switch (type)
                {
                    case "Bread":
                        food = new Bread(name, price);
                        break;
                    case "Cake":
                        food = new Cake(name, price);
                        break;
                }
                bakedFoods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }

            return string.Empty;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable" || type == "OutsideTable")
            {
                ITable table = null;

                switch (type)
                {
                    case "InsideTable":
                        table = new InsideTable(tableNumber, capacity);
                        break;
                    case "OutsideTable":
                        table = new OutsideTable(tableNumber, capacity);
                        break;
                }
                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }

            return string.Empty;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder result = new StringBuilder();

            foreach (var table in tables)
            {
                if (!table.IsReserved)
                {
                    result.AppendLine(table.GetFreeTableInfo());
                }
            }

            return result.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:F2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Table: {tableNumber}");
            result.AppendLine($"Bill: {bill:f2}");

            return result.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return $"Could not find table {tableNumber}";
            }
            else if (!drinks.Any(x => x.Name == drinkName && x.Brand == drinkBrand))
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
                var drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
                table.OrderDrink(drink);

                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return $"Could not find table {tableNumber}";
            }
            else if (!bakedFoods.Any(x => x.Name == foodName))
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
                var food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
                table.OrderFood(food);

                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            var searchedTable = tables.FirstOrDefault(x => x.Capacity >= numberOfPeople && x.IsReserved == false);

            if (searchedTable == null || searchedTable.Capacity <= numberOfPeople)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                searchedTable.Reserve(numberOfPeople);
                return $"Table {searchedTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
