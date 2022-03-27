using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace tholdiDeclaration
{

    public class declaration
    {
        private string _codeDeclaration;
        private string _commentaireDeclaration;
        private DateTime _dateDeclaration;
        private string _codeDocker;
        private bool _urgence;
        private bool _traite;
        private string _numContainer;
        private string _libelleProbleme;

        //supprimer une déclaration 
        private static string _insertSql =
        "INSERT INTO declaration (commentaireDeclaration,dateDeclaration,codeDocker,urgence,traite,numContainer,libelleProbleme) VALUES (?commentaireDeclaration,?dateDeclaration,?codeDocker,?urgence,?traite,?numContainer,?libelleProbleme)";
        private static string _selectSql =
                "SELECT * FROM declaration";
        private static string _selectByIdSql =
            "SELECT * FROM declaration where codeDeclaration=?codeDeclaration";
        private static string _updateSql =
        "UPDATE declaration SET commentaireDeclaration=?commentaireDeclaration,dateDeclaration=?dateDeclaration,codeDocker=?codeDocker,urgence=?urgence,traite=?traite,numContainer=?numContainer,libelleProbleme=?libelleProbleme where codeDeclaration=?codeDeclaration";
        private static string _deleteByIdSql =
        "DELETE FROM declaration WHERE codeDeclaration = ?codeDeclaration and libelleProbleme=?libelleProbleme";

        public string CommentaireDeclaration { get => _commentaireDeclaration; set => _commentaireDeclaration = value; }
        public DateTime DateDeclaration { get => _dateDeclaration; set => _dateDeclaration = value; }
        public bool Urgence { get => _urgence; set => _urgence = value; }
        public bool Traite { get => _traite; set => _traite = value; }

        //Constructeur de la classe declaration
        //public declaration(int codeDelcaration, string commentaire, DateTime dateDeclaration, int codeDocker,bool urgence, bool traite)
        //{
        //    _codeDeclaration = codeDelcaration;
        //    _commentaireDeclaration = commentaire;
        //    _dateDeclaration = dateDeclaration;
        //    _codeDocker = codeDocker;
        //    _urgence=
        //}

        //public static Declaration Fetch(int codeDeclaration)
        //{
        //Declaration c = null;
        //DataBaseAccess.Connexion.Open();
        // MySqlCommand commandSql = DataBaseAccess.Connexion.CreateCommand();//Initialisation d'un objet permettant d'interroger la bd
        // commandSql.CommandText = _selectByIdSql;//Définit la requete à utiliser
        // commandSql.Parameters.Add(DataBaseAccess.CodeParam("?codeDeclaration", codeDeclaration));//Transmet un paramètre à utiliser lors de l'envoie de la requête
        // commandSql.Prepare();//Prépare la requête (modification du paramètre de la requête)
        //  MySqlDataReader jeuEnregistrements = commandSql.ExecuteReader();//Exécution de la requête
        //  bool existEnregistrement = jeuEnregistrements.Read();//Lecture du premier enregistrement
        //    if (existEnregistrement)//Si l'enregistrement existe
        //{//alors
        //     c = new Declaration();//Initialisation de la variable Declaration
        //      c._codeDeclaration = Convert.ToInt16(jeuEnregistrements["codeDeclaration"].ToString());//Lecture d'un champ de l'enregistrement
        //     c._commentaireDeclaration = jeuEnregistrements["commentaireDeclaration"].ToString();
        //     c._dateDeclaration = (DateTime)jeuEnregistrements["dateDeclaration"];
        //     c = Declaration.Fetch(codeDeclaration);
        // }
        // DataBaseAccess.Connexion.Close();//fermeture de la connexion
        //     return c;
        //   }


        //supprimer une déclaration 
        public void Delete(int codeDeclaration,string libelleProbleme)
    {

            dataBaseAccess.Connexion.Open();
        MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
        commandSql.CommandText = _deleteByIdSql;
        commandSql.Parameters.Add(dataBaseAccess.CodeParam("?codeDeclaration", codeDeclaration));
        commandSql.Parameters.Add(dataBaseAccess.CodeParam("?libelleProbleme", libelleProbleme));
        commandSql.Prepare();
        commandSql.ExecuteNonQuery();
        dataBaseAccess.Connexion.Close();
        }

        //mise à jours d'une déclaration
        public void Update(int codeDeclaration,string commentaire, DateTime date, int codeDocker, bool urgence, bool traite,int numContainer, string libelleProbleme)
        {

            dataBaseAccess.Connexion.Open();
            MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
            commandSql.CommandText = _updateSql;
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?codeDeclaration", codeDeclaration));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?commentaireDeclaration", commentaire));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateDeclaration", date));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?codeDocker", codeDocker));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?urgence", urgence));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?traite", traite));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numContainer", numContainer));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?libelleProbleme", libelleProbleme));
            commandSql.Prepare();
            commandSql.ExecuteNonQuery();
            dataBaseAccess.Connexion.Close();
        }

        //Insérer une déclaration dans la base de donnée
        public void Insert(string commentaire, DateTime date, int codeDocker, bool urgence, bool traite, int numContainer,string libelleProbleme)
        {
            dataBaseAccess.Connexion.Open();
            MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
            commandSql.CommandText = _insertSql;
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?commentaireDeclaration", commentaire));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateDeclaration", date));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?codeDocker", codeDocker));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?urgence", urgence));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?traite", traite));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numContainer", numContainer));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?libelleProbleme", libelleProbleme));
            commandSql.Prepare();
            commandSql.ExecuteNonQuery();
            dataBaseAccess.Connexion.Close();
        }


        /// <summary>
        /// Retourne une collection contenant les declaration
        /// </summary>
        /// <returns>Une collection de declaration</returns>
        public static List<declaration> FetchAll()
        {
            List<declaration> resultat = new List<declaration>();
            dataBaseAccess.Connexion.Open();
            MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
            commandSql.CommandText = _selectSql;
            MySqlDataReader jeuEnregistrements = commandSql.ExecuteReader();
            while (jeuEnregistrements.Read())
            {
                declaration d = new declaration();
                string codeDeclaration = jeuEnregistrements["codeDeclaration"].ToString();
                d._codeDeclaration =codeDeclaration;
                string commentaireDeclaration = jeuEnregistrements["commentaireDeclaration"].ToString();
                d._commentaireDeclaration = commentaireDeclaration;
                DateTime dateDeclaration = (DateTime)jeuEnregistrements["dateDeclaration"];
                d._dateDeclaration = dateDeclaration;
                string codeDocker= jeuEnregistrements["codeDocker"].ToString();
                d._codeDocker = codeDocker;
                Console.WriteLine(codeDocker);
                bool urgence= (bool)jeuEnregistrements["urgence"];
                d._urgence = urgence;
                bool traite = (bool)jeuEnregistrements["traite"];
                d._traite = traite;
                string numContainer = jeuEnregistrements["numContainer"].ToString();
                d._numContainer = numContainer;
                string libelleProbleme= (string)jeuEnregistrements["libelleProbleme"].ToString();
                d._libelleProbleme = libelleProbleme;

                resultat.Add(d);
            }
            dataBaseAccess.Connexion.Close();
            return resultat;
        }
    }
}