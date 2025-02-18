using System;
using System.Collections.Generic;
using CVApplication.Models;

namespace CVApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CV mioCV = new CV
            {
                InformazioniPersonali = InserisciInformazioniPersonali(),
                StudiEffettuati = InserisciStudi(),
                Impieghi = InserisciImpieghi()
            };

            StampaDettagliCVSuSchermo(mioCV);

            Console.WriteLine("Premi Invio per chiudere...");
            Console.ReadLine();
        }

        static string RichiediInput(string messaggio)
        {
            string input;
            do
            {
                Console.Write(messaggio);
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        static InformazioniPersonali InserisciInformazioniPersonali()
        {
            return new InformazioniPersonali
            {
                Nome = RichiediInput("Nome: "),
                Cognome = RichiediInput("Cognome: "),
                Telefono = RichiediInput("Telefono: "),
                Email = RichiediInput("Email: ")
            };
        }

        static List<Studi> InserisciStudi()
        {
            List<Studi> studi = new List<Studi>();
            int numStudi = int.Parse(RichiediInput("Quanti titoli di studio vuoi inserire? "));

            for (int i = 0; i < numStudi; i++)
            {
                Studi studio = new Studi
                {
                    Istituto = RichiediInput("Istituto: "),
                    Qualifica = RichiediInput("Qualifica: "),
                    Tipo = RichiediInput("Tipo: "),
                    Dal = RichiediInput("Dal (gg/mm/aaaa): "),
                    Al = RichiediInput("Al (gg/mm/aaaa): ")
                };
                studi.Add(studio);
            }
            return studi;
        }

        static List<Impiego> InserisciImpieghi()
        {
            List<Impiego> impieghi = new List<Impiego>();
            int numImpieghi = int.Parse(RichiediInput("Quante esperienze lavorative vuoi inserire? "));

            for (int i = 0; i < numImpieghi; i++)
            {
                Esperienza esperienza = new Esperienza
                {
                    Azienda = RichiediInput("Azienda: "),
                    JobTitle = RichiediInput("Job Title: "),
                    Dal = RichiediInput("Dal (gg/mm/aaaa): "),
                    Al = RichiediInput("Al (gg/mm/aaaa): "),
                    Descrizione = RichiediInput("Descrizione: "),
                    Compiti = RichiediInput("Compiti: ")
                };
                impieghi.Add(new Impiego { Esperienza = esperienza });
            }
            return impieghi;
        }

        static void StampaDettagliCVSuSchermo(CV cv)
        {
            Console.WriteLine($"CV di {cv.InformazioniPersonali.Nome} {cv.InformazioniPersonali.Cognome}");
            Console.WriteLine("\n++++ INIZIO Informazioni Personali: ++++\n");
            if (!string.IsNullOrEmpty(cv.InformazioniPersonali.Nome)) Console.WriteLine($"Nome: {cv.InformazioniPersonali.Nome}");
            if (!string.IsNullOrEmpty(cv.InformazioniPersonali.Cognome)) Console.WriteLine($"Cognome: {cv.InformazioniPersonali.Cognome}");
            if (!string.IsNullOrEmpty(cv.InformazioniPersonali.Email)) Console.WriteLine($"Email: {cv.InformazioniPersonali.Email}");
            if (!string.IsNullOrEmpty(cv.InformazioniPersonali.Telefono)) Console.WriteLine($"Telefono: {cv.InformazioniPersonali.Telefono}");
            Console.WriteLine("\n++++ FINE Informazioni Personali: ++++\n");

            Console.WriteLine("\n++++ INIZIO Studi e Formazione: ++++\n");
            foreach (var studio in cv.StudiEffettuati)
            {
                if (!string.IsNullOrEmpty(studio.Istituto)) Console.WriteLine($"Istituto: {studio.Istituto}");
                if (!string.IsNullOrEmpty(studio.Qualifica)) Console.WriteLine($"Qualifica: {studio.Qualifica}");
                if (!string.IsNullOrEmpty(studio.Tipo)) Console.WriteLine($"Tipo: {studio.Tipo}");
                if (!string.IsNullOrEmpty(studio.Dal) && !string.IsNullOrEmpty(studio.Al)) Console.WriteLine($"Dal: {studio.Dal} al {studio.Al}\n");
            }
            Console.WriteLine("++++ FINE Studi e Formazione: ++++\n");

            Console.WriteLine("\n++++ INIZIO Esperienze Professionali: ++++\n");
            foreach (var impiego in cv.Impieghi)
            {
                if (!string.IsNullOrEmpty(impiego.Esperienza.Azienda)) Console.WriteLine($"Presso: {impiego.Esperienza.Azienda}");
                if (!string.IsNullOrEmpty(impiego.Esperienza.JobTitle)) Console.WriteLine($"Tipo di lavoro: {impiego.Esperienza.JobTitle}");
                if (!string.IsNullOrEmpty(impiego.Esperienza.Compiti)) Console.WriteLine($"Compito: {impiego.Esperienza.Compiti}");
                if (!string.IsNullOrEmpty(impiego.Esperienza.Dal) && !string.IsNullOrEmpty(impiego.Esperienza.Al)) Console.WriteLine($"Dal: {impiego.Esperienza.Dal} al {impiego.Esperienza.Al}\n");
            }
            Console.WriteLine("++++ FINE Esperienze Professionali: ++++\n");
        }
    }
}
