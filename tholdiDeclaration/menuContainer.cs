using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tholdiDeclaration
{
    public partial class menuContainer : Form
    {
        public menuContainer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuContainer menuContainer = new menuContainer();
            menuContainer.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuDeclaration menuDeclaration = new menuDeclaration();
            menuDeclaration.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menuAffichageDeclarations menuAffichageDeclarations = new menuAffichageDeclarations();
            menuAffichageDeclarations.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuUtilisateur menuUtilisateur = new menuUtilisateur();
            menuUtilisateur.Show();
            this.Hide();
        }

        private void validerContainer_Click(object sender, EventArgs e)
        {
            container unContainer = new container();
            string code = numContainer.Text;
            int numeroContainer = Convert.ToInt16(code);
            DateTime dateAch = dateAchat.Value;
            //enregistrer informations depuis la saisie de l'utilisateur dans des variables 
            string typeDeContainer = typeContainer.Text;
            DateTime dateDerniere = dateDerniereInsp.Value;
            menuContainer menuContainer = new menuContainer();
            menuContainer.Show();
            this.Hide();

            unContainer.Insert(numeroContainer, dateAch, typeDeContainer, dateDerniere);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menuInspection menuInspection = new menuInspection();
            menuInspection.Show();
            this.Hide();
        }
    }
}
