using AaliyahAllieST10212542ProgPOEPart3;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ClearRecipeWindow : Window
    {
        private List<Recipe> recipes;

        public ClearRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;

            // Populate the ComboBox with recipe names
            foreach (Recipe recipe in recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName);
            }
        }


        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe name
            string selectedRecipeName = RecipeComboBox.SelectedItem as string;

            // Find the recipe in the list
            Recipe recipeToRemove = recipes.FirstOrDefault(r => r.RecipeName == selectedRecipeName);

            // Remove the recipe if found
            if (recipeToRemove != null)
            {
                recipes.Remove(recipeToRemove);
                MessageBox.Show($"Recipe '{selectedRecipeName}' has been cleared.", "Clear Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a recipe to clear.", "Clear Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Close the window after clearing the recipe
            this.Close();
        }
    }
}
