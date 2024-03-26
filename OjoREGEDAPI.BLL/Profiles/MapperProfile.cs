using AutoMapper;
using OjoREGED.BLL.DTOs;
using OjoREGEDAPI.BLL.DTOs;
using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerLoginDTO, Customer>().ReverseMap();

            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<EmployeeSchedule, EmployeeScheduleDTO>().ReverseMap();
            CreateMap<EmployeeLocation, EmployeeLocationDTO>().ReverseMap();
            CreateMap<employeeDTO, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDTO, Employee>();
            CreateMap<EmployeeInsertPickup, PickupSP>().ReverseMap();
            CreateMap<Pickup, PickupDTO>().ReverseMap();
            CreateMap<Bill, BillDTO>().ReverseMap();
            CreateMap<Employee_OrderPlacedDTO, EmployeeSchedule>().ReverseMap();


            CreateMap<InsertBookingSP, OrderPlacedSP>().ReverseMap();
            CreateMap<EmployeeSchedule, EmployeeCreateSchedule>().ReverseMap();

            CreateMap<OrderPlaced, OrderPlacedDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailsDTO>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<SubcriptionsLevel, SubscriptionLevelDTO>().ReverseMap();


            CreateMap<Address, AddressesDTO>().ReverseMap();
            CreateMap<AddressAddCustomer, AddressesDTO>();
            CreateMap<EmployeeLocationCreateDTO, EmployeeLocation>();
        }
    }
}
