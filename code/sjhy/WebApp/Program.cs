using Entity.Models;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Repository;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<MyContext>(opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DbCon")    
    )
);

//我们需要把IRolesDal和IRolesService实现依赖注入，允许我们通过构造函数来进行创建对象
builder.Services.AddScoped<IRolesDal,RolesDal>();
//上面的写法是 微软自带的依赖注入写法，这种写法在存在基类的时候是无法实现批量注入的
// 我们工作的时候解决方案，把微软自带的依赖注入用 Autofac 这个插件替换掉

//1. autofac 需要我们到Nuget当中进行安装，我们需要安装两个内容
//2. 开始注册autofac的服务
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//3. 我们需要使用 反射 来找到 Repository和Service对象的 程序集
builder.Host.ConfigureContainer<ContainerBuilder>(
    container =>
    {
        Assembly dal = Assembly.Load("Repository");
        container.RegisterAssemblyTypes(dal)
            .AsImplementedInterfaces().InstancePerDependency();


        Assembly bll = Assembly.Load("Services");
        container.RegisterAssemblyTypes(bll)
            .AsImplementedInterfaces().InstancePerDependency();
    }
  //4.去对应的实现层创建一个核心类，用于返回当前实现层的程序集名称

); 


// Assembly.Load("程序集名称") 用于找到我们指定的程序集
// 程序集就是我们当前项目当中的每一个项目组成模块 Entity  Repository
 



var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllerRoute(
        "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
