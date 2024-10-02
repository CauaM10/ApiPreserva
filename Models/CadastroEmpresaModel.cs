namespace Api.Models
{
    public class CadastroEmpresaModel
    {
        public int CadastroEmpresaId { get; set; }

        public string NomeEmpresa { get; set; } = string.Empty;

        public int CnpjEmpresa { get; set; }

        public int TelefoneEmpresa { get; set; }

        public string EmailEmpresa { get; set; } = string.Empty;

        public string SenhaEmpresa { get; set; } = string.Empty;

        public static implicit operator List<object>(CadastroEmpresaModel v)
        {
            throw new NotImplementedException();
        }
    }
}
