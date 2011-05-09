using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels.Arquivo
{
    public class CreateArquivoViewModel
    {
        [Required(ErrorMessage = "O arquivo deve ser anexado")]
        public HttpPostedFileBase Anexo { get; set; }

        public Core.Objetos.Arquivo Arquivo { get; set; }

    }
}