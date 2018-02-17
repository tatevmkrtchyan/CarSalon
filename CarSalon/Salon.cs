using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    public class Salon : IEnumerable<Car>
    {
        public List<Car> Cars = new List<Car>();
      //  public event SalonChangedEventArgsHandler SalonChanged;

        public IEnumerator<Car> GetEnumerator()
        {
            return Cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //public void Add(Car car, Brand brand)
        //{
        //    Cars.Add(car);

        //    SalonChanged?.Invoke(this, new SalonChangedEventArgs()
        //    {
        //        Brand = brand,
        //        Car = car,
        //        ChangeType = SalonChangedType.Add
        //    });
        //}
    }
}
