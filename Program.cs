
Console.Clear();

int soma = 0;

string[] cidades = { "Belo Horizonte", "Rio de Janeiro", "São Paulo", "Vitória" };
int[,] distancias = {
    { 0, 434, 586, 524 }, // Belo Horizonte
    { 434, 0, 429, 521 }, // Rio de Janeiro
    { 586, 429, 0, 882 }, // São Paulo
    { 524, 521, 882, 0 }  // Vitória
};

Console.WriteLine("*** Distância Percorrida ***\n");
Console.WriteLine("0 = Belo Horizonte\n1 = Rio de Janeiro\n2 = São Paulo\n3 = Vitória");

Console.Write("\nDigite o percurso (ex.: 1,2,0,1): ");
string percurso = Console.ReadLine();

List<int> cidadesPercurso;
try
{
    cidadesPercurso = percurso.Split(',')
                              .Select(num => int.Parse(num.Trim()))
                              .ToList();
}
catch (FormatException)
{
    Console.WriteLine("Entrada inválida! Use números inteiros separados por vírgulas.");
    return;
}

foreach (int trajeto in cidadesPercurso)
{
    if (trajeto < 0 || trajeto >= cidades.Length)
    {
        Console.WriteLine("Trajeto inválido. Por favor, insira números entre 0 e 3.");
        return;
    }
}

for (int i = 0; i < cidadesPercurso.Count - 1; i++)
{
    int cidadeAtual = cidadesPercurso[i];
    int proximaCidade = cidadesPercurso[i + 1];
    int distancia = distancias[cidadeAtual, proximaCidade];
    
    soma += distancia;
    Console.WriteLine("De {0} para {1}: {2} km", cidades[cidadeAtual], cidades[proximaCidade], distancia);
    
}

Console.WriteLine("\nA soma total das distâncias é de {0} km", soma);
