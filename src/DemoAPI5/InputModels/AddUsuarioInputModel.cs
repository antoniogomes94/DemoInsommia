namespace DemoAPI5.InputModels
{
    public class AddUsuarioInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool? Admin { get; set; }
    }
}
