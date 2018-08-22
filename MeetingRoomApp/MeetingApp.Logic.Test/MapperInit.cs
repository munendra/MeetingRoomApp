using MeetingApp.Mapper;

namespace MeetingApp.Logic.Test
{
    public static class MapperInit
    {
     public  static void InitAutoMapper()
        {
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                var profiles = typeof(BookingMapper);
                cfg.AddProfiles(profiles);
            });
        }
    }
}
