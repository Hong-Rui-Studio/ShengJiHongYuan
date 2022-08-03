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

//������Ҫ��IRolesDal��IRolesServiceʵ������ע�룬��������ͨ�����캯�������д�������
builder.Services.AddScoped<IRolesDal,RolesDal>();
//�����д���� ΢���Դ�������ע��д��������д���ڴ��ڻ����ʱ�����޷�ʵ������ע���
// ���ǹ�����ʱ������������΢���Դ�������ע���� Autofac �������滻��

//1. autofac ��Ҫ���ǵ�Nuget���н��а�װ��������Ҫ��װ��������
//2. ��ʼע��autofac�ķ���
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//3. ������Ҫʹ�� ���� ���ҵ� Repository��Service����� ����
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
  //4.ȥ��Ӧ��ʵ�ֲ㴴��һ�������࣬���ڷ��ص�ǰʵ�ֲ�ĳ�������

); 


// Assembly.Load("��������") �����ҵ�����ָ���ĳ���
// ���򼯾������ǵ�ǰ��Ŀ���е�ÿһ����Ŀ���ģ�� Entity  Repository
 



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
