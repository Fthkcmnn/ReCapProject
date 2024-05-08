using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.AutoMapper
{
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        public IMapper Configure(Profile profile)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });

            return config.CreateMapper();
        }
    }
}
