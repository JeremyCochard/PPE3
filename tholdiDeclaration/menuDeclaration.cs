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
    public partial class menuDeclaration : Form
    {
        bool urgenceDecla = false;
        bool traiteDecla = false;
        public menuDeclaration()
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
        private void validerDecla_Click(object sender, EventArgs e)
        {
            declaration declarations = new declaration();
            string commentaire = commentaireDeclaration.Text;
            DateTime date = dateDecla.Value;
            string code = codeDocker.Text;
            int codeDecla=Convert.ToInt16(code);
            string urgenc = urgence.Text;
            string trait = traite.Text;
            string numCont = numContainerInsert.Text;
            int numContainer = Convert.ToInt16(numCont);
            string libelle = libelleProbleme.Text;

            if (urgenc == "urgent")
            {
                urgenceDecla = true;
            }

            if (trait== "traite")
            {
                traiteDecla= true;

            }

            menuDeclaration menuDeclaration = new menuDeclaration();
            menuDeclaration.Show();
            this.Hide();


            declarations.Insert(commentaire, date, codeDecla, urgenceDecla, traiteDecla,numContainer, libelle);


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

        private void button5_Click(object sender, EventArgs e)
        {
            menuInspection menuInspection = new menuInspection();
            menuInspection.Show();
            this.Hide();
        }

        private void menuDeclaration_Load(object sender, EventArgs e)
        {
            List<container> containers = container.FetchAll();
            numContainerInsert.ValueMember = "numContainer";
            numContainerInsert.DataSource = containers;
        }
    }
}
