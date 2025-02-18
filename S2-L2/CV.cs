using System.Collections.Generic;

namespace CVApplication.Models
{
    class CV
    {
        public InformazioniPersonali InformazioniPersonali { get; set; }
        public List<Studi> StudiEffettuati { get; set; }
        public List<Impiego> Impieghi { get; set; }
    }
}
