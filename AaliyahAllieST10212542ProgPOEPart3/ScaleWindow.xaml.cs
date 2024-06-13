using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AaliyahAllieST10212542ProgPOEPart3;

//This code will scale a selected recipe by a selected factor
namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ScaleWindow : Window
    {
        private List<Recipe> _recipes; // List to hold Recipe objects passed from the caller

        public ScaleWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            _recipes = recipes; // Initialize the list of recipes with the provided list
            PopulateRecipeNames(); // Populate the ComboBox with recipe names
        }

        private void PopulateRecipeNames()
        {
            // Clear existing items in the RecipeComboBox
            RecipeComboBox.Items.Clear();

            // Populate the ComboBox with recipe names from the _recipes list
            foreach (var recipe in _recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName); // Add each recipe's name to the ComboBox
            }
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe name is selected in the RecipeComboBox
            if (RecipeComboBox.SelectedItem is string selectedRecipeName)
            {
                // Find the Recipe object in _recipes based on the selected name
                Recipe selectedRecipe = _recipes.Find(recipe => recipe.RecipeName == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    // Check if a scaling factor is selected in the ScaleFactorComboBox
                    if (ScaleFactorComboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        double factor = double.Parse(selectedItem.Content.ToString()); // Parse the scaling factor
                        selectedRecipe.ScaleRecipe(factor); // Scale the selected recipe using the factor
                        MessageBox.Show($"Recipe '{selectedRecipeName}' scaled by a factor of {factor}"); // Display success message
                        this.Close(); // Close the ScaleWindow
                    }
                    else
                    {
                        MessageBox.Show("Please select a scaling factor."); // Display error message if no scaling factor selected
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale."); // Display error message if no recipe selected
            }
        }
    }
}
