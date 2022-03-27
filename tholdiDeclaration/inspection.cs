using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tholdiDeclaration
{
    class inspection
    {
        private int _numInspection;
        private int _numContainer;
        private DateTime _dateInscription;
        private string _commentairePostInspection;
        private string _Avis;
        private string _libelleMotif;
        private string _libelleEtat;

        //liste des commandes pour intéragir avec la base de donnée pour une inspection
        private static string _insertSql =
        "INSERT INTO inspection (numInspection,NumContainer,dateInscription,commentairePostInspection,Avis,libelleMotif,libelleEtat) VALUES (?numInspection,?NumContainer,?dateInscription,?commentairePostInspection,?Avis,?libelleMotif,?libelleEtat)";
        private static string _selectSql =
                "SELECT * FROM declaration";
        private static string _selectByIdSql =
            "SELECT numContainer FROM container";
        private static string _updateSql =
        "UPDATE declaration SET commentaireDeclaration=?commentaireDeclaration,dateDeclaration=?dateDeclaration,codeDocker=?codeDocker,urgence=?urgence,traite=?traite,libelleProbleme=?libelleProbleme where codeDeclaration=?codeDeclaration";
        private static string _deleteByIdSql =
        "DELETE FROM declaration WHERE codeDeclaration = ?codeDeclaration and libelleProbleme=?libelleProbleme";

        public int NumInspection { get => _numInspection; set => _numInspection = value; }
        public int NumContainer { get => _numContainer; set => _numContainer = value; }
        public DateTime DateInscription { get => _dateInscription; set => _dateInscription = value; }
        public string CommentairePostInspection { get => _commentairePostInspection; set => _commentairePostInspection = value; }
        public string Avis { get => _Avis; set => _Avis = value; }
        public string LibelleMotif { get => _libelleMotif; set => _libelleMotif = value; }
        public string LibelleEtat { get => _libelleEtat; set => _libelleEtat = value; }

        public void Insert(int numInspec, int numContainer,DateTime date, string commentaire,string avis,string motif,string etat)
        {
            dataBaseAccess.Connexion.Open();
            MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
            commandSql.CommandText = _insertSql;
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numInspection", numInspec));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numContainer", numContainer));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateInscription", date));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?commentairePostInspection", commentaire));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?Avis", avis));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?libelleMotif", motif));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?libelleEtat", etat));
            commandSql.Prepare();
            commandSql.ExecuteNonQuery();
            dataBaseAccess.Connexion.Close();
        }

    }
}
