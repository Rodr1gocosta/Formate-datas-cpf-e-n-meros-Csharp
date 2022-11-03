using Caelum.Stella.CSharp.Validation;
using Caelum.Stella.CSharp.Vault;
using System.Diagnostics;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string cpf1 = "69589418023";
        string cpf2 = "86283381257";
        string cpf3 = "22222222222";

        ValidarCPF(cpf1);
        ValidarCPF(cpf2);
        ValidarCPF(cpf3);


        //---------------------------------------------------------------------//

        DateTime data = new DateTime(2022, 10, 24);

        //IMPRIME APENAS A DATA
        Console.WriteLine(data.ToString("d"));

        //IMPRIME A DATA EM FORMATO BRASILEIRO
        Console.WriteLine(data.ToString("d", new CultureInfo("pt-BR")));

        // 23/10/22
        Console.WriteLine(data.ToString("dd/MM/yy"));

        //24/10/22 00:00:00
        Console.WriteLine(data.ToString("dd/MM/yy HH:mm:ss"));

        // segunda-feira, 24 de outubro de 2022
        Console.WriteLine(data.ToString("D"));

        // 24 de outubro
        Console.WriteLine(data.ToString("m"));

        // outubro de 2022
        Console.WriteLine(data.ToString("Y"));

        // 24/10/2022 00:00:00
        Console.WriteLine(data.ToString("G"));


        // 24/10/2022 00:00
        Console.WriteLine(data.ToString("g"));

        // 2022 - 10 - 24T00:00:00.0000000 FORMATO DE IDA E VOLTA
        Console.WriteLine(data.ToString("O"));
        Console.WriteLine(DateTime.Parse(data.ToString("O")).ToString("dd/MM/yyyy HH:mm:ss") + " CONVERTENDO");

        // 00:00
        Console.WriteLine(data.ToString("t"));

        // 00:00:00
        Console.WriteLine(data.ToString("T"));  




        //--------------------------------------------------------------------------------------------------------------//
        //TRABALHANDO COM DINHEIRO

        var euro = new Money(Currency.EUR, 1000);
        var dolar = new Money(Currency.USD, 1000);
        var reias = new Money(Currency.BRL, 1000);


        //--------------------------------------------------------------------------------------------------------------//
        //TRABALHANDO COM CEP

        string cep = "73105904";
        string formato = "json";
        string url = $"https://viacep.com.br/ws/{cep}/{formato}/";

        string result = new HttpClient().GetStringAsync(url).Result;

        Console.WriteLine(result);
    }

    private static void ValidarCPF(string cpf)
    {
        //QUANDO RETORNA UM ERRO
        //try
        //{
        //    new CPFValidator().AssertValid(cpf);
        //    Debug.Write("CPF válido: " + cpf);
        //}
        //catch (Exception ex)
        //{
        //    Debug.Write($"CPF inválido: {cpf} : {ex}");
        //}

        //QUANDO RETORNA UM BOOLEAN
        if(new CPFValidator().IsValid(cpf))
        {
            Debug.WriteLine(@$"CPF válido : {cpf} ");
        }
        else
        {
            Debug.WriteLine($"CPF inválido: {cpf} ");
        }
    }
}
