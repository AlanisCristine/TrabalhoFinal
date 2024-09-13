using AutoMapper;
using TrabalhoFinal._03_Entidade.DTOs;
using TrabalhoFinal._03_Entidade;

namespace API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProdutoDTO, Produto>().ReverseMap();
            CreateMap<CreatePessoaDTO, Pessoa>().ReverseMap();
        }
    }
}
