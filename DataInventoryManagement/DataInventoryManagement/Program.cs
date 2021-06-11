using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace DataInventoryManagement
{
    class Program
    {
        /// creating a json file and adding inventory to it and
        /// reading json file and deserializing it to string format
        /// also calculating the total value for inventory.

        static void Main(string[] args)
        {
            Console.WriteLine("welcome to Data Inventory Management");
            //create an object and  now have all the key-value pairs as assigned in our code.
            //will arrange the data and validate if the JSON we have provided is valid or not.
            //“students” is the key.
            //“[“ and “]”square brackets are array statement.It means there is the array between “[“ and “]” in brackets.
            //All statements in square brackets are value of “students” key.
            Inventory rice = new Inventory()
            {
                ItemNo = 1,
                name = "Rice",
                weight = 25,
                price = 50
            }; Inventory pulses = new Inventory()
            {
                ItemNo = 2,
                name = "Pulses",
                weight = 50,
                price = 75
            };
            Inventory wheats = new Inventory()
            {
                ItemNo = 3,
                name = "Wheat",
                weight = 100,
                price = 25
            };

            List<Inventory> inventories = new List<Inventory>();
            inventories.Add(rice);
            inventories.Add(pulses);
            inventories.Add(wheats);

            //Serialization object from string to json format.//
            //will serialize the class object that we defined into JSON using JsonConvert.SerializeObject.
            //Let’s store the serialized data inside a string variable.
            string strResult = JsonConvert.SerializeObject(inventories);

            File.WriteAllText(@"Inventort.json", strResult);
            //if data is stored print stored Successfully
            Console.WriteLine("Stored successfully!!");

            //Deserialization object from json file to string format.//
            strResult = File.ReadAllText(@"Inventort.json");
            //Deserializing to Object
            var list = JsonConvert.DeserializeObject<List<Inventory>>(strResult);
            // total Value =0
            float totalValue = 0;
            foreach (Inventory inventory in list)
            {
                Console.WriteLine($"Serial Number: {inventory.ItemNo}\n Name: {inventory.name}\n Weight: {inventory.weight}\n Price: {inventory.price}/Kg\n Total Price: {inventory.weight * inventory.price}\n");
                totalValue += (inventory.price * inventory.weight);
            }
            //op for total value of inventory 
            Console.WriteLine($"Total Value of inventory:{totalValue}");
            //read data
            Console.ReadLine();
        }
    }
}
