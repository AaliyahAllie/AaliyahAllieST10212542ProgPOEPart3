using AaliyahAllieST10212542ProgPOEPart3;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static AaliyahAllieST10212542ProgPOEPart3.Recipe;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class RecipeWindow : Window
    {
        private List<Ingredient> ingredients;
        private List<string> steps;

        public RecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

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
                ingredients.Add(ingredient);
                IngredientsListBox.Items.Add($"{ingredientName}: {quantity} {unit} (Food Group: {foodGroup}, Calories: {calories})");

                IngredientNameTextBox.Clear();
                QuantityTextBox.Clear();
                UnitTextBox.Clear();
                CaloriesTextBox.Clear();
                FoodGroupComboBox.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please enter valid quantity and calories.");
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string step = StepTextBox.Text;
            steps.Add(step);
            StepsListBox.Items.Add($"Step {steps.Count}: {step}");
            StepTextBox.Clear();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;

            if (string.IsNullOrEmpty(recipeName) || ingredients.Count == 0 || steps.Count == 0)
            {
                MessageBox.Show("Please provide a recipe name, at least one ingredient, and at least one step.");
                return;
            }

            Recipe recipe = new Recipe(recipeName)
            {
                Ingredients = new List<Ingredient>(ingredients),
                Steps = new List<string>(steps)
            };

            double totalCalories = recipe.CalculateTotalCalories();
            if (totalCalories > 300)
            {
                MessageBox.Show($"ALERT!!! The recipe '{recipeName}' exceeds 300 calories.");
            }

            MainWindow.Recipes.Add(recipe);

            MessageBox.Show($"Recipe '{recipeName}' added successfully.");

            RecipeNameTextBox.Clear();
            IngredientsListBox.Items.Clear();
            StepsListBox.Items.Clear();
            ingredients.Clear();
            steps.Clear();
        }
    }
}
