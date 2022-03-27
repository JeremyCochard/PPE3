using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tholdiDeclaration
{
    class container
    {
        private int _numContainer;
        private DateTime _dateAchat;
        private string _typeContainer;
        private DateTime _dateDerniereInsp;

        public int NumContainer { get => _numContainer; set => _numContainer = value; }
        public string TypeContainer { get => _typeContainer; set => _typeContainer = value; }
        public DateTime DateAchat { get => _dateAchat; set => _dateAchat = value; }
        public DateTime DateDerniereInsp { get => _dateDerniereInsp; set => _dateDerniereInsp = value; }

        //liste des commandes SQL pour intéragir avec la base de donnée
        private static string _selectSql =
                "SELECT numContainer , dateAchat, typeContainer,  dateDerniereInsp FROM container";

        private static string _selectByIdSql =
            "SELECT numContainer , dateAchat, typeContainer,  dateDerniereInsp FROM container WHERE numContainer = ?numContainer ";

        private static string _updateSql =
            "UPDATE container SET dateAchat = ?dateAchat, dateDerniereInsp=?dateDerniereInsp";

        private static string _insertSql =
            "INSERT INTO container (numContainer,dateAchat,typeContainer,dateDerniereInsp) VALUES (?numContainer,?dateAchat,?typeContainer,?dateDerniereInsp)";

        private static string _deleteByIdSql =
            "DELETE FROM container WHERE numContainer = ?numContainer";

        private static string _getLastInsertId =
            "SELECT numContainer FROM container WHERE dateAchat = ?dateAchat AND typeContainer=?typeContainer AND dateDerniereInsp=?dateDerniereInsp ";


        //Constructeur de la classe container

        //public container(int numContainer, string typeContainer, DateTime dateAchat, DateTime dateDerniereInsp)
        //{
        //    _numContainer = numContainer;
        //    _typeContainer = typeContainer;
        //    _dateAchat = dateAchat;
        //    _dateDerniereInsp = dateDerniereInsp;

        //}

        //public static container Fetch(int Container)
        //{
        //    container c = null;
        //    dataBaseAccess.Connexion.Open();
        //    MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();//Initialisation d'un objet permettant d'interroger la bd
        //    commandSql.CommandText = _selectByIdSql;//Définit la requete à utiliser
        //    commandSql.Parameters.Add(dataBaseAccess.CodeParam("?id", numContainer));//Transmet un paramètre à utiliser lors de l'envoie de la requête
        //    commandSql.Prepare();//Prépare la requête (modification du paramètre de la requête)
        //    MySqlDataReader jeuEnregistrements = commandSql.ExecuteReader();//Exécution de la requête
        //    bool existEnregistrement = jeuEnregistrements.Read();//Lecture du premier enregistrement
        //    if (existEnregistrement)//Si l'enregistrement existe
        //    {//alors
        //        c = new container();//Initialisation de la variable Contact
        //        c.numContainer = Convert.ToInt16(jeuEnregistrements["numContainer"].ToString());//Lecture d'un champ de l'enregistrement
        //        c.typeContainer = jeuEnregistrements["typeContainer"].ToString();
        //        c.container = Container.Fetch(numContainer);
        //    }
        //    DataBaseAccess.Connexion.Close();//fermeture de la connexion
        //    return c;
        //}
        //public void Delete()
        //{
        //    dataBaseAccess.Connexion.Open();
        //    MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
        //    commandSql.CommandText = _deleteByIdSql;
        //    commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numContainer", numContainer));
        //    commandSql.Prepare();
        //    commandSql.ExecuteNonQuery();
        //}

        //private void Update()
        //{
        //    dataBaseAccess.Connexion.Open();
        //    MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
        //    commandSql.CommandText = _updateSql;
        //    commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numContainer", numContainer));
        //    commandSql.Parameters.Add(dataBaseAccess.CodeParam("?typeContainer", typeContainer));
        //    commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateAchat", dateAchat));
        //    commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateDerniereInsp", dateDerniereInsp));
        //    commandSql.Prepare();
        //    commandSql.ExecuteNonQuery();
        //    DataBaseAccess.Connexion.Close();
        //}

        //insérer un container dans la base de donnée
        public void Insert(int numContainer,DateTime dateAch,string typeContainer,DateTime dateDerniereInsp)
        {
            dataBaseAccess.Connexion.Open();
            MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
            commandSql.CommandText = _insertSql;

            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?numContainer", numContainer));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateAchat", dateAch));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?typeContainer", typeContainer));
            commandSql.Parameters.Add(dataBaseAccess.CodeParam("?dateDerniereInsp", dateDerniereInsp));
            commandSql.Prepare();
            commandSql.ExecuteNonQuery();
            dataBaseAccess.Connexion.Close();
        }

        /// <summary>
        /// Retourne une collection contenant les declarations
        /// </summary>
        /// <returns>Une collection de declarations</returns>
        public static List<container> FetchAll()
        {
            List<container> resultat = new List<container>();
            dataBaseAccess.Connexion.Open();
            MySqlCommand commandSql = dataBaseAccess.Connexion.CreateCommand();
            commandSql.CommandText = _selectSql;
            MySqlDataReader jeuEnregistrements = commandSql.ExecuteReader();
            while (jeuEnregistrements.Read())
            {
                container container = new container();
                int numContainer = (int)jeuEnregistrements["numContainer"];
                container._numContainer = numContainer;
                resultat.Add(container);
            }
            dataBaseAccess.Connexion.Close();
            return resultat;
        }
    }
}
