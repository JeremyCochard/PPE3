using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tholdiDeclaration
{
    public partial class menuAffichageDeclarations : Form
    {

        public menuAffichageDeclarations()
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

        private void menuAffichageDeclarations_Load(object sender, EventArgs e)
        {
            //afficher les informations d'une déclaration
            List<declaration> declarations = declaration.FetchAll();
            affichageDeclaration.DataSource = declarations;
            List<container> containers = container.FetchAll();
            numContainerUpdate.ValueMember = "numContainer";
            numContainerUpdate.DataSource = containers;

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

        private void SupprimerDecla_Click(object sender, EventArgs e)
        {
            //suppression déclaration
            declaration declaration = new declaration();
            string codeSup = codeDeclaSup.Text;
            int codeSupDecla = Convert.ToInt16(codeSup);
            string libelle = libelleProbleme.Text;

            declaration.Delete(codeSupDecla, libelle);
            //afficher menu
            menuAffichageDeclarations menuAffichageDeclarations = new menuAffichageDeclarations();
            menuAffichageDeclarations.Show();
            this.Hide();

        }

        private void libelleProbleme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        bool urgenceDecla = false;
        bool traiteDecla = false;
        private void modifierDeclaration_Click(object sender, EventArgs e)
        {
            //modifier déclaration
            declaration declarations = new declaration();
            string codeDeModif = codeDeclarationModif.Text;
            int codeDeclaModifier = Convert.ToInt16(codeDeModif);
            string commentaire = commentaireDeclarationModif.Text;
            DateTime date = dateDeclaModif.Value;
            string code = codeDockerModif.Text;
            int codeDeclaDocker = Convert.ToInt16(code);
            string urgenc = urgenceModif.Text;
            string trait = traiteModif.Text;
            string numContainer = numContainerUpdate.Text;
            int numeroContainer = Convert.ToInt16(numContainer);
            string libelle = libelleModif.Text;

            if (urgenc == "urgent")
            {
                urgenceDecla = true;
            }

            if (trait == "traite")
            {
                traiteDecla = true;

            }


            commentaireDeclarationModif.Clear();


            declarations.Update(codeDeclaModifier,commentaire, date, codeDeclaDocker, urgenceDecla, traiteDecla,numeroContainer,libelle);
            menuAffichageDeclarations menuAffichageDeclarations= new menuAffichageDeclarations();
            menuAffichageDeclarations.Show();
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menuInspection menuInspection = new menuInspection();
            menuInspection.Show();
            this.Hide();
        }
    }
}
