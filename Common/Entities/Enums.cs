using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Web.Common.Entities
{
    /// <summary>
    /// Tipologie utenti
    /// </summary>
    public enum UserTypesEnum
    {
        CONSULTATORE = 3,
        REFERENTE_INTERNO = 1,//2
        REFERENTE_ESTERNO = 2,//4
        REDATTORE = 4,
        AMMINISTRATORE = 5
    }

    public enum TreeElementType
    {
        [Display(Name = "Radice")]
        Radice = 0,
        [Display(Name = "Ambito")]
        Ambito = 1,
        [Display(Name = "Processo")]
        Processo = 2,
        [Display(Name = "Fase")]
        Fase = 3,
        [Display(Name = "Attivita")]
        Attivita = 4,
        [Display(Name = "Applicazione")]
        Applicazione = 5,
        [Display(Name = "Gestione")]
        Gestione = 6,
        [Display(Name = "Servizio")]
	    Servizio = 7
    }

    public enum DocumentSearchType
    {
        Oggetto = 1,
        Id_Ref_Interno = 2,
        Id_Ref_Esterno = 3,
        Id_Autore = 4,
        Id_Tipologia_Doc = 5
    }

    public enum EnumGestioni
    {
        GPU = 35,
        GPR = 24,
        GSS = 29
    }

    public enum ApplicationTypesEnum
    {
        [Description("Nessuno")]
        NESSUNO = 0,
        [Description("Sistema Operativo")]
        Sistemi = 1,
        [Description("Ambiente")]
        AmbientiOperativi = 2,
        [Description("Dominio Applicazione")]
        DominioApplicazione = 3,
        [Description("Custom Mainframe")]
        Mainframe = 4,
        [Description("Editor")]
        Editor = 5,
        [Description("Database")]
        Database = 6,
        [Description("Linguaggio")]
        Linguaggio = 7,
        [Description("Framework")]
        Framework = 8,
        [Description("Tipologia autenticazione")]
        TipologiaAutenticazione = 9,
        [Description("DWH")]
        DWH = 10,
        [Description("Consumer / Utenti")]
        Consumer = 11,
        [Description("Application Server")]
        ApplicationServer = 12
    }
}
