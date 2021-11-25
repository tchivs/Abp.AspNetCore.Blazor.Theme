﻿using DemoApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DemoApp
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DemoAppEntityFrameworkCoreTestModule)
        )]
    public class DemoAppDomainTestModule : AbpModule
    {
        
    }
}
