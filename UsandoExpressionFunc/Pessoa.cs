namespace UsandoExpressionFunc
{
    public class Pessoa
    {
        public Pessoa()
        {

        }

        public Pessoa(string nome, char sexo, int idade)
        {
            Nome = nome;
            Sexo = sexo;
            Idade = idade;
        }
        public int Id { get; set; }
        public string Nome { get; private set; }
        public char Sexo { get; private set; }
        public int Idade { get; private set; }

        public override string ToString() => $"Id: {Id}, Nome: {Nome}, Sexo: {Sexo}, Idade: {Idade}";
    }
}
