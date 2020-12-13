using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance
            => CalculateOverallPerformance();

        public override decimal Price
            => base.Price + this.Peripherals.Sum(x => x.Price) +
            this.Components.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType() == component.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }

            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            var peripherial = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripherial);

            return peripherial;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({components.Count}):");

            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            string averrageResult = this.Peripherals.Count == 0 ? "0.00" :
                this.Peripherals.Average(x => x.OverallPerformance).ToString("F2");

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({averrageResult}):");

            foreach (var peripherial in peripherals)
            {
                sb.AppendLine($"  {peripherial}");
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }

        private double CalculateOverallPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            var result = base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);

            return result;
        }
    }
}
