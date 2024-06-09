using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AaliyahAllieST10212542ProgPOEPart3;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ScaleWindow : Window
    {
        private List<Recipe> _recipes;

        public ScaleWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            _recipes = recipes;
            PopulateRecipeNames();
        }

        private void PopulateRecipeNames()
        {
            // Clear existing items
            RecipeComboBox.Items.Clear();

            // Populate the ComboBox with recipe names
            foreach (var recipe in _recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName);
            }
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem is string selectedRecipeName)
            {
                Recipe selectedRecipe = _recipes.Find(recipe => recipe.RecipeName == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    // Scale the selected recipe
                    if (ScaleFactorComboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        double factor = double.Parse(selectedItem.Content.ToString());
                        selectedRecipe.ScaleRecipe(factor);
                        MessageBox.Show($"Recipe '{selectedRecipeName}' scaled by a factor of {factor}");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select a scaling factor.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
            }
        }
    }
}
