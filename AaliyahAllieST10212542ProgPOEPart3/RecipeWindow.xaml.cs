using AaliyahAllieST10212542ProgPOEPart3;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static AaliyahAllieST10212542ProgPOEPart3.Recipe;

//This code contains the specifications for capturing the details of the recipe and saving it
namespace AaliyahAllieST10212542ProgPOEPart3
{
    //This code will call on elements and methods within the Recipe.cs to save data
    public partial class RecipeWindow : Window
    {
        private List<Ingredient> ingredients;  // List to store ingredients of the recipe
        private List<string> steps;  // List to store steps of the recipe

        public RecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();  // Initialize the ingredients list
            steps = new List<string>();  // Initialize the steps list
        }

        // Event handler for adding an ingredient to the recipe
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientNameTextBox.Text;
            if (int.TryParse(QuantityTextBox.Text, out int quantity) && double.TryParse(CaloriesTextBox.Text, out double calories))
            {
                string unit = UnitTextBox.Text;
                string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString();

                var ingredient = new Ingredient
                {
                    Name = ingredientName,
                    Quantity = quantity,
                    UnitOfMeasurement = unit,
                    FoodGroup = foodGroup,
                    Calories = calories
                };
                ingredients.Add(ingredient);  // Add ingredient to the list
                IngredientsListBox.Items.Add($"{ingredientName}: {quantity} {unit} (Food Group: {foodGroup}, Calories: {calories})");

                // Clear input fields after adding ingredient
                IngredientNameTextBox.Clear();
                QuantityTextBox.Clear();
                UnitTextBox.Clear();
                CaloriesTextBox.Clear();
                FoodGroupComboBox.SelectedIndex = -1;  // Reset food group selection
            }
            else
            {
                MessageBox.Show("Please enter valid quantity and calories.");  // Alert user for invalid input
            }
        }

        // Event handler for adding a step to the recipe
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string step = StepTextBox.Text;
            steps.Add(step);  // Add step to the list
            StepsListBox.Items.Add($"Step {steps.Count}: {step}");  // Display step in the ListBox
            StepTextBox.Clear();  // Clear step input field
        }

        // Event handler for adding a recipe
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;

            if (string.IsNullOrEmpty(recipeName) || ingredients.Count == 0 || steps.Count == 0)
            {
                MessageBox.Show("Please provide a recipe name, at least one ingredient, and at least one step.");  // Alert if essential fields are missing
                return;
            }

            // Create a Recipe object
            Recipe recipe = new Recipe(recipeName)
            {
                Ingredients = new List<Ingredient>(ingredients),  // Assign ingredients to the recipe
                Steps = new List<string>(steps)  // Assign steps to the recipe
            };

            double totalCalories = recipe.CalculateTotalCalories();  // Calculate total calories in the recipe
            if (totalCalories > 300)
            {
                MessageBox.Show($"ALERT!!! The recipe '{recipeName}' exceeds 300 calories.");  // Alert if recipe exceeds calorie limit
            }

            MainWindow.Recipes.Add(recipe);  // Add recipe to the main collection

            MessageBox.Show($"Recipe '{recipeName}' added successfully.");  // Confirmation message

            // Clear all input fields and reset lists after adding recipe
            RecipeNameTextBox.Clear();
            IngredientsListBox.Items.Clear();
            StepsListBox.Items.Clear();
            ingredients.Clear();
            steps.Clear();
        }
    }
}
