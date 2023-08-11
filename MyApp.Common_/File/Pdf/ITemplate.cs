namespace MyApp.ReportService.File.Pdf
{
    public interface ITemplate
    {
        /** Regras para a criação de um template
         * 1 - O nome do arquivo html deve ser o mesmo nome da classe que herda esta interface. Ex.: RelatorioX.cs - RelatorioX.html
         * 2 - No template, os campos que devem ser substítuidos devem ter o mesmo nome da propriedade da classe entre colchetes. 
         * Ou seja: 
         *      Na classe: string Documento
         *      No template: [Documento]
         * 3 - Ao seguir este padrão, o mapeamento acontecerá de forma automática.
         */

        string GetTemplateName();

        string Build();
    }
}
