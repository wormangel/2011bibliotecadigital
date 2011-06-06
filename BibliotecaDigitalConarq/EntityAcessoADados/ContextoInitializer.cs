using System.Data.Entity;

namespace EntityAcessoADados
{
    public class ContextoInitializer : DropCreateDatabaseIfModelChanges<ContextoAcessoADados>
    {
        protected override void Seed(ContextoAcessoADados context)
        {
            //Comando para cascata na relação de DocumentoArquivistico e suas Versões
            //Remove a constraint gerada pelo Entity, adiciona-a novamente da forma que queremos
            context.Database.ExecuteSqlCommand(
                @"           
                IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[DocumentoArquivistico_Versoes]') AND parent_object_id = OBJECT_ID(N'[dbo].[VersaoDocumentoArquivisticoes]'))
                ALTER TABLE [dbo].[VersaoDocumentoArquivisticoes] DROP CONSTRAINT [DocumentoArquivistico_Versoes]");
            context.Database.ExecuteSqlCommand(
                @"ALTER TABLE [dbo].[VersaoDocumentoArquivisticoes]  WITH CHECK ADD  CONSTRAINT [DocumentoArquivistico_Versoes] FOREIGN KEY([DocumentoArquivistico_Id])
                REFERENCES [dbo].[DocumentoArquivisticoes] ([Id])
                ON DELETE CASCADE"
                );

            //Comando para cascata na relação de Volume e suas Versões
            //Remove a constraint gerada pelo Entity, adiciona-a novamente da forma que queremos
            context.Database.ExecuteSqlCommand(
                @"           
                IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Volume_Versoes]') AND parent_object_id = OBJECT_ID(N'[dbo].[VersaoVolumes]'))
                ALTER TABLE [dbo].[VersaoVolumes] DROP CONSTRAINT [Volume_Versoes]");
            context.Database.ExecuteSqlCommand(
                @"ALTER TABLE [dbo].[VersaoVolumes]  WITH CHECK ADD  CONSTRAINT [Volume_Versoes] FOREIGN KEY([Volume_Id])
                REFERENCES [dbo].[Volumes] ([Id])
                ON DELETE CASCADE"
                );

            //Comando para cascata na relação de Volume e suas Versões
            //Remove a constraint gerada pelo Entity, adiciona-a novamente da forma que queremos
            context.Database.ExecuteSqlCommand(
                @"           
                IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Documento_Versoes]') AND parent_object_id = OBJECT_ID(N'[dbo].[VersaoDocumentoes]'))
                ALTER TABLE [dbo].[VersaoDocumentoes] DROP CONSTRAINT [Documento_Versoes]");
            context.Database.ExecuteSqlCommand(
                @"ALTER TABLE [dbo].[VersaoDocumentoes]  WITH CHECK ADD  CONSTRAINT [Documento_Versoes] FOREIGN KEY([Documento_Id])
                REFERENCES [dbo].[Documentoes] ([Id])
                ON DELETE CASCADE"
                );

            base.Seed(context);
        }
    }
}
