using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public class Ingredient
    {// Represents an ingredient with properties for its name, quantity, original quantity, unit of measurement,
     // calories, original calories, food group, and food group number.


        //Getter and Setter for the Name variable
        public string Name { get; set; }
        //Getter and Setter for the Quantity variable
        public int Quantity { get; set; }
        //Getter and Setter for the OriginalQuantity variable
        //This is used to store the original quantity input for when the reset method is active
        public int OriginalQuantity { get; set; }
        //Getter and Setter for the UnitOfMeasuremnet variable
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        //Getter and Setter for the OriginalCalories variable
        //This is used to store the original calories input for when the reset method is active
        public double OriginalCalories { get; set; }
        //Getter and Setter for the FoodGroup variable
        public string FoodGroup { get; set; }
        //Getter and Setter for the OriginalQuantity variable
        //Captures what food group the user sets for an ingredient
        public int FoodGroupNumber { get; set; }
    }
}
