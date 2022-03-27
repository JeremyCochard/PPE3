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
    public partial class menuInspection : Form
    {
        public menuInspection()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menuInspection menuInspection = new menuInspection();
            menuInspection.Show();
            this.Hide();
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

        private void menuInspection_Load(object sender, EventArgs e)
        {
            //afficher les informations d'un container
            List<container> containers = container.FetchAll();
            numContainerInspection.ValueMember = "numContainer";
            numContainerInspection.DataSource = containers;
        }

        private void validerDecla_Click(object sender, EventArgs e)
        {
            //insérer une inspection
            inspection inspection = new inspection();
            string numIns = numInspection.Text;
            int numInspec= Convert.ToInt16(numIns);
            string numCont= numContainerInspection.Text;
            int numContainer = Convert.ToInt16(numCont);
            DateTime date = dateInscription.Value;
            string commentaire = commentaireInspection.Text;
            string avis= avisInspection.Text;
            string motif = motifInspection.Text;
            string etat = etatInspection.Text;

            menuInspection menuInspection = new menuInspection();
            menuInspection.Show();
            this.Hide();

            inspection.Insert(numInspec,numContainer,date,commentaire,avis,motif,etat);
        }
    }
}
