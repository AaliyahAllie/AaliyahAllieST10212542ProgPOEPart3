using AaliyahAllieST10212542ProgPOEPart3;
using System.Collections.Generic;
using System.Windows;
//Will display a selected recipe on the display recipe window
namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class SelectRecipeWindow : Window
    {
        // Property to hold the selected recipe name
        public string SelectedRecipeName { get; private set; }

        public SelectRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();

            // Populate the ComboBox with recipe names
            foreach (Recipe recipe in recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName);
            }

            // Select the first item by default
            if (RecipeComboBox.Items.Count > 0)
            {
                RecipeComboBox.SelectedIndex = 0;
            }
        }

        // Event handler for the "Display" button click
        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe name
            SelectedRecipeName = RecipeComboBox.SelectedItem as string;

            // Close the window
            DialogResult = true;
        }
    }
}
