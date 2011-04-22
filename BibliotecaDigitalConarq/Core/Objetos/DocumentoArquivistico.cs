using System.Collections.Generic;
using Core.Objetos.Enums;

namespace Core.Objetos
{
    // Referente ao 'Processo/Dossiê' citado na documentação da CONARQ
    public class DocumentoArquivistico
    {
        // Metadados 1.4 - Identificador do processo/dossiê
        public long Id { get; set; }

        // Metadados 1.5 - Identificador do processo/dossiê
        public string NumeroDoProcessoOuDossie { get; set; }

        // Metadados 1.8 - Tipo de meio
        public TipoDoMeio TipoDoMeio { get; set; }

        

        // Referências

        // Os volumes que este processo/dossiê contém
        public IEnumerable<Volume> Volumes { get; set; }
    }

}
