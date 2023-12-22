using AutoMapper;
using BasicFinancial.Core.Models;
using BasicFinancial.DTO;

namespace BasicFinancial.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Account, AccountDTO>();
            CreateMap<Customer, CustomerDTO>();

            // Resource to Domain
            CreateMap<AccountDTO, Account>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<SaveAccountDTO, Account>();
            CreateMap<SaveCustomerDTO, Customer>();
        }
    }
}
