using RecreioBarcode.Domain.Exceptions;

namespace RecreioBarcode.Domain.Entities;

public sealed class Location
{
    public int Id { get; private set; }
    public string Zona { get; private set; } = string.Empty;
    public int Rua { get; private set; }
    public int Estante { get; private set; }
    public string Prateleira { get; private set; } = string.Empty;
    public int Numero { get; private set; }
    public string Key { get; private set; } = string.Empty;

    private Location(){}
    public Location(string zona, int rua, int estante, string prateleira, int numero)
    {
        Validate(zona, rua, estante, prateleira, numero);

        Zona = zona.ToUpper();
        Rua = rua;
        Estante = estante;
        Prateleira = prateleira.ToUpper();
        Numero = numero;
        Key = $"{Zona}-{Rua}-{Prateleira}-{Estante}-{Numero}";
    }

    public void Update(string zona, int rua, int estante, string prateleira, int numero)
    {
        Validate(zona, rua, estante, prateleira, numero);
        
        Zona = zona.ToUpper();
        Rua = rua;  
        Estante = estante;
        Prateleira = prateleira.ToUpper();
        Numero = numero;
    }
    
    private bool HasOnlyLetters(string value)
    {
        if (string.IsNullOrEmpty(value))
            return false;

        return value.All(char.IsLetter);
    }
    private void Validate(string zona, int rua, int estante, string prateleira, int numero)
    {  
        if (string.IsNullOrWhiteSpace(zona))
            throw new DomainException("Zona is required");
        if (zona.Length > 2)
            throw new DomainException("Zona must have max of 2 characters.");
        if (!HasOnlyLetters(zona))
            throw new DomainException("Zona must have only letters (A-Z).");

        if (1 > rua || rua > 99)
            throw new DomainException("Rua must have a value between 1 and 99");

        if (1 > estante || estante > 999)
            throw new DomainException("Estante must have a value between 1 and 999");

        if (string.IsNullOrWhiteSpace(prateleira))
            throw new DomainException("Prateleira is required");
        if (prateleira.Length > 3)
            throw new DomainException("Prateleira must have max of 3 characters.");

        if (!HasOnlyLetters(prateleira))
            throw new DomainException("Prateleira must have only letters (A-Z).");

        if (1 > numero || numero > 999)
            throw new DomainException("Numero must have a value between 1 and 999");
    }
}
