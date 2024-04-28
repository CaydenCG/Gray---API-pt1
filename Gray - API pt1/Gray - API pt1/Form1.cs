using PokeAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gray___API_pt1
{
    public partial class Form1 : Form
    {
        private PokemonSpecies currentPokemon;

        public Form1()
        {
            InitializeComponent();
        }
        //Displays pokemon data from API
        public async void GetSpecies(int id)
        {
            currentPokemon = await DataFetcher.GetApiObject<PokemonSpecies>(id);

            NameLabel.Text = currentPokemon.Name;
            HappinessLabel.Text = currentPokemon.BaseHappiness.ToString();
            CaptureLabel.Text = currentPokemon.CaptureRate.ToString();
            HabitatLabel.Text = currentPokemon.Habitat.Name;
            GrowthLabel.Text = currentPokemon.GrowthRate.Name;
            FlavorLabel.Text = currentPokemon.FlavorTexts[0].FlavorText;
            EggLabel.Text = string.Join(", ", currentPokemon.EggGroups.Select(eggGroup => eggGroup.Name));

            DisplayScenario();
        }
        //scenario sentance function
        private void DisplayScenario()
        {
            ScenarioLabel.Text = $"You stumble upon a {currentPokemon.Name} in a {currentPokemon.Habitat.Name} environment.";
        }
        //contains search for the first 3 generations of pokemon
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IDBox.Text, out int id) && id >= 1 && id <= 386)
            {
                GetSpecies(id);
            }
            else
            {
                MessageBox.Show("Please enter a number between 1 and 386.");
            }
        }
    }
}