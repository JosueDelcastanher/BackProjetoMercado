using AutoMapper;

namespace Shared
{
    public static class Map
    {
        public static TToChange ChangeValues<TOrigin, TToChange>(TOrigin origin) where TOrigin : class where TToChange : class
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TOrigin, TToChange>();
            });
            IMapper mapper = configuration.CreateMapper();
            return mapper.Map<TToChange>(origin);
        }
    }
}
