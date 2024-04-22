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
        public Form1()
        {
            InitializeComponent();
        }


        public async void GetSpecies(int id)
        {
            PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(id);
            NameLabel.Text = p.Name;
            HappinessLabel.Text = p.BaseHappiness.ToString();
            CaptureLabel.Text = p.CaptureRate.ToString();
            HabitatLabel.Text = p.Habitat.Name;
            GrowthLabel.Text = p.GrowthRate.Name;
            FlavorLabel.Text = p.FlavorTexts[0].FlavorText;
            EggLabel.Text = string.Join(", ", p.EggGroups.Select(eggGroup => eggGroup.Name));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IDBox.Text, out int id) && id >= 1 && id <= 1025)
            {
                GetSpecies(id);
            }
            else
            {
                MessageBox.Show("Please enter a number between 1 and 1025.");
            }
        }
    }
}
