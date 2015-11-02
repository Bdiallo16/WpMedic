using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace wpmedical
{
    public static class WebServiceClaude
    {
        public static string protoSoap =
                    @"<?xml version=""1.0"" encoding=""utf-8""?>
              <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                    xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                    xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                      {0}  
                  </soap:Body>
              </soap:Envelope>";

        public static string medecinlogin(string login, string password)
        {
            string protoMedecinLogin = @"<medecinLogin>
                                            <login>{0}</login>
                                            <password>{1}</password>
                                        </medecinLogin>";

            string bodyMedecinLogin = string.Format(protoMedecinLogin, login, password);
            return string.Format(protoSoap, bodyMedecinLogin);
        }

        public static string consultations(int id, int idPatient)
        {
            string protoMedecinLogin = @"<consultations>
                                            <id>{0}</id>
                                            <idpatient>{1}</idpatient>
                                        </consultations>";

            string bodyMedecinLogin = string.Format(protoMedecinLogin, id, idPatient);
            return string.Format(protoSoap, bodyMedecinLogin);
        }

        public static string patient(string nomPatient)
        {
                     string Patient =@" <patients>
                                            <nom>{0}</nom>
                                        </patients>";

                     string bodyMedecinLogin = string.Format(Patient , nomPatient);
                     return string.Format(protoSoap, bodyMedecinLogin);
        }

        public static string ajoutConsultations(int idPatient, string date, string libelle, int motif, int poids, int taille, int imc, int tas, int tad, string detail, string devenir, int id)
        {
            string protoajoutConsult= @"<consultationAdd>
                                            <idpatient>{0}</idpatient> 
                                            <dateconsultation>{1}</dateconsultation>
                                            <libelle>{2}</libelle>
                                            <motif>{3}</motif>
                                            <poids>{6}</poids>
                                            <taille>{4}</taille>
                                            <imc>{5}</imc>
                                            <tas>{7}</tas>
                                            <tad>{8}</tad>
                                            <detail>{9}</detail>
                                            <devenir>{10}</devenir>
                                            <idmedecin>{11}</idmedecin>
                                        </consultationAdd>";

            string ajoutConsultations = string.Format(protoajoutConsult, idPatient, date, libelle, motif, poids, taille, imc, tas, tad, detail, devenir, id);
            return string.Format(protoSoap, ajoutConsultations);
        }

        public static string agenda(int idmedecin, int idPatient, string dateprevue, string datedebut, string datefin, string urgence, string libelle)
        {
            string agenda = @" <agendas>
                                   <idmedecin>{0}</idmedecin>
                                    <idpatient>{1}</idpatient>
                                    <dateprevue>{2}</dateprevue>
                                    <datedebut>{3}</datedebut>
                                    <datefin>{4}</datefin>
                                    <urgence>{5}</urgence>
                                    <libelle>{6}</libelle>
                                </agendas>";

            string bodyagenda = string.Format(agenda, idmedecin , idPatient, dateprevue, datedebut, datefin, urgence, libelle );
            return string.Format(protoSoap, bodyagenda);
        }

        public static string agendaCons(int idmedecin, int idPatient)
        {
            string agenda = @" <agendas>
                                   <id>{0}</id>
                                    <idmedecin>{1}</idmedecin>
                                </agendas>";

            string bodyagenda = string.Format(agenda, idmedecin, idPatient);
            return string.Format(protoSoap, bodyagenda);
        }

            public static string medic(int id, int idp)
        {
            string medic = @"<prescriptions>
                                <id>{0}</id>
                                <idpatient>{1}</idpatient>
                             </prescriptions>";

            string bodymedic = string.Format(medic, id, idp);
            return string.Format(protoSoap, bodymedic);
        }

            public static string MAJInfos(int id, string nom, string prenom, string adresse, string codepostal, string ville,
                                    string telephone, string mobile, string email, string datenaissance, string sexe)
            {
                string protoMAJInfos = @"<patientUpdate>
                                            <id>{0}</id>
                                            <nom>{1}</nom> 
                                            <prenom>{2}</prenom>
                                            <adresse>{3}</adresse>
                                            <codepostal>{4}</codepostal>
                                            <ville>{5}</ville>
                                            <telephone>{6}</telephone>
                                            <mobile>{7}</mobile>
                                            <email>{8}</email>
                                            <datenaissance>{9}</datenaissance>
                                            <sexe>{10}</sexe>
                                        </patientUpdate>";

                string MAJInfos = string.Format(protoMAJInfos, id, nom, prenom, adresse, codepostal, ville, telephone, mobile, email, datenaissance, sexe);
                return string.Format(protoSoap, MAJInfos);
            }

            public static string MAJAntecedents(int id, int idPatient, string libelle, int annee, string commentaire)
            {
                string protoMAJAnte = @"<atcdUpdate>
                                            <id>{0}</id>
                                            <idpatient>{1}</idpatient> 
                                            <libelle>{2}</libelle>
                                            <annee>{3}</annee>
                                            <commentaire>{4}</commentaire>
                                        </atcdUpdate>";

                string MAJAntecedents = string.Format(protoMAJAnte, id, idPatient, libelle, annee, commentaire);
                return string.Format(protoSoap, MAJAntecedents);
            }

            public static string supprimerajoutAntecedents(int id)
            {
                string protoSuppAnte = @"<atcdDelete>
                                            <id>{0}</id> 
                                        </atcdDelete>";

                string supprimerajoutAntecedents = string.Format(protoSuppAnte, id);
                return string.Format(protoSoap, supprimerajoutAntecedents);
            }

            public static string ajoutAntecedents(int idPatient, string libelle, int annee, string commentaire)
            {
                string protoajoutAnte = @"<atcdAdd>
                                            <idpatient>{0}</idpatient> 
                                            <libelle>{1}</libelle>
                                            <annee>{2}</annee>
                                            <commentaire>{3}</commentaire>
                                        </atcdAdd>";

                string ajoutAntecedents = string.Format(protoajoutAnte, idPatient, libelle, annee, commentaire);
                return string.Format(protoSoap, ajoutAntecedents);
            }

            public static string antecedents(int id, int idPatient)
            {
                string protoMedecinLogin = @"<atcds>
                                            <id>{0}</id>
                                            <idpatient>{1}</idpatient>
                                        </atcds>";

                string bodyMedecinLogin = string.Format(protoMedecinLogin, id, idPatient);
                return string.Format(protoSoap, bodyMedecinLogin);
            }
    }
}
