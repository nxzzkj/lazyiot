
using Autofac;
using Autofac.Integration.Mvc;
using ScadaWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ScadaWeb.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MySqlHelper.connectionString = "Data Source="+Server.MapPath(MySqlHelper.datafile);
            RemoveWebFormEngines();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //����autofac����ע���������ʵ��
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            //ʹ��Autofac�ṩ��RegisterControllers��չ�������Գ��������е�Controllerһ���Ե����ע�� ֧������ע��
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            // ������װ�뵽΢��Ĭ�ϵ�����ע��������
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            //WebAPIֻ������services��repository�Ľӿڣ���������ʵ�ֵ�dll��
            //�������ʵ�ֵĳ��򼯣���dll������binĿ¼�¼��ɣ���������dll
            var iServices = Assembly.Load("ScadaWeb.IService");
            var services = Assembly.Load("ScadaWeb.Service");
            var iRepository = Assembly.Load("ScadaWeb.IRepository");
            var repository = Assembly.Load("ScadaWeb.Repository");

            //��������Լ���������Ľӿں�ʵ�־���Services��β����ʵ�ַ���ӿںͷ���ʵ�ֵ�����
            builder.RegisterAssemblyTypes(iServices, services)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces().PropertiesAutowired();

            //��������Լ�������ݷ��ʲ�Ľӿں�ʵ�־���Repository��β����ʵ�����ݷ��ʽӿں����ݷ���ʵ�ֵ�����
            builder.RegisterAssemblyTypes(iRepository, repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().PropertiesAutowired();
        }

        /// <summary>
        /// �Ƴ�webform��ͼ����
        /// </summary>
        void RemoveWebFormEngines()
        {
            var viewEngines = ViewEngines.Engines;
            var webFormEngines = viewEngines.OfType<WebFormViewEngine>().FirstOrDefault();
            if (webFormEngines != null)
            {
                viewEngines.Remove(webFormEngines);
            }
        }

    }
}
