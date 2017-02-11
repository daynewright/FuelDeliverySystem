using System;
using FuelDeliverySystem.Data;

namespace FuelDeliverySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //If database is empty then add seed data
            DbInitializer.Initialize();
        }
    }
}
