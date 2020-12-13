using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherials;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherials = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            GetComputer(computerId);

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            else if (componentType != ComponentType.CentralProcessingUnit.ToString()
                     && componentType != ComponentType.Motherboard.ToString()
                     && componentType != ComponentType.PowerSupply.ToString()
                     && componentType != ComponentType.RandomAccessMemory.ToString()
                     && componentType != ComponentType.SolidStateDrive.ToString()
                     && componentType != ComponentType.VideoCard.ToString())
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.AddComponent(component);
            components.Add(component);
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            GetComputer(computerId);

            if (peripherials.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            else if (peripheralType != PeripheralType.Headset.ToString()
                     && peripheralType != PeripheralType.Keyboard.ToString()
                     && peripheralType != PeripheralType.Monitor.ToString()
                     && peripheralType != PeripheralType.Mouse.ToString())
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.AddPeripheral(peripheral);
            peripherials.Add(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer searchedComputer = this.computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (searchedComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(searchedComputer);
            return searchedComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            GetComputer(id);

            var computer = computers.FirstOrDefault(x => x.Id == id);

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            GetComputer(id);
            var computer = computers.FirstOrDefault(x => x.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            GetComputer(computerId);

            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.RemoveComponent(componentType);
            components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            GetComputer(computerId);

            var peripherial = peripherials.FirstOrDefault(x => x.GetType().Name == peripheralType);
            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.RemovePeripheral(peripheralType);
            peripherials.Remove(peripherial);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripherial.Id);
        }

        private void GetComputer(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
